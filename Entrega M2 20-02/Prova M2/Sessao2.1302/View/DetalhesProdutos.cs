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
using Sessao2.Data;

namespace Sessao2._1302.View
{
    public partial class DetalhesProdutos : Form
    {
        public DetalhesProdutos(List<DetalhesProdutosDTO> dto)
        {
            InitializeComponent();
            dataGridView1.DataSource = dto;
            Theme.Apply(this);
        }

        private void DetalhesProdutos_Load(object sender, EventArgs e)
        {

        }
    }
}
