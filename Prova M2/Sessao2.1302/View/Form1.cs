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
using Sessao2._1302.Services;
using Sessao2._1302.View;
using Sessao2.Data;

namespace Sessao2._1302
{
    public partial class Form1 : Form
    {
        List<SolicitacaoDTO> listaSolicitacao = new List<SolicitacaoDTO>();

        public Form1()
        {
            InitializeComponent();
            Theme.Apply(this);
            Global.user = new PadraoDAO().Login("agnercamargo@email.com", "4522398");
            listaSolicitacao = new PadraoDAO().SolicitacaoClienteLogado();
            Carregar(listaSolicitacao);
        }



        private void Carregar(List<SolicitacaoDTO> lista)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var i in lista)
            {
                var p = new CardSolicitacao(i);
                p.editar += ClickEditar;
                p.excluir += ClickExcluir;
                p.detalhes += ClickDetalhes;
                flowLayoutPanel1.Controls.Add(p);

            }
        }

        private void ClickDetalhes(object sender, EventArgs e)
        {
        }

        private void ClickExcluir(object sender, EventArgs e)
        {
            var card = (CardSolicitacao)sender;
            var s = card.s;
            new PadraoDAO().ExcluirProdutoSolicitacao(s.Id);
            new PadraoDAO().ExcluirCashbackSolicitacao(s.Id);
            new PadraoDAO().ExcluirSolicitacao(s.Id);
            MessageBox.Show("Solicitacao excluida com sucesso!");
            Carregar(new PadraoDAO().SolicitacaoClienteLogado());
        }

        private void ClickEditar(object sender, EventArgs e)
        {
            var card = (CardSolicitacao)sender;
            var s = card.s;
            new NovaSolicitacaoView(s).Show();
            this.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void Ordenacao(int num)
        {
            List<SolicitacaoDTO> filtro = new PadraoDAO().SolicitacaoClienteLogado();

            foreach (var item in filtro)
            {
                item.diasPraVencer = (item.Data - DateTime.Now).Days;
            }
            switch (num)
            {
                case 1:
                    filtro = filtro.OrderByDescending(x => x.Data).ToList();
                    break;
                case 2:
                    filtro = filtro.OrderBy(x => x.Data).ToList();
                    break;
                case 3:
                    filtro = filtro.OrderBy(x => x.listaProduto.Count).ToList();
                    break;
                case 4:
                    filtro = filtro.OrderByDescending(x => x.listaProduto.Count).ToList();
                    break;
                case 5:
                    filtro = filtro.OrderByDescending(x => x.diasPraVencer).ToList();
                    break;
                case 6:
                    filtro = filtro.OrderBy(x => x.diasPraVencer).ToList();
                    break;

            }
            Carregar(filtro);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var filtro = listaSolicitacao.Where(x => x.listaProduto.Any(p => p.nome.Contains(textBox1.Text)));
            flowLayoutPanel1.Controls.Clear();

            foreach (var i in filtro)
            {
                var p = new CardSolicitacao(i);
                p.editar += ClickEditar;
                p.excluir += ClickExcluir;
                p.detalhes += ClickDetalhes;
                flowLayoutPanel1.Controls.Add(p);

            }


        }

        private void label3_Click(object sender, EventArgs e)
        {
            new OrdenarView(this).ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new NovaSolicitacaoView(null).Show();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new CadastroUsuarioView().Show();
        }
    }
}
