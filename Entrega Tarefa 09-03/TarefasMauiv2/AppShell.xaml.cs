using TarefasMauiv2.View;

namespace TarefasMauiv2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("BoardsView", typeof(BoardsView));
            Routing.RegisterRoute("TarefasView", typeof(TarefasView));
            Routing.RegisterRoute("AddTarefaView", typeof(AddTarefaView));
        }
    }
}
