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
    public partial class ModalEstoque : Form
    {
        NovaSolicitacao _n;
        CardProduto _p;
        bool editar = false;
        public ModalEstoque(NovaSolicitacao n, CardProduto p)
        {
            InitializeComponent();
            _n = n;
            _p = p;
            Theme.Apply(this);
            var pr = p.GetProduto();
            if (pr.Quantidade != 0)
            {
                numericUpDown1.Value = pr.Quantidade;
                pr.Estoque -= pr.Quantidade;
                editar = true;
            }
        }

        private void ModalEstoque_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Quantidade invalida");
                return;
            }

            var p = _p.GetProduto();
            if (p.Estoque < numericUpDown1.Value)
            {
                MessageBox.Show("Sem estoque para essa quantidade!");
                return;
            }
            if (editar)
            {
                _n.EditarProduto(p, (int)numericUpDown1.Value);
                this.Close();
                return;

            }
            _n.AdicionarProduto(p, (int)numericUpDown1.Value);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
