using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TarefasMauiv2.DTOs;
using TarefasMauiv2.Models;
using TarefasMauiv2.Services;

namespace TarefasMauiv2.View;

public partial class BoardsView : ContentPage
{
    public ObservableCollection<Board> Boards { get; set; }

    public BoardsView()
    {
        InitializeComponent();
        Carregar();
    }

    private async Task Carregar()
    {
        var l = await new PadraoService().Get<List<Board>>($"Board/{Global.user.Id}");
        Boards = new ObservableCollection<Board>(l);
        BindingContext = null;
        BindingContext = this;
    }
    private void OnAdd(object sender, EventArgs e)
    {

    }

    private async void OnExcluir(object sender, TappedEventArgs e)
    {
        var b = e.Parameter as Board;
        if (b == null) return;

        Global.board = b;
        var tarefasQuadro = await new PadraoService().Get<List<Tarefa>>($"tarefas/{b.Id}");
        if (tarefasQuadro.Count == 0)
        {
            bool con = await DisplayAlert("Atenção", "Deseja excluir esse quadro?", "Sim", "Não");
            if (con)
            {
                await new PadraoService().Delete($"Board/{b.Id}");
                await DisplayAlert("Sucesso", "Quadro excluido com sucesso!", "Ok");
                Carregar();
                OnPropertyChanged(nameof(Boards));
            }
            return;
        }

        var boardsUsuario = await new PadraoService().Get<List<Board>>($"board/{Global.user.Id}");
        if (boardsUsuario.Count == 1)
        {
            await DisplayAlert("Erro", "Impossivel excluir esse board com tarefas pendentes! Nenhum outro disponivel", "OK");
            return;
        }

        var destino = boardsUsuario.Where(x => x.Id != b.Id).ToList();
        if (destino.Count == 0)
        {
            await DisplayAlert("Erro", "Impossivel excluir esse board com tarefas pendentes! Nenhum outro disponivel", "OK");
            return;
        }
        string action = await DisplayActionSheet($"O quadro '{b.Nome}' tem {tarefasQuadro.Count} tarefas. O que deseja fazer?", "Cancelar", "Excluir tudo", "Transferir para outro quadro");
        if (action.Equals("Excluir tudo"))
        {
            await new PadraoService().Delete($"Board/{b.Id}");
            await DisplayAlert("Sucesso", "Quadro excluido com sucesso!", "Ok");
            Carregar();
            OnPropertyChanged(nameof(Boards));

        }
        else if (action.Equals("Transferir tarefas para outro quadro"))
        {
            await Tranferir(b);
            Carregar();
            OnPropertyChanged(nameof(Boards));
        }

    }

    private async Task Tranferir(Board b)
    {
        var boardsUsuario = await new PadraoService().Get<List<Board>>($"board/{Global.user.Id}");
        var d = boardsUsuario.Where(x => x.Id != b.Id).ToList();
        string[] nomes = d.Select(s => s.Nome).ToArray();

        string escolha = await DisplayActionSheet("Escolha o quadro de destino:", "Cancelar", null, nomes);
        if (escolha != "Cancelar" && !string.IsNullOrWhiteSpace(escolha))
        {
            var bd = d.FirstOrDefault(x => x.Nome == escolha);

            await new PadraoService().Put<Tarefa>($"tranferir-tarefas/{b.Id}/{bd.Id}", null);

            await new PadraoService().Delete($"Board/{b.Id}");
            await DisplayAlert("Sucesso", "Quadro excluido com sucesso!", "Ok");
            Carregar();
            OnPropertyChanged(nameof(Boards));
        }

    }

    private async void OnEditarNome(object sender, TappedEventArgs e)
    {
        var b = e.Parameter as Board;
        if (b == null) return;
        string novoNome = await DisplayPromptAsync("Editar board", "Digite o novo nome do quadro", "Salvar", "Cancelar", initialValue: b.Nome);
        {
            var res = await new PadraoService().Put<Board>($"Board/{b.Id}", new CreateBoardDTO { Nome = novoNome });
            if (res != null)
            {
                await DisplayAlert("Sucesso", "Nome alterado com sucesso!", "OK");
            }
            else
            {
                await DisplayAlert("Erro", "Erro ao editar nome!", "OK");

            }

            Carregar();
            OnPropertyChanged(nameof(Boards));
        }

    }
}