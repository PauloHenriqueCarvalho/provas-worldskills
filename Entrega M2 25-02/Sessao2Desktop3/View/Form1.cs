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
using Sessao2Desktop3.View;

namespace Sessao2Desktop3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Theme.Apply(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new PadraoDAO().Login(textBox1.Text, textBox2.Text);
            if (u != null)
            {
                MessageBox.Show("Bem Vindo!");
                Global.user = u;
                if (u.cliente)
                {
                    //Cliente
                    this.Hide();
                    new TelaSolicitacao().Show();
                }
                else
                {
                    //Fornecedor
                    new ProdutosView().Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Usuario ou senha incorreto!");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new CadastroUsuarioView().Show();
            this.Hide();
        }
    }
}
