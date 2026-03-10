using System.Threading.Tasks;
using TarefasMauiv2.DTOs;
using TarefasMauiv2.Models;
using TarefasMauiv2.Services;

namespace TarefasMauiv2.View;

public partial class AddTarefaView : ContentPage
{
    public AddTarefaView()
    {
        InitializeComponent();
        Carregar();
    }

    private async void Carregar()
    {
        var colunas = await new PadraoService().Get<List<Coluna>>($"Colunas/{Global.board.Id}");
        var usuarios = await new PadraoService().Get<List<Usuario>>($"Usuario/{Global.board.Id}");

        pckColuna.ItemsSource = colunas;
        pckUsuarios.ItemsSource = usuarios;
    }

    private async void OnCadastrar(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtTitulo.Text) || string.IsNullOrEmpty(txtDescricao.Text)
            || pckColuna.SelectedIndex < 0 || pckUsuarios.SelectedIndex < 0)
        {
            await DisplayAlert("Erro", "Preencha todos os dados corretamente!", "OK");
            return;

        }
        var data = new DateTime(
           txtDataVencimento.Date.Year,
           txtDataVencimento.Date.Month,
           txtDataVencimento.Date.Day,
           txtHoraVencimento.Time.Hours,
           txtHoraVencimento.Time.Minutes,
           0
           );

        if (data < DateTime.Now)
        {
            await DisplayAlert("Erro", "Esse horario ja passou!", "OK");
            return;
        }


        var cs = pckColuna.SelectedItem as Coluna;
        var us = pckUsuarios.SelectedItem as Usuario;
        if (us == null)
        {
            await DisplayAlert("Erro", "Usuario invalido!", "OK");
            return;
        }
        if (cs == null)
        {
            await DisplayAlert("Erro", "Coluna invalida!", "OK");
            return;
        }
        var t = new CreateTarefaDTO
        {
            BoardId = Global.board.Id,
            ColunaId = cs.Id,
            Descricao = txtDescricao.Text,
            Titulo = txtTitulo.Text,
            Vencimento = data,
            UsuarioCriadorId = Global.user.Id,
            UsuarioDestinoId = us.Id

        };

        var r = await new PadraoService().Post<Tarefa>("Tarefas", t);
        if (r != null)
        {
            await DisplayAlert("Sucesso", "Cadastrado com sucesso!", "OK");
        }
        else
        {
            await DisplayAlert("Erro", "Esse horario ja passou!", "OK");
        }

        await Shell.Current.GoToAsync("TarefasView");



    }
}