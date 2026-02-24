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

namespace Sessao2Desktop2.View
{
    public partial class SolicitacoesView : Form
    {
        List<CardSolicitacaoDTO> lista = new List<CardSolicitacaoDTO>();
        public SolicitacoesView()
        {
            InitializeComponent();
            Theme.Apply(this);
            lista = new PadraoDAO().SolicitacaoCliente(Global.user.Id);
            Carregar(lista);
        }

        public void Carregar(List<CardSolicitacaoDTO> l)
        {

            flowLayoutPanel1.Controls.Clear();

            foreach (var item in l)
            {
                if (item.Produtos.Count > 0)
                {
                    var c = new CardSolicitacao(item);
                    ContextMenuStrip menu = new ContextMenuStrip();
                    c.ContextMenuStrip = menu;

                    if (item.Data.Date < DateTime.Now)
                    {
                        item.Status = "Vencido";
                    }
                    else if (item.Data.Date.AddDays(7) < DateTime.Now)
                    {
                        item.Status = "Vencendo";

                    }
                    else
                    {
                        item.Status = "Valida";

                    }
                    if (item.Status == "Vencido")
                    {

                        menu.Items.Add("Ver Detalhes", null, VerDetalhes);
                    }
                    else
                    {
                        menu.Items.Add("Editar", null, EditarClick);
                        menu.Items.Add("Excluir", null, ExcluirClick);

                    }


                    c.MouseClick += (e, s) =>
                    {
                        if (s.Button == MouseButtons.Right)
                        {
                            menu.Show(s.Location);

                        }

                    };
                    flowLayoutPanel1.Controls.Add(c);
                }

            }

        }

        private void VerDetalhes(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ExcluirClick(object sender, EventArgs e)
        {
            //Excluir

        }

        private void EditarClick(object sender, EventArgs e)
        {
            //Editar
        }

        private void SolicitacoesView_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var list = lista.Where(x => x.Produtos.Any(p => p.Nome.Contains(textBox1.Text))).ToList();
            Carregar(list);
        }
        public void Detalhes(int id)
        {
            var r = new List<CardSolicitacaoDTO>();
            switch (id)
            {
                case 0:
                    // Mais Antiga
                    r = lista.OrderByDescending(x => x.DataCricao).ToList();
                    break;
                case 1:
                    // Menos Antiga
                    r = lista.OrderBy(x => x.DataCricao).ToList();
                    break;
                case 2:
                    // Mais Produtos
                    r = lista.OrderBy(x => x.Produtos.Count).ToList();
                    break;
                case 3:
                    // menos produtos
                    r = lista.OrderByDescending(x => x.Produtos.Count).ToList();
                    break;
                case 4:
                    // Mais proxima do vencimento
                    r = lista.OrderBy(x => x.Data).ToList();
                    break;
                case 5:
                    // mais distante do vencimento
                    r = lista.OrderByDescending(x => x.Data).ToList();
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
            new NovaSolicitacao().Show();
        }
    }
}
