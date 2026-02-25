using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sessao2Desktop3.data;

namespace Sessao2Desktop3.View
{
    public partial class DetalhesView : Form
    {
        TelaSolicitacao t;
        public DetalhesView(TelaSolicitacao s)
        {
            InitializeComponent();
            Theme.Apply(this);
            t = s;
        }

        private void DetalhesView_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            t.Detalhes(1);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t.Detalhes(2);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            t.Detalhes(3);
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            t.Detalhes(4);
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            t.Detalhes(5);
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            t.Detalhes(6);
            this.Close();
        }
    }
}
