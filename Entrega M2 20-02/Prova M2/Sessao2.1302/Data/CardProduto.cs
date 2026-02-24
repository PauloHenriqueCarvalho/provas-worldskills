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

namespace Sessao2._1302.Data
{
    public partial class CardProduto : UserControl
    {
        public Produto produto { get; set; }
        public CardProduto(Produto p)
        {
            InitializeComponent();
            txtNome.Text = p.nome;
            produto = p;
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject(p.Id.ToString());

        }

        private void CardProduto_Load(object sender, EventArgs e)
        {

        }
    }
}
