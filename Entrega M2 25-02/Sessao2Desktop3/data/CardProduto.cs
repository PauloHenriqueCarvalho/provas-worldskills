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
    public partial class CardProduto : UserControl
    {
        public CardProduto(Produto p)
        {
            InitializeComponent();
            txtNome.Text = p.Nome;
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject(p.Id.ToString());
            produto = p;
        }

        public Produto produto { get; set; }

        private void CardProduto_Load(object sender, EventArgs e)
        {

        }
    }
}
