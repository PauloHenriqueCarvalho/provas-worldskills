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
    public partial class ModalEstoque : Form
    {
        NovaSolicitacaView s;
        CardProduto c;
        public ModalEstoque(NovaSolicitacaView v, CardProduto p)
        {
            InitializeComponent();
            Theme.Apply(this);
            s = v;
            c = p;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var valor = numericUpDown1.Value;
            if (valor <= 0)
            {
                MessageBox.Show("Quantidade Invalida!");
                return;
            }
            if (valor > c.produto.Estoque)
            {
                MessageBox.Show("Quantidade acima do estoque!");
                return;
            }

            if (c.produto.Quantidade != 0)
            {
                c.produto.Estoque -= c.produto.Quantidade;
                if (valor > c.produto.Estoque)
                {
                    MessageBox.Show("Quantidade acima do estoque!");
                    return;
                }

                c.produto.Quantidade = int.Parse(valor.ToString());
                s.EditarProduto(c.produto);
                this.Close();
                return;
            }

            c.produto.Quantidade = int.Parse(valor.ToString());
            s.AdicionarProduto(c.produto);
            this.Close();

        }
    }
}
