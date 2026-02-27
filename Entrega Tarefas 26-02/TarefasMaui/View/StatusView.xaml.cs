using System.Text.RegularExpressions;
using TarefasMaui.Models;
using TarefasMaui.Services;

namespace TarefasMaui.View;

public partial class StatusView : ContentPage
{
    public List<Status> listaStatus { get; set; }
    public StatusView()
    {
        InitializeComponent();
        Carregar();
    }

    public async void Carregar()
    {
        var r = await new PadraoService().GetStatus();
        if (r != null)
        {
            listaStatus = r;
            BindingContext = null;
            BindingContext = this;
        }
    }

    public async void OnExcluirStatusTapped(object sender, EventArgs e)
    {
        var border = sender as Border;
        var status = border?.BindingContext as Status;

        if (status == null) return;
        bool confirmacao = await DisplayAlert("Excluir Status", $"Desejo realmente excluir o status '{status.Nome}'?", "Sim", "Não");
        if (confirmacao)
        {
            try
            {
                await new PadraoService().DeletarStatus(status.Id);
                await DisplayAlert("Sucesso", "Status excluido com sucesso!", "OK");
                Carregar();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro ", "Não foi possivel excluir: " + ex.Message, "OK");
            }
        }

    }
    public async void OnBuscar(object sender, EventArgs e)
    {
        var r = await new PadraoService().GetStatus();
        r = r.Where(x => x.Nome.Contains(txtBusca.Text)).ToList();
        if (r != null)
        {
            listaStatus = r;
            BindingContext = null;
            BindingContext = this;
        }
    }
    public async void OnAdicionar(object sender, EventArgs e)
    {
        var cor = txtCor.Text;
        if (string.IsNullOrWhiteSpace(cor) || string.IsNullOrWhiteSpace(txtNome.Text))
        {
            await DisplayAlert("Erro", "Preencha todos os campos", "OK");

        }

        var regex = new Regex(@"^#([A-Fa-f0-9]{3}|[A-Fa-f0-9]{6})$");
        if (string.IsNullOrEmpty(cor) || !regex.IsMatch(cor))
        {
            await DisplayAlert("Erro", "Cor inválida! Use o formato #FFF ou #FFFFFF", "OK");
            return;
        }
        var dto = new Status
        {
            Cor = cor,
            Nome = txtNome.Text,
        };

        await new PadraoService().CreateStatus(dto);
        await DisplayAlert("Sucesso", "Cadastrado com sucesso!", "OK");
        Carregar();


    }

}