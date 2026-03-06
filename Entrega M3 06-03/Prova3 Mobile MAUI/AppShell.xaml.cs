using Prova3_Mobile_MAUI.View;

namespace Prova3_Mobile_MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("LoginResponsavelView", typeof(LoginResponsavelView));
        }
    }
}
