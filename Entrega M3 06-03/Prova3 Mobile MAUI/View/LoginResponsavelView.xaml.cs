using System.Collections.ObjectModel;
using Prova3_Mobile_MAUI.Models;

namespace Prova3_Mobile_MAUI.View;

public partial class LoginResponsavelView : ContentPage
{

    public ObservableCollection<Pessoa>? Idosos { get; set; } = new ObservableCollection<Pessoa>();
    public string Nome { get; set; } = "Bem vindo, " + Global.user.Nome;
    public LoginResponsavelView()
    {
        InitializeComponent();
        if (Global.user.Idosos != null)
        {
            Idosos = new ObservableCollection<Pessoa>(Global.user.Idosos);

        }
        BindingContext = null;
        BindingContext = this;
    }

    private void OnUsuarioSelecionado(object sender, EventArgs e)
    {

    }
}