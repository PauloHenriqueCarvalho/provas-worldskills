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
    public partial class DetalhesSolicitacaoView : Form
    {

        public class DetalhesDTO
        {
            public string nome { get; set; }
            public DateTime Validade { get; set; }
            public int Quantidade { get; set; }
            public double Preco { get; set; }
            public int desconto { get; set; }
            public string Fornecedor { get; set; }
            public double subtotal { get; set; }
        }
        public DetalhesSolicitacaoView(List<DetalhesDTO> lista)
        {
            InitializeComponent();
            Theme.Apply(this);
            dataGridView1.DataSource = lista;

        }

        private void DetalhesSolicitacaoView_Load(object sender, EventArgs e)
        {

        }
    }
}
