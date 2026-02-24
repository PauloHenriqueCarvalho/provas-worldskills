using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sessao2Desktop2.Data;

namespace Sessao2Desktop2.View
{
    public partial class DetalhesView : Form
    {
        SolicitacoesView v;
        public DetalhesView(SolicitacoesView s)
        {
            InitializeComponent();
            Theme.Apply(this);
            v = s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            v.Detalhes(0);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            v.Detalhes(0);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            v.Detalhes(0);
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            v.Detalhes(0);
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            v.Detalhes(0);
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            v.Detalhes(0);
            this.Close();
        }
    }
}
