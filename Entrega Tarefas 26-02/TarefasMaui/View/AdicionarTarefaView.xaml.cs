using TarefasMaui.Helpers;
using TarefasMaui.Models;
using TarefasMaui.Services;
using static TarefasMaui.Services.PadraoService;

namespace TarefasMaui.View;

public partial class AdicionarTarefaView : ContentPage
{
    public AdicionarTarefaView()
    {
        InitializeComponent();
        Carregar();
    }

    private async void Carregar()
    {
        pckStatus.ItemsSource = await new PadraoService().GetStatus();
        pckUsuario.ItemsSource = await new PadraoService().GetUsuarios();
    }
    public async void OnCriar(object sender, EventArgs e)
    {
        var st = pckStatus.SelectedItem as Status;
        var ut = pckUsuario.SelectedItem as Usuarios;
        // Use DateTime.Today em vez de DateTime.Now
        if (st == null || ut == null ||
            string.IsNullOrWhiteSpace(txtTitulo.Text) ||
            string.IsNullOrWhiteSpace(txtDescricao.Text))
        {
            await DisplayAlert("Erro", "Preencha todos os campos! ", "OK");
            return;
        }
        try
        {
            var tarefa = new CreateTarefasDTO
            {
                DataVencimento = dtpData.Date,
                Descricao = txtDescricao.Text,
                Titulo = txtTitulo.Text,
                Status = st.Id,
                UsuarioDestinatario = ut.Id,
                UsuarioRemetente = Global.user.Id
            };

            await new PadraoService().CadastrarTarefas(tarefa);

            await DisplayAlert("Sucesso", "Cadastrado com sucesso!", "OK");

            await Shell.Current.GoToAsync("///TarefasView");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", "Falha ao salvar: " + ex.Message, "OK");
        }
    }
}