using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sessao2Desktop2.Data;
using Sessao2Desktop2.Model;
using Sessao2Desktop2.View;

namespace Sessao2Desktop2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Theme.Apply(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new PadraoDAO().Login(textBox1.Text, textBox2.Text);
            if (u.Id != 0)
            {
                MessageBox.Show("Bem vindo !");
                Global.user = u;
                if (u.cliente)
                {
                    //cliente
                    new SolicitacoesView().Show();
                    this.Hide();
                }
                else
                {
                    //Fornecedor
                }
            }
            else
            {
                MessageBox.Show("Usuario ou senha incorreto!");
            }
        }
    }
}
