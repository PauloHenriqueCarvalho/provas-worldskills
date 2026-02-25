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
    public partial class CadastroUsuarioView : Form
    {
        bool cliente = false;
        public CadastroUsuarioView()
        {
            InitializeComponent();
            Theme.Apply(this);
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0 && comboBox1.SelectedIndex != 1)
                return;
            if (comboBox1.SelectedIndex == 0)
            {
                //Fornecedor
                lblRazao.Text = "Razao social";
                txtRazao.Visible = true;
                dateTimePicker1.Visible = false;
                cliente = false;
            }
            else
            {
                //Cliente
                cliente = true;
                lblRazao.Text = "Data de nascimento";
                txtRazao.Visible = false;
                dateTimePicker1.Visible = true;
            }



        }

        private void CadastroUsuarioView_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idade = DateTime.Now.Year - dateTimePicker1.Value.Date.Year;
            if (cliente)
            {
                if (txtCnpj.Text.Length != 11)
                {
                    MessageBox.Show("CPF Incorreto!");
                    return;
                }
                if (idade < 18)
                {
                    MessageBox.Show("Usuario precisa ter pelo menos 18 anos!");
                    return;
                }
            }
            else
            {
                if (txtCnpj.Text.Length != 14)
                {
                    MessageBox.Show("CNPJ Incorreto!");
                    return;
                }

                if (txtRazao.Text.Equals(""))
                {
                    MessageBox.Show("Todos campos precisam estar preenchidos!");
                    return;
                }

            }

            if (txtNome.Text.Trim().Equals("") || txtConfirme.Text.Trim().Equals("")
                || txtSenha.Text.Trim().Equals("") || txtTel.Text.Trim().Equals("") || txtUsuario.Text.Trim().Equals("")
                )
            {
                MessageBox.Show("Todos campos precisam estar preenchidos!");
            }
            if (txtSenha.Text != txtConfirme.Text)
            {
                MessageBox.Show("As senhas são diferentes!");
                return;
            }

            //Pessoa
            try
            {
                int id = new PadraoDAO().CadastroPessoa(txtNome.Text, txtTel.Text);

                new PadraoDAO().CadastroUsuario(txtUsuario.Text, id, txtSenha.Text);
                if (cliente)
                    new PadraoDAO().CadastroCliente(txtCnpj.Text, id, dateTimePicker1.Value);
                else
                    new PadraoDAO().CadastroFornecedor(txtRazao.Text, id, txtCnpj.Text);

                MessageBox.Show("Usuario cadastrado com sucesso!");
                this.Close();
                new Form1().Show();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ja existe um usuario com esse nome!");

            }

        }
    }
}
