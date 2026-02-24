using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sessao2Desktop2.Model;

namespace Sessao2Desktop2.Data
{
    public partial class CardSolicitacao : UserControl
    {
        public CardSolicitacao(CardSolicitacaoDTO dto)
        {
            InitializeComponent();
            txtNome.Text = dto.NomeTipo;
            txtDes.Text = (dto.Descricao.Length > 20) ? dto.Descricao.Substring(0, 20) + "..."
            : dto.Descricao;
            txtdata.Text = dto.Data.ToString();

            if (dto.Data.Date < DateTime.Now)
            {
                txtStatus.Text = "Vencido";
                txtStatus.ForeColor = Color.Red;
            }
            else if (dto.Data.Date.AddDays(7) < DateTime.Now)
            {
                txtStatus.Text = "Vencendo";
                txtStatus.ForeColor = Color.Yellow;
            }
            else
            {
                txtStatus.Text = "Valida";
                txtStatus.ForeColor = Color.Green;
            }

            var valor = 0.0;
            foreach (var item in dto.Produtos)
            {
                valor += item.Valor * item.Quantidade;
            }
            txtPreco.Text = "R$ " + valor.ToString();

            var id = new PadraoDAO().TipoDaSolicitacao(dto.Id);
            if (id == 1)
            {
                pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject("higiene");
            }
            else if (id == 2)
            {

                pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject("equipamento");
            }
            else
            {
                pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject("medicamento");

            }

        }

        private void CardSolicitacao_Load(object sender, EventArgs e)
        {

        }
    }
}
