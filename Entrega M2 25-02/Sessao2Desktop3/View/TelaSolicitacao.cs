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
using Sessao2Desktop3.Model;

namespace Sessao2Desktop3.View
{
    public partial class TelaSolicitacao : Form
    {
        List<CardSolicitacaoDTO> lista = new List<CardSolicitacaoDTO>();
        public TelaSolicitacao()
        {
            InitializeComponent();
            lista = new PadraoDAO().ListaSolicitacoesUsuario();
            Carregar(lista);
            Theme.Apply(this);
        }


        private void Carregar(List<CardSolicitacaoDTO> l)
        {
            flowLayoutPanel1.Controls.Clear();

            l = l.Where(x => x.Produtos.Count > 0).ToList();

            foreach (var item in l)
            {
                var c = new CardSolicitacao(item);
                ContextMenuStrip menu = new ContextMenuStrip();
                c.ContextMenuStrip = menu;

                if (item.Vencimento < DateTime.Now)
                {
                    menu.Items.Add("Ver Detalhes", null, VerDetalhes);

                }
                else
                {
                    menu.Items.Add("Editar", null, EditarClick);
                    menu.Items.Add("Excluir", null, ExcluirClick);

                }


                c.MouseClick += (o, e) =>
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        menu.Show(e.Location);
                    }
                };

                flowLayoutPanel1.Controls.Add(c);
            }


        }

        private void VerDetalhes(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ExcluirClick(object sender, EventArgs e)
        {
            var mi = sender as ToolStripItem;
            var menu = mi.Owner as ContextMenuStrip;
            var c = menu.SourceControl as CardSolicitacao;

            new PadraoDAO().DeleteSolicitacao(c.solicitacaoDTO.Id);
            MessageBox.Show("Solicitacao deletada com sucesso!");
            lista = new PadraoDAO().ListaSolicitacoesUsuario();
            Carregar(lista);

        }

        private void EditarClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TelaSolicitacao_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var l = lista.Where(x => x.Produtos.Any(p => p.Nome.Contains(textBox1.Text))).ToList();
            Carregar(l);
        }

        public void Detalhes(int t)
        {
            var r = new List<CardSolicitacaoDTO>();
            switch (t)
            {
                case 1:
                    r = lista.OrderBy(x => x.DataCadastro).ToList();
                    break;
                case 2:
                    r = lista.OrderByDescending(x => x.DataCadastro).ToList();
                    break;
                case 3:
                    r = lista.OrderBy(x => x.Produtos.Count).ToList();
                    break;
                case 4:
                    r = lista.OrderByDescending(x => x.Produtos.Count).ToList();
                    break;
                case 5:
                    r = lista.OrderBy(x => x.Vencimento).ToList();
                    break;
                case 6:
                    r = lista.OrderByDescending(x => x.Vencimento).ToList();
                    break;
            }
            Carregar(r);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new DetalhesView(this).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new NovaSolicitacaView().Show();
        }
    }
}
