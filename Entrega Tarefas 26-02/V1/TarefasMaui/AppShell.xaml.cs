using TarefasMaui.View;

namespace TarefasMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("TarefasView", typeof(TarefasView));
            Routing.RegisterRoute("CadastroView", typeof(CadastroView));
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("StatusView", typeof(StatusView));
            Routing.RegisterRoute("AdicionarTarefaView", typeof(AdicionarTarefaView));

        }
    }
}
