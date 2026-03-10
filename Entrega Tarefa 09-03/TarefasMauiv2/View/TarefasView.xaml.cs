using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TarefasMauiv2.DTOs;
using TarefasMauiv2.Models;
using TarefasMauiv2.Services;

namespace TarefasMauiv2.View;

public partial class TarefasView : ContentPage
{

    public ObservableCollection<TarefasColuna> Colunas { get; set; } = new ObservableCollection<TarefasColuna>();

    public TarefasView()
    {
        InitializeComponent();
        Carregar();
    }

    private async void Carregar()
    {

        var l = await new PadraoService().Get<List<Coluna>>($"Colunas/{Global.board.Id}");
        List<TarefasColuna> newList = new List<TarefasColuna>();

        if (!string.IsNullOrEmpty(txtbuscar.Text))
        {
            l = l.Where(x => x.Tarefas.Any(s => s.Titulo.Equals(txtbuscar.Text) || s.Usuarios.Any(q => q.Nome.Equals(txtbuscar.Text)))).ToList();
        }

        foreach (var coluna in l)
        {
            newList.Add(new TarefasColuna
            {
                Coluna = coluna,
                Tarefas = new List<Tarefa>(coluna.Tarefas)
            });

        }

        Colunas = new ObservableCollection<TarefasColuna>(newList);
        BindingContext = null;
        BindingContext = this;
    }
    private async void OnBuscar(object sender, EventArgs e)
    {
        Carregar();
    }

    private async void onExcluirColuna(object sender, TappedEventArgs e)
    {
        var c = e.Parameter as Coluna;

        if (c.Tarefas.Count != 0)
        {
            await DisplayAlert("Erro", "Não é posivel deletar coluna com tarefas!", "Ok");
            return;
        }

        var res = await DisplayAlert("Atenção", "Deseja excluir a coluna?", "Sim", "Cencelar");
        if (res)
        {
            await new PadraoService().Delete($"Colunas/{c.Id}");
            await DisplayAlert("Sucesso", "Deletado com sucesso", "Ok");
        }
        Carregar();
    }

    private async void OnMoverTarefa(object sender, TappedEventArgs e)
    {
        var t = e.Parameter as Tarefa;

        if (t == null) return;


        string[] nomes = Colunas.Where(x => x.Coluna.Id != t.ColunaId).Select(s => s.Coluna.Nome).ToArray();

        string escolha = await DisplayActionSheet("Mover para coluna:", "Cancelar", null, nomes);
        if (escolha != "Cancelar" && !string.IsNullOrWhiteSpace(escolha))
        {
            var colunaSelecionada = Colunas.FirstOrDefault(x => x.Coluna.Nome == escolha);
            await new PadraoService().Put<Tarefa>($"Tarefas/mover/{t.Id}/{colunaSelecionada.Coluna.Id}", null);
            await DisplayAlert("Sucesso", "Movido com sucesso", "Ok");

        }
        Carregar();
    }

    TarefasColuna colunaArrastada;
    private void OnColunaDragStarting(object sender, DragStartingEventArgs e)
    {
        var elemento = sender as Element;

        var coluna = colunaArrastada = elemento?.BindingContext as TarefasColuna;
        if (coluna == null) return;
        colunaArrastada = coluna;
        e.Data.Properties.Add("ColunaId", coluna);
    }
    private async Task SalvarNovaOrdem()
    {
        try
        {
            var ordens = Colunas;
            var dados = ordens.Select(x => new { Id = x.Coluna.Id, Ordem = x.Coluna.Ordem });
            await new PadraoService().Put<Coluna>("Colunas/Ordenar", dados);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", "Falha ao salvar ordem: " + ex.Message, "OK");
        }
    }
    private async void OnColunaDrop(object sender, DropEventArgs e)
    {
        var elementoDestino = sender as Element;
        var colunaDestino = elementoDestino?.BindingContext as TarefasColuna;

        if (colunaArrastada == null || colunaArrastada == colunaDestino) return;

        int indiceOrigem = Colunas.IndexOf(colunaArrastada);
        int indiceDestino = Colunas.IndexOf(colunaDestino);
        if (indiceOrigem != -1 && indiceDestino != -1)
        {
            Colunas.RemoveAt(indiceOrigem);
            Colunas.Insert(indiceDestino, colunaArrastada);

            for (int i = 0; i < Colunas.Count; i++)
            {
                Colunas[i].Coluna.Ordem = i + 1;
            }
            var tempList = Colunas.ToList();
            Colunas = new ObservableCollection<TarefasColuna>(tempList);
            BindingContext = null;
            BindingContext = this;
            await SalvarNovaOrdem();
        }


    }

    private async void OnAddTarefa(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("AddTarefaView");
    }

    private async void OnAddColuna(object sender, EventArgs e)
    {
        var nome = await DisplayPromptAsync("Nova Coluna", "Digiteo nome da coluna: ", "Salvar", "Cancelar");
        if (string.IsNullOrEmpty(nome))
            return;
        var r = await new PadraoService().Post<Coluna>("Colunas", new CreateColunaDTO { Nome = nome, BoardId = Global.board.Id });
        if (r != null)
        {
            await DisplayAlert("Sucesso", "Coluna cadastrada com sucesso!", "OK");
        }
        else
        {
            await DisplayAlert("Erro", "Ja existe uma coluna com esse nome!", "OK");

        }
        Carregar();
    }

    private async void onAddUsuario(object sender, EventArgs e)
    {
        var boardsUsuario = await new PadraoService().Get<List<Usuario>>($"Usuario");

        boardsUsuario = boardsUsuario
            .Where(x => Global.user.Id != x.Id && !Global.board.Usuarios.Any(d => d.Id == x.Id))
            .ToList();
        if (boardsUsuario.Count == 0)
        {
            await DisplayAlert("Atenção", "Nenhum usuario disponivel!", "Ok");
            return;
        }

        string[] nomes = boardsUsuario.Select(s => s.Nome).ToArray();

        string escolha = await DisplayActionSheet("Escolha o usuario que dejesa adicionar:", "Cancelar", null, nomes);
        if (escolha != "Cancelar" && !string.IsNullOrWhiteSpace(escolha))
        {
            var usuarioSelecionado = boardsUsuario.FirstOrDefault(x => x.Nome == escolha);

            await new PadraoService().Put<Tarefa>($"Board/adicionar-usuario/{Global.board.Id}/{usuarioSelecionado.Id}", null);

            await DisplayAlert("Sucesso", "Usuario adicionado com sucesso!", "Ok");
            Global.board.Usuarios.Add(usuarioSelecionado);

            Carregar();
        }
    }

    private async void OnRemoveUsuario(object sender, EventArgs e)
    {
        var boardsUsuario = await new PadraoService().Get<List<Usuario>>($"Usuario");

        boardsUsuario = boardsUsuario
            .Where(x => Global.user.Id != x.Id && Global.board.Usuarios.Any(d => d.Id == x.Id))
            .ToList();

        if (boardsUsuario.Count == 0)
        {
            await DisplayAlert("Atenção", "Nenhum usuario disponivel!", "Ok");
            return;
        }
        string[] nomes = boardsUsuario.Select(s => s.Nome).ToArray();

        string escolha = await DisplayActionSheet("Escolha o usuario que dejesa remover:", "Cancelar", null, nomes);
        if (escolha != "Cancelar" && !string.IsNullOrWhiteSpace(escolha))
        {
            var usuarioSelecionado = boardsUsuario.FirstOrDefault(x => x.Nome == escolha);

            await new PadraoService().Put<Tarefa>($"Board/remover-usuario/{Global.board.Id}/{usuarioSelecionado.Id}", null);

            await DisplayAlert("Sucesso", "Usuario removido com sucesso!", "Ok");

            var usuarioBoard = Global.board.Usuarios
                .FirstOrDefault(x => x.Id == usuarioSelecionado.Id);

            if (usuarioBoard != null)
            {
                Global.board.Usuarios.Remove(usuarioBoard);
            }

            Carregar();
        }
    }

    private void OnSair(object sender, EventArgs e)
    {

    }
}