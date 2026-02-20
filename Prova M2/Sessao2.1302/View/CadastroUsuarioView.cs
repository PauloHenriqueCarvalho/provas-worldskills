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
using Sessao2._1302.Services;
using Sessao2.Data;

namespace Sessao2._1302.View
{
    public partial class CadastroUsuarioView : Form
    {
        public CadastroUsuarioView()
        {
            InitializeComponent();
            Theme.Apply(this);
        }

        private void CadastroUsuarioView_Load(object sender, EventArgs e)
        {

        }

        private void cbPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPerfil.SelectedIndex == 1)
            {
                txtrazaosocial.Visible = false;
                dateTimePicker1.Visible = true;
                label3.Text = "Data de nascimento";
                label4.Text = "CPF";
            }
            else
            {
                label3.Text = "Razão social";
                label4.Text = "CNPJ";
                txtrazaosocial.Visible = true;
                dateTimePicker1.Visible = false;

            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //se for cliente razao social nao pode ta vazio


            if (cbPerfil.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione algum perfil!");
                return;
            }
            if (cbPerfil.SelectedIndex == 0 && txtrazaosocial.Text.Trim().Equals(""))
            {
                MessageBox.Show("Nenhum campo pode estar vazio!");
                return;
            }



            //nenhum campo pode estar vazio
            if (txtNome.Text.Trim().Equals("")
                || txttelefone.Text.Trim().Equals("")
                || txtusuario.Text.Trim().Equals("")
                || txtsenha.Text.Trim().Equals("")
                || txtconfirmesenha.Text.Trim().Equals(""))
            {
                MessageBox.Show("Nenhum campo pode estar vazio!");
                return;
            }

            if (txtsenha.Text != txtconfirmesenha.Text)
            {
                MessageBox.Show("As senhas estão diferentes!");
                return;
            }
            //Se for fornecedro cnpj nao pode ser diferente que 14
            if (cbPerfil.SelectedIndex == 0 && txtCpf.Text.Length != 14)
            {
                MessageBox.Show("CNPJ incorreto!");
                return;
            }


            //se for for cliente e o aniversario de 18 for antes que hoje nao pode 
            if (cbPerfil.SelectedIndex == 1 && dateTimePicker1.Value.AddYears(18) > DateTime.Now)
            {
                MessageBox.Show("Cliente precissa ter mais que 18 anos!");
                return;
            }

            //se for cliente cpf tem que ter 11
            if (cbPerfil.SelectedIndex == 1 && txtCpf.Text.Length != 11)
            {
                MessageBox.Show("CPF incorreto!");
                return;
            }



            Usuarios u = new Usuarios();
            Pessoa p = new Pessoa();
            u.Login = txtusuario.Text;
            u.SenhaHash = txtconfirmesenha.Text;
            //Usuario

            p.nome = txtNome.Text;
            p.telefone = txttelefone.Text;
            p.Id = u.Id;
            //Pessoa
            int id = new PadraoDAO().CadastroPessoa(p);
            u.Id = id;
            new PadraoDAO().CadastroUsuario(u);

            if (cbPerfil.SelectedIndex == 1)
            {
                //Cliente
                Cliente c = new Cliente();
                c.DataNasciment = dateTimePicker1.Value;
                c.CPF = txtCpf.Text;
                c.ID = u.Id;

                new PadraoDAO().CadastroCliente(c);
            }
            else
            {
                //Fornecedor
                Fornecedor f = new Fornecedor();
                f.CNPJ = txtCpf.Text;
                f.RazaoSocial = txtrazaosocial.Text;
                f.Id = u.Id;
                new PadraoDAO().CadastroFornecedor(f);
            }
            MessageBox.Show("Cadastrado com sucesso!");
        }
    }
}
