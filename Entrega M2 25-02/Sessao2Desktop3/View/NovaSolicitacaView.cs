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
using static Sessao2Desktop3.View.DetalhesSolicitacaoView;

namespace Sessao2Desktop3.View
{
    public partial class NovaSolicitacaView : Form
    {
        List<Produto> listaProduto = new List<Produto>();
        List<Produto> listaProdutoSelecionado = new List<Produto>();
        bool cashativo = false;
        public NovaSolicitacaView()
        {
            InitializeComponent();
            Theme.Apply(this);
            listaProduto = new PadraoDAO().GetProdutos();
            Carregar(listaProduto);

            var dic = new PadraoDAO().GetFornecedor();

            comboBox1.DataSource = new BindingSource(dic, null);
            comboBox1.ValueMember = "Key";
            comboBox1.DisplayMember = "Value";


            flowLayoutPanel2.DragEnter += FlowLayoutPanel2_DragEnter;
            flowLayoutPanel2.DragDrop += FlowLayoutPanel2_DragDrop;

        }

        private void FlowLayoutPanel2_DragDrop(object sender, DragEventArgs e)
        {
            var card = (CardProduto)e.Data.GetData(typeof(CardProduto));
            new ModalEstoque(this, card).Show();
        }


        public void AdicionarProduto(Produto p)
        {
            listaProduto.Remove(p);
            listaProdutoSelecionado.Add(p);

            Carregar(listaProduto);
            CarregarSelecionados(listaProdutoSelecionado);
            Detalhes();
        }
        public void EditarProduto(Produto p)
        {
            listaProdutoSelecionado.Add(p);
            listaProdutoSelecionado.FirstOrDefault(x => x.Id == p.Id).Quantidade = p.Quantidade;

            Detalhes();
        }

        private void Detalhes()
        {
            var valorCash = new PadraoDAO().GetCashback();
            int qtd = 0;
            var valor = 0.00;
            foreach (var item in listaProdutoSelecionado)
            {
                valor += item.Quantidade * item.Valor;
                qtd += item.Quantidade;
            }
            if (!cashativo)
            {
                txtCashvack.Text = "0";

            }
            else
            {
                valor = valor - valorCash;
                if (valor < 0)
                    valor = 0;
                txtCashvack.Text = valorCash.ToString("F2");
            }

            txtQtd.Text = qtd.ToString();
            txtValor.Text = valor.ToString("F2");
        }


        private void FlowLayoutPanel2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CardProduto)))
                e.Effect = DragDropEffects.Move;
        }

        private void Carregar(List<Produto> p)
        {
            flowLayoutPanel1.Controls.Clear();

            var l = p.Where(x => x.Validade > DateTime.Now);

            foreach (var x in l)
            {
                var c = new CardProduto(x);
                c.MouseDown += (o, e) =>
                {
                    DoDragDrop(o as CardProduto, DragDropEffects.Move);
                };
                flowLayoutPanel1.Controls.Add(c);
            }
        }

        private void CarregarSelecionados(List<Produto> p)
        {
            flowLayoutPanel2.Controls.Clear();


            foreach (var x in p)
            {
                var c = new CardProduto(x);
                ContextMenuStrip menu = new ContextMenuStrip();
                c.ContextMenuStrip = menu;
                menu.Items.Add("Editar", null, EditarClick);
                menu.Items.Add("Excluir", null, ExcluirClick);

                c.MouseClick += (s, e) =>
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        menu.Show(e.Location);

                    }
                };

                flowLayoutPanel2.Controls.Add(c);
            }
        }

        private void ExcluirClick(object sender, EventArgs e)
        {
            var mi = sender as ToolStripItem;
            var menu = mi.Owner as ContextMenuStrip;
            var c = menu.SourceControl as CardProduto;

            listaProduto.Add(c.produto);
            listaProdutoSelecionado.Remove(c.produto);
            Carregar(listaProduto);
            CarregarSelecionados(listaProdutoSelecionado);
            Detalhes();
        }

        private void EditarClick(object sender, EventArgs e)
        {
            var mi = sender as ToolStripItem;
            var menu = mi.Owner as ContextMenuStrip;
            var c = menu.SourceControl as CardProduto;

            new ModalEstoque(this, c).Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 15 || textBox1.Text.Length > 50)
            {
                MessageBox.Show("A descrição deve ter no mínimo 15 caracteres e no máximo 50");
                return;
            }
            if (dateTimePicker1.Value < DateTime.Now.AddDays(15))
            {
                MessageBox.Show("A data de validade da solicitação deve, obrigatoriamente, ser uma data futura, com no mínimo 15 dias de diferença da data atual.");
                return;
            }

            if (listaProdutoSelecionado.Count == 0)
            {
                MessageBox.Show("Selecione pelo menos 1 produto!");
                return;
            }

            var s = new CardSolicitacaoDTO();
            s.Vencimento = dateTimePicker1.Value;
            s.Descricao = textBox1.Text;
            var id = new PadraoDAO().CadastroSolicitacao(s);

            foreach (var item in listaProdutoSelecionado)
            {
                new PadraoDAO().CadastroProdutoSolicitacao(item, id);
                new PadraoDAO().AtualizarEstoque(item.Id, (item.Estoque - item.Quantidade));

            }

            var valor = 0.00;
            foreach (var item in listaProdutoSelecionado)
            {
                valor += item.Quantidade * item.Valor;
            }

            List<CardSolicitacaoDTO> solicitacoes = new PadraoDAO().ListaSolicitacoesUsuario();
            foreach (var item in solicitacoes)
            {
                new PadraoDAO().DeleteCashback(item.Id);
            }

            new PadraoDAO().CadastroCashback(valor / 100, id);
            MessageBox.Show("Cadastrado com sucesso!");
            new TelaSolicitacao().Show();
            this.Close();


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NovaSolicitacaView_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var l = listaProduto.Where(x => x.Nome.Contains(textBox2.Text)).ToList();
            Carregar(l);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var l = listaProduto.Where(x => x.Tipoid == 3).ToList();
            Carregar(l);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var l = listaProduto.Where(x => x.Tipoid == 1).ToList();
            Carregar(l);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            var l = listaProduto.Where(x => x.Tipoid == 2).ToList();
            Carregar(l);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                cashativo = true;

            }
            else
            {
                cashativo = false;
            }
            Detalhes();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex <= 0)
            {
                Carregar(listaProduto);
                return;
            }

            var l = listaProduto.Where(x => x.FornecedorId == (int)comboBox1.SelectedValue).ToList();
            Carregar(l);

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<DetalhesDTO> detalhes = new List<DetalhesDTO>();
            foreach (var i in listaProdutoSelecionado)
            {
                detalhes.Add(new DetalhesDTO
                {
                    desconto = 0,
                    nome = i.Nome,
                    Preco = i.Valor,
                    Quantidade = i.Quantidade,
                    Validade = i.Validade,
                    Fornecedor = i.Fornecedor,
                    subtotal = i.Valor * i.Quantidade,
                });
            }
            new DetalhesSolicitacaoView(detalhes).Show();

        }
    }
}
