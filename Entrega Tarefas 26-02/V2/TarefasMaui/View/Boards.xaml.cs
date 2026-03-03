using System.Collections.ObjectModel;
using TarefasAPI_v2.Models;
using TarefasMaui.Helpers;
using TarefasMaui.Services;
using static TarefasMaui.Services.PadraoService;

namespace TarefasMaui.View;

public partial class Boards : ContentPage
{
    public ObservableCollection<Board> BoardsList { get; set; } = new();


    public Boards()
    {
        InitializeComponent();
        BindingContext = this;
        Carregar();

    }

    public async void Carregar()
    {
        var l = await new PadraoService().GetBoardsUsuario();
        BoardsList.Clear();
        foreach (var board in l)
        {
            BoardsList.Add(board);
        }

        OnPropertyChanged(nameof(BoardsList));

    }

    private async void OnBoardSelecionado(object sender, TappedEventArgs e)
    {
        var board = e.Parameter as Board;
        if (board == null) return;
        Global.board = board;
        await Shell.Current.GoToAsync("TarefasView");
    }

    private async void OnNovoBoard(object sender, EventArgs e)
    {
        string nomeBoard = await DisplayPromptAsync(
            "Novo Quadro",
            "Digite o nome do quadro:",
            "Criar",

            "Cancelar",
            "Ex: Projeto de vendas");
        if (!string.IsNullOrWhiteSpace(nomeBoard))
        {
            try
            {
                var dto = new CreateBoardDTO
                {
                    nome = nomeBoard,
                    IdCriador = Global.user.Id
                };
                var s = await new PadraoService().CreateBoard(dto);
                await DisplayAlert("Secesso", "Quadro criado com sucesso!", "OK");
                Carregar();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", "Não foi possivel criar o quadro", "OK");
            }
        }
    }


}