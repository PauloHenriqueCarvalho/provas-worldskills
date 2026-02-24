using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sessao2._1302.Services;
using Sessao2.Data;

namespace Sessao2._1302.View
{
    public partial class ProdutoView : Form
    {
        private List<ProdutoDataDTO> lista = new List<ProdutoDataDTO>();
        private BindingSource bs = new BindingSource();
        public ProdutoView()
        {
            InitializeComponent();
            Theme.Apply(this);

            dataGridView1.CellFormatting += dataGridView1_CellFormatting;

            Carregar();
        }
        public void Carregar()
        {
            lista = new PadraoDAO().ListaProdutoFornecedor();

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("Tipo", typeof(string));
            dt.Columns.Add("DataValidade", typeof(DateTime));
            dt.Columns.Add("DataCadastro", typeof(DateTime));

            foreach (var p in lista)
            {
                dt.Rows.Add(p.Id, p.Nome, p.Tipo, p.DataValidade, p.DataCadastro);
            }

            dataGridView1.DataSource = dt;

            dataGridView1.Columns["Id"].Visible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }


        // 🔹 Destaque da validade
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "DataValidade")
            {
                if (e.Value == null) return;

                DateTime validade = Convert.ToDateTime(e.Value);

                if (validade.Date < DateTime.Now.Date)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else if (validade.Date <= DateTime.Now.Date.AddDays(7))
                {
                    e.CellStyle.ForeColor = Color.Goldenrod;
                }
            }
        }



        private void ProdutoView_Load(object sender, EventArgs e)
        {

        }

        public class ProdutoDataDTO
        {
            public string Nome { get; set; }
            public String Tipo { get; set; }
            public DateTime DataValidade { get; set; }
            public DateTime DataCadastro { get; set; }
            public int Id { get; set; }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto para editar.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);


            var produto = lista.FirstOrDefault(x => x.Id == id);

            if (produto == null)
                return;

            var form = new ProdutoCadastroView(produto);
            form.ShowDialog();

            Carregar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new ProdutoCadastroView(null);
            form.ShowDialog();

            Carregar();
        }
    }
}
