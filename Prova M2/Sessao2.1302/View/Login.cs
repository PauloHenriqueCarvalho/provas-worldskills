using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sessao2._1302.Data;
using Sessao2._1302.Models;
using Sessao2._1302.Services;
using Sessao2.Data;

namespace Sessao2._1302.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Theme.Apply(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ProdutoView().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new CadastroUsuarioView().Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            var u = (Usuarios)new PadraoDAO().Login(textBox1.Text, textBox2.Text);
            if (u != null)
            {
                MessageBox.Show("Bem Vindo!");
                Global.user = u;
                if (u.Id < 16)
                {
                    new ProdutoView().Show();
                    this.Hide();
                }
                else
                {
                    new Form1().Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Usuario ou senha invalido!");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new CadastroUsuarioView().Show();
        }
    }
}
