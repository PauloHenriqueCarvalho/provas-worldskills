using System.Threading.Tasks;
using Prova3_Mobile_MAUI.DTO;
using Prova3_Mobile_MAUI.Models;
using Prova3_Mobile_MAUI.Service;

namespace Prova3_Mobile_MAUI
{
    public partial class MainPage : ContentPage
    {
        int tentativas = 2;
        public MainPage()
        {
            InitializeComponent();
            txtCpf.Text = "12345678901";
            txtSenha.Text = "abcd1234";
        }



        private async void OnEntrar(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtCpf.Text))
            {
                await DisplayAlert("Erro", "CPF não pode estar vazio", "OK");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                await DisplayAlert("Erro", "Senha não pode estar vazio", "OK");
                return;
            }
            var r = (LoginResponseDTO)await new ApiService().Post<LoginResponseDTO>("Usuario", new { cpf = txtCpf.Text, senha = txtSenha.Text });
            if (r is null)
            {
                await DisplayAlert("Erro", "Cpf ou senha invalido!", "OK");


                return;
            }
            Global.user = r;
            await DisplayAlert("Sucesso", "Bem vindo! " + r.Perfil, "OK");
            if (r.Perfil != "Idoso")
            {
                await Shell.Current.GoToAsync("LoginResponsavelView");
            }

        }

        private void Tentativas

        private void OnCadastrar(object sender, EventArgs e)
        {

        }
    }
}
