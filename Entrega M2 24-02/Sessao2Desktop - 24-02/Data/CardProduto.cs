using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sessao2Desktop2.Model;

namespace Sessao2Desktop2.Data
{
    public partial class CardProduto : UserControl
    {
        Produtos _p;
        public CardProduto(Produtos p)
        {
            InitializeComponent();
            txtNome.Text = p.Nome;
            _p = p;
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject(p.Id.ToString());
        }
        public Produtos GetProduto()
        {
            return _p;
        }
        private void CardProduto_Load(object sender, EventArgs e)
        {

        }
    }
}
