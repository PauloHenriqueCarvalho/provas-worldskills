using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sessao2.Data;

namespace Sessao2._1302
{
    public partial class OrdenarView : Form
    {
        Form1 _f;
        public OrdenarView(Form1 f)
        {
            InitializeComponent();
            _f = f;
            Theme.Apply(this);
        }

        private void OrdenarView_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _f.Ordenacao(2);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _f.Ordenacao(1);
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _f.Ordenacao(3);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _f.Ordenacao(4);
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _f.Ordenacao(5);
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _f.Ordenacao(6);
            this.Close();
        }
    }
}
