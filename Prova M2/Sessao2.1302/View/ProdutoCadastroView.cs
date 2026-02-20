using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sessao2._1302.Models;
using Sessao2._1302.Services;
using Sessao2.Data;
using static Sessao2._1302.View.ProdutoView;

namespace Sessao2._1302.View
{
    public partial class ProdutoCadastroView : Form
    {
        List<TipoProduto> listaTipos = new List<TipoProduto>();
        public ProdutoCadastroView(ProdutoDataDTO produto)
        {
            InitializeComponent();
            Theme.Apply(this);

            listaTipos = new PadraoDAO().GetTipoProduto();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Nome";
            comboBox1.DataSource = listaTipos;
        }

        private void ProdutoCadastroView_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ProdutoView().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Selecionar imagem";
                ofd.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (var imgTemp = Image.FromFile(ofd.FileName))
                    {
                        pictureBox1.Image = new Bitmap(imgTemp);
                    }

                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
      string.IsNullOrWhiteSpace(txtDesc.Text))
            {
                MessageBox.Show("Dados inválidos!");
                return;
            }

            if (dateTimePicker1.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("A validade não pode ser menor que hoje!");
                return;
            }
            List<ProdutoDataDTO> lista = new PadraoDAO().ListaProdutoFornecedor();

            if (lista.Any(x =>
    x.Nome.Equals(txtNome.Text, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Já existe um produto com esse nome para esse fornecedor!");
                return;
            }

            if (numValor.Value <= 0)
            {
                MessageBox.Show("O valor deve ser maior que 0");
                return;
            }
            if (txtDesc.Text.Length < 20 || txtDesc.Text.Length > 50)
            {
                MessageBox.Show("Descricao precisa conter entre 20 e 50 caracteres!");
                return;
            }
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o tipo do produto!");
                return;
            }

        }
    }
}
