using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sessao2._1302.Data
{
    public partial class CardSolicitacao : UserControl
    {

        public SolicitacaoDTO s;
        string status = "";

        public EventHandler editar;
        public EventHandler detalhes;
        public EventHandler excluir;


        public CardSolicitacao(SolicitacaoDTO teste)
        {
            InitializeComponent();
            s = teste;

            txtData.Text = s.Data.ToString();
            var desc = teste.Descricao.Length > 20
                ? teste.Descricao.Substring(0, 20) + "..."
                : teste.Descricao;
            txtDes.Text = desc;
            txtTipo.Text = s.TipoNome;

            var dias = (teste.Data.Date - DateTime.Now).Days;

            if (dias <= 0)
            {
                status = "Vencido";
                txtStatus.ForeColor = Color.Red;
            }
            else if (dias <= 7)
            {
                txtStatus.ForeColor = Color.Yellow;
                status = "Vencendo";
            }
            else
            {
                txtStatus.ForeColor = Color.Green;
                status = "Valido";
            }

            switch (teste.Tipo)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.higiene;
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources.medicamento;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources.equipamento;
                    break;
            }

            txtStatus.Text = status;


            var valor = 0.00;
            foreach (var i in s.listaProduto)
            {
                valor += i.valorProduto * i.quantidade;
            }
            txtValor.Text = valor.ToString();

        }

        private void CardSolicitacao_MouseUp(object sender, MouseEventArgs e)
        {

            menu.Items.Clear();

            if (status.Equals("Vencido"))
            {
                menu.Items.Add("Ver Detalhes", null, Detalhesclick);

            }
            else
            {
                menu.Items.Add("Excluir", null, Excluirclick);
                menu.Items.Add("Editar", null, EditarClick);
            }

            menu.Show(this, e.Location);
        }

        private void Excluirclick(object sender, EventArgs e)
        {
            excluir.Invoke(this, EventArgs.Empty);
        }

        private void Detalhesclick(object sender, EventArgs e)
        {
            detalhes.Invoke(this, EventArgs.Empty);
        }

        private void EditarClick(object sender, EventArgs e)
        {
            editar.Invoke(this, EventArgs.Empty);
        }

        private void CardSolicitacao_Load(object sender, EventArgs e)
        {

        }
    }
}
