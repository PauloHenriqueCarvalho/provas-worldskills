using TarefasMauiv2.DTOs;
using TarefasMauiv2.Models;
using TarefasMauiv2.Services;
using TarefasMauiv2.View;

namespace TarefasMauiv2
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }


        private async void OnEntrar(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogin.Text) || string.IsNullOrEmpty(txtSenha.Text))
            {
                await DisplayAlert("Erro", "Preencha todos os campos!", "Ok");
                return;
            }

            var u = await new PadraoService().Post<Usuario>("Usuario/Login", new LoginDTO
            {
                Login = txtLogin.Text,
                Senha = txtSenha.Text
            });
            if (u == null)
            {
                await DisplayAlert("Erro", "Login ou senha incorreto!", "Ok");
                return;
            }

            Global.user = u;
            await DisplayAlert("Sucesso", "Bem vindo!", "Ok");
            await Shell.Current.GoToAsync("BoardsView");


        }
    }
}
