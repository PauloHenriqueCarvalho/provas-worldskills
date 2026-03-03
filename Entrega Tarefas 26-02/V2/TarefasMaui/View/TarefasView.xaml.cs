using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using TarefasAPI_v2.Models;
using TarefasMaui.Helpers;
using TarefasMaui.Models;
using TarefasMaui.Services;
using static TarefasMaui.Services.PadraoService;

namespace TarefasMaui.View;


public partial class TarefasView : ContentPage
{
    public List<StatusColuna> ColunasStatus { get; set; } = new List<StatusColuna>();
    public TarefasView()
    {
        InitializeComponent();

        Carregar();

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Carregar();
    }

    private async void Carregar()
    {
        var colunas = await new PadraoService().GetColunas();
        var tarefas = await new PadraoService().GetTarefas();


        colunas ??= new List<Coluna>();
        tarefas ??= new List<Tarefa>();



        ColunasStatus = colunas
            .OrderBy(x => x.Ordem)
            .Select(s => new StatusColuna
            {
                Coluna = s,
                Tarefas = tarefas.Where(x => x.ColunaId == s.Id).ToList()
            }).ToList();

        BindingContext = null;
        BindingContext = this;
    }

    public async void OnStatus(object sender, EventArgs e)
    {
        string nomeColuna = await DisplayPromptAsync("Nova Coluna", "Qual o nome da nova etapa? (ex: Testes)", "Criar", "Cancelar");
        if (string.IsNullOrEmpty(nomeColuna))
            return;


        int ordem = ColunasStatus.Count + 1;

        if (ColunasStatus.Any(x => x.Coluna.Nome == nomeColuna))
        {
            await DisplayAlert("Erro!", "Ja existe uma coluna com esse nome!", "Ok");
            return;
        }
        var dto = new Coluna
        {
            Cor = "#333",
            Nome = nomeColuna,
            BoardId = Global.board.Id,
            Ordem = ordem,

        };

        await new PadraoService().CreateStatus(dto);

        await DisplayAlert("Sucesso!", "Criado com sucesso!", "Ok");
        Carregar();
        //await Shell.Current.GoToAsync("StatusView");
    }
    public async void OnCriarTarefa(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("AdicionarTarefaView");
    }

    public async void OnBuscar(object sender, EventArgs e)
    {
        var colunas = await new PadraoService().GetColunas();
        var tarefas = await new PadraoService().GetTarefas();

        tarefas = tarefas.Where(x => x.Titulo.Contains(txtBusca.Text)).ToList();

        ColunasStatus = colunas.Select(s => new StatusColuna
        {
            Coluna = s,
            Tarefas = tarefas.Where(x => x.ColunaId == s.Id).ToList()
        }).ToList();



        BindingContext = null;
        BindingContext = this;
    }


    Tarefa tarefaSendoArrastada;

    private async void OnMoverTarefaTapped(object sender, TappedEventArgs e)
    {
        var border = sender as Border;
        var tarefa = border?.BindingContext as Tarefa;

        if (tarefa == null) return;

        var listaBotoes = new List<string> { "Editar" };
        listaBotoes.AddRange(ColunasStatus.Select(x => x.Coluna.Nome));

        string acao = await DisplayActionSheet($"Tarefa: {tarefa.Titulo}", "Cancelar", "Excluir", listaBotoes.ToArray());
        var opcoesStatus = ColunasStatus.Select(c => c.Coluna.Nome).ToArray();

        if (acao == "Cancelar" || string.IsNullOrEmpty(acao))
        {
            return;
        }

        if (acao == "Editar")
        {
            await Shell.Current.GoToAsync($"AdicionarTarefaView?Id={tarefa.Id}");
            return;
        }

        if (acao == "Excluir")
        {
            bool confir = await DisplayAlert("Confirmar", $"Deseja realmente a tarefa '{tarefa.Titulo}'?", "Sim", "Não");
            if (confir)
            {
                await new PadraoService().DeletarTarefa(tarefa.Id);
                Carregar();
            }
        }

        if (acao != null && acao != "Cancelar")
        {
            var novoStatus = ColunasStatus.FirstOrDefault(c => c.Coluna.Nome == acao)?.Coluna;

            if (novoStatus != null && novoStatus.Id != tarefa.Coluna.Id)
            {
                await new PadraoService().AtualizarStatusTarefa(tarefa.Id, novoStatus.Id);
                Carregar();
            }
        }
    }

    private async void OnAddUser(object sender, EventArgs e)
    {
        var users = await new PadraoService().GetUsuarios();

        users = users.Where(x => x.Id != Global.user.Id).ToList();

        var listaUsuariosBoard = Global.board.Usuarios;

        var userList = users.Where(x => !listaUsuariosBoard.Any(v => v.Id == x.Id)).ToList();


        userList = userList.Where(x => x.Id != Global.user.Id).ToList();

        var nomes = userList.Select(u => u.Nome).ToArray();
        if (!nomes.Any())
        {
            await DisplayAlert("Atenção", "Todos usuarios ja estao nesse quadro!", "Ok");
            return;
        }
        string escolha = await DisplayActionSheet("Convidar para o quadro", "Cancelar", null, nomes);
        if (!string.IsNullOrEmpty(escolha))
        {
            var userSelecionado = userList.First(u => u.Nome == escolha);

            var dto = new AddUserBoardDTO
            {
                IdUsuario = userSelecionado.Id,
                idBoard = Global.board.Id,
            };
            await new PadraoService().AddUserBoard(dto);
            await DisplayAlert("Sucesso", "Usuario adicionado com sucesso!", "Ok");


            var l = await new PadraoService().GetBoardsUsuario();

            var board = l.Where(x => x.Id == Global.board.Id).FirstOrDefault();
            Global.board = board;

        }
    }

    StatusColuna colunaSendoArrastada;
    private void OnColunaDragStarting(object sender, DragStartingEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("MÉTODO DE ARRASTAR DISPARADO!");
        var elemento = sender as Element;
        var coluna = colunaSendoArrastada = elemento?.BindingContext as StatusColuna;
        if (coluna == null) return;
        colunaSendoArrastada = coluna;
        e.Data.Properties.Add("ColunaId", coluna);
    }
    private async void OnColunaDrop(object sender, DropEventArgs e)
    {
        var elementoDestino = sender as Element;
        var colunaDestino = elementoDestino?.BindingContext as StatusColuna;

        if (colunaSendoArrastada == null || colunaSendoArrastada == colunaDestino)
            return;

        int indiceOrigem = ColunasStatus.IndexOf(colunaSendoArrastada);
        int indiceDestino = ColunasStatus.IndexOf(colunaDestino);

        if (indiceOrigem != -1 && indiceDestino != -1)
        {
            ColunasStatus.RemoveAt(indiceOrigem);
            ColunasStatus.Insert(indiceDestino, colunaSendoArrastada);

            for (int i = 0; i < ColunasStatus.Count; i++)
            {
                ColunasStatus[i].Coluna.Ordem = i + 1;
            }

            var tempLista = ColunasStatus.ToList();
            ColunasStatus = tempLista;

            BindingContext = null;
            BindingContext = this;
            await SalvarNovaOrdem();
        }
    }

    private async Task SalvarNovaOrdem()
    {
        try
        {
            var ordens = ColunasStatus;
            await new PadraoService().AtualizarOrdensColunas(ordens);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", "Falha ao salvar ordem: " + ex.Message, "OK");
        }
    }

}