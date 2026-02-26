using TarefasMaui.Helpers;
using TarefasMaui.Models;
using TarefasMaui.Services;

namespace TarefasMaui.View;

public partial class TarefasView : ContentPage
{
    public List<Tarefa> listaTarefas { get; set; } = new List<Tarefa>();
    public List<Tarefa> listaTarefasAtribuidas { get; set; } = new List<Tarefa>();
    public TarefasView()
    {
        InitializeComponent();

        Carregar();
    }

    private async void Carregar()
    {
        var r = await new PadraoService().GetTarefas();
        var r2 = await new PadraoService().GetTarefasAtribuidas();
        if (r != null)
        {
            listaTarefas = r;
            listaTarefasAtribuidas = r2;

            BindingContext = null;
            BindingContext = this;

        }

    }

    public async void OnStatus(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("StatusView");
    }
    public async void OnCriarTarefa(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("AdicionarTarefaView");
    }

    public async void OnBuscar(object sender, EventArgs e)
    {

    }
}