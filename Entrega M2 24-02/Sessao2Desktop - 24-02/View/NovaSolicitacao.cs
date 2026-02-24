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
using static Sessao2Desktop2.Data.PadraoDAO;

namespace Sessao2Desktop2.View
{
    public partial class NovaSolicitacao : Form
    {
        List<Produtos> listaProdutos = new List<Produtos>();
        List<Produtos> listaProdutosSelecionados = new List<Produtos>();

        public NovaSolicitacao()
        {
            InitializeComponent();
            Theme.Apply(this);
            listaProdutos = new PadraoDAO().TodosProdutos();
            Dictionary<int, string> dicforne = new PadraoDAO().Fornecedores();
            comboBox1.DataSource = new BindingSource(dicforne, null);
            comboBox1.ValueMember = "Key";
            comboBox1.DisplayMember = "Value";
            flowLayoutPanel2.AllowDrop = true;
            flowLayoutPanel2.DragEnter += FlowLayoutPanel2_DragEnter;
            flowLayoutPanel2.DragDrop += FlowLayoutPanel2_DragDrop;
            CarregarProduto(listaProdutos);
        }

        public void CarregarProduto(List<Produtos> lista)
        {
            flowLayoutPanel1.Controls.Clear();



            foreach (Produtos produto in lista)
            {
                if (produto.Validade > DateTime.Now)
                {
                    var c = new CardProduto(produto);
                    c.MouseDown += (s, e) =>
                    {

                        DoDragDrop(s as CardProduto, DragDropEffects.Move);
                    };
                    flowLayoutPanel1.Controls.Add(c);

                }
            }

        }
        private void FlowLayoutPanel2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CardProduto)))
                e.Effect = DragDropEffects.Move;
        }

        private void FlowLayoutPanel2_DragDrop(object sender, DragEventArgs e)
        {
            var card = (CardProduto)e.Data.GetData(typeof(CardProduto));
            new ModalEstoque(this, card).Show();
        }
        public void CarregarProdutoSelecionado(List<Produtos> lista)
        {
            flowLayoutPanel2.Controls.Clear();

            foreach (Produtos produto in lista)
            {
                if (produto.Validade > DateTime.Now)
                {
                    var c = new CardProduto(produto);
                    ContextMenuStrip menu = new ContextMenuStrip();
                    c.ContextMenuStrip = menu;

                    menu.Items.Add("Editar", null, EditarClick);
                    menu.Items.Add("Excluir", null, ExcluirClick);

                    c.MouseClick += (e, s) =>
                    {
                        if (s.Button == MouseButtons.Right)
                        {
                            menu.Show(s.Location);
                        }

                    };
                    flowLayoutPanel2.Controls.Add(c);
                }
            }

        }

        private void ExcluirClick(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripItem;
            var menu = menuItem.Owner as ContextMenuStrip;
            var c = menu.SourceControl as CardProduto;
            listaProdutos.Add(c.GetProduto());
            listaProdutosSelecionados.Remove(c.GetProduto());
            CarregarProdutoSelecionado(listaProdutosSelecionados);
            CarregarProduto(listaProdutos);
            Detalhes(0);
            checkBox1.Checked = false;
        }

        private void EditarClick(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripItem;
            var menu = menuItem.Owner as ContextMenuStrip;
            var card = menu.SourceControl as CardProduto;
            new ModalEstoque(this, card).Show();

        }
        public void EditarProduto(Produtos p, int quantidade)
        {
            var pr = listaProdutosSelecionados
                        .FirstOrDefault(x => x.Id == p.Id); pr.Quantidade = quantidade;
            CarregarProdutoSelecionado(listaProdutosSelecionados);
            Detalhes(0);
            checkBox1.Checked = false;
        }
        public void AdicionarProduto(Produtos p, int quantidade)
        {
            p.Quantidade = quantidade;
            listaProdutosSelecionados.Add(p);
            listaProdutos.Remove(p);
            CarregarProduto(listaProdutos);
            CarregarProdutoSelecionado(listaProdutosSelecionados);
            Detalhes(0);
            checkBox1.Checked = false;
        }


        private void NovaSolicitacao_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var l = listaProdutos.Where(x => x.Nome.Contains(textBox2.Text)).ToList();
            CarregarProduto(l);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var l = listaProdutos.Where(x => x.TipoId == 3).ToList();
            CarregarProduto(l);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var l = listaProdutos.Where(x => x.TipoId == 1).ToList();
            CarregarProduto(l);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var l = listaProdutos.Where(x => x.TipoId == 2).ToList();
            CarregarProduto(l);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex <= 0)
            {
                CarregarProduto(listaProdutos);
                return;

            }
            var l = listaProdutos.Where(x => x.FornecedorId == (int)comboBox1.SelectedValue).ToList();
            CarregarProduto(l);
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Detalhes(double cash)
        {
            double valor = 0.0;
            int qtd = 0;
            foreach (var item in listaProdutosSelecionados)
            {
                valor += item.Quantidade * item.Valor;
                qtd += item.Quantidade;
            }
            valor = valor - cash;
            txtValor.Text = valor.ToString("F2");
            txtCash.Text = cash.ToString("F2"); ;

            txtQuantidae.Text = qtd.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                var valor = new Cashback().GetCashback();
                Detalhes(valor);
            }
            else
            {
                Detalhes(0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Descricao tem que ter pelo menos 15 caracteres!");
                return;
            }

            if (dateTimePicker1.Value < DateTime.Now.AddDays(15))
            {
                MessageBox.Show("Data de validade deve ser no minimo 15 dias de diferença da data atual!");
                return;
            }

            var s = new Solicitacao();
            s.Descricao = textBox1.Text;
            s.Validade = dateTimePicker1.Value;
            int id = new PadraoDAO().AdicionarSolicitacao(s);

            double valor = 0.0;
            int qtd = 0;
            foreach (var item in listaProdutosSelecionados)
            {
                valor += item.Quantidade * item.Valor;
                qtd += item.Quantidade;
            }

            foreach (var item in listaProdutosSelecionados)
            {
                new PadraoDAO().CadastrarProdutoSolicitacao(new ProdutoSolicitacao
                {
                    SolicitacaoId = id,
                    produtoID = item.Id,
                    Quantidade = item.Quantidade,
                });
            }
            new Cashback().AdicionarCashback(id, (valor / 100));
            MessageBox.Show("Solicitacao Cadastrada!");
            this.Close();
            new SolicitacoesView().Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new SolicitacoesView().Show();
        }
    }
}
