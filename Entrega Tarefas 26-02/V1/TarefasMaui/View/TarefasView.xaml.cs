using TarefasMaui.Helpers;
using TarefasMaui.Models;
using TarefasMaui.Services;

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
        var r = await new PadraoService().GetTarefas();
        var r2 = await new PadraoService().GetTarefasAtribuidas();
        var status = await new PadraoService().GetStatus();
        var tarefas = r.Concat(r2).DistinctBy(x => x.Id).ToList();

        ColunasStatus = status.Select(s => new StatusColuna
        {
            Status = s,
            Tarefas = tarefas.Where(x => x.Status.Id == s.Id).ToList()
        }).ToList();



        BindingContext = null;
        BindingContext = this;



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
        var r = await new PadraoService().GetTarefas();
        var r2 = await new PadraoService().GetTarefasAtribuidas();
        var status = await new PadraoService().GetStatus();
        var tarefas = r.Concat(r2).DistinctBy(x => x.Id).ToList();

        tarefas = tarefas.Where(x => x.Titulo.Contains(txtBusca.Text)).ToList();

        ColunasStatus = status.Select(s => new StatusColuna
        {
            Status = s,
            Tarefas = tarefas.Where(x => x.Status.Id == s.Id).ToList()
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
        listaBotoes.AddRange(ColunasStatus.Select(x => x.Status.Nome));

        string acao = await DisplayActionSheet($"Tarefa: {tarefa.Titulo}", "Cancelar", "Excluir", listaBotoes.ToArray());
        var opcoesStatus = ColunasStatus.Select(c => c.Status.Nome).ToArray();

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
            var novoStatus = ColunasStatus.FirstOrDefault(c => c.Status.Nome == acao)?.Status;

            if (novoStatus != null && novoStatus.Id != tarefa.Status.Id)
            {
                await new PadraoService().AtualizarStatusTarefa(tarefa.Id, novoStatus.Id);
                Carregar();
            }
        }
    }



}