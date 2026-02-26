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

    public async void OnBuscar(object sender, EventArgs e)
    {

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