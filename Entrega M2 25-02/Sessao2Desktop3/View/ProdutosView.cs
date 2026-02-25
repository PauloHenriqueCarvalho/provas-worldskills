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
using Sessao2Desktop3.Model;

namespace Sessao2Desktop3.View
{
    public partial class ProdutosView : Form
    {
        public class ProdutoDTO
        {
            public string nome { get; set; }
            public string Tipo { get; set; }
            public DateTime Validade { get; set; }
            public DateTime DataCadastro { get; set; }

        }
        public ProdutosView()
        {
            InitializeComponent();
            Theme.Apply(this);
            List<Produto> lista = new PadraoDAO().GetProdutosfornecedor();

            List<ProdutoDTO> listDto = new List<ProdutoDTO>();
            foreach (Produto produto in lista)
            {
                listDto.Add(new ProdutoDTO
                {
                    Validade = produto.Validade,
                    Tipo = produto.Tipo,
                    DataCadastro = produto.Cadastro,
                    nome = produto.Nome
                });
            }


            dataGridView1.DataSource = listDto;
        }

        private void ProdutosView_Load(object sender, EventArgs e)
        {

        }
    }
}
