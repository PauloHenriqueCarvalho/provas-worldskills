using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sessao2Desktop3.Model;

namespace Sessao2Desktop3.data
{
    public partial class CardSolicitacao : UserControl
    {
        public CardSolicitacaoDTO solicitacaoDTO { get; set; }
        public CardSolicitacao(CardSolicitacaoDTO dto)
        {
            InitializeComponent();
            solicitacaoDTO = dto;
            switch (dto.tipoId)
            {
                case 1:
                    txtNome.Text = "Higiene";
                    pictureBox1.Image = Properties.Resources.higiene;
                    break;
                case 2:
                    txtNome.Text = "Equipamento";
                    pictureBox1.Image = Properties.Resources.equipamento;
                    break;
                case 3:
                    txtNome.Text = "Medicamento";
                    pictureBox1.Image = Properties.Resources.medicamento;
                    break;
            }

            txtDes.Text = (dto.Descricao.Length > 20) ? dto.Descricao.Substring(2) + "..."
                : dto.Descricao;

            double valor = 0.00;
            foreach (var i in dto.Produtos)
            {
                valor += i.Quantidade * i.Valor;
            }

            txtValor.Text = valor.ToString("F2");
            txtData.Text = dto.Vencimento.ToString();


            if (dto.Vencimento < DateTime.Now)
            {
                txtStatus.Text = "Vencido";
                txtStatus.ForeColor = Color.Red;
            }
            else if (dto.Vencimento < DateTime.Now.AddDays(7))
            {
                txtStatus.Text = "Vencendo";
                txtStatus.ForeColor = Color.Yellow;
            }
            else
            {
                txtStatus.Text = "Valida";
                txtStatus.ForeColor = Color.Green;
            }





        }

        private void CardSolicitacao_Load(object sender, EventArgs e)
        {

        }
    }
}
