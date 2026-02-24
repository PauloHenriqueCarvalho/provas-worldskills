using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sessao2._1302.Data;
using Sessao2._1302.Models;
using Sessao2.Data;

namespace Sessao2._1302.View
{
    public partial class ModalEstoque : Form
    {
        NovaSolicitacaoView _v;
        CardProduto _card;
        public ModalEstoque(NovaSolicitacaoView v, CardProduto card)
        {
            InitializeComponent();
            Theme.Apply(this);
            _v = v;
            _card = card;
        }


        private void ModelEstoque_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value <= 0)
            {
                _v.QuantidadeItens(int.Parse(numericUpDown1.Value.ToString()), _card, false);
                return;
            }
            if (numericUpDown1.Value > _card.produto.Estoque)
            {
                _v.QuantidadeItens(int.Parse(numericUpDown1.Value.ToString()), _card, false);
                this.Close();
                return;
            }

            _v.QuantidadeItens(int.Parse(numericUpDown1.Value.ToString()), _card, true);
            this.Close();
        }
    }
}
