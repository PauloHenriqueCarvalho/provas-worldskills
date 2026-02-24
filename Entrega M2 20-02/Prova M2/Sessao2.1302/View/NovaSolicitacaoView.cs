using System;
using System.Collections;
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
    public partial class NovaSolicitacaoView : Form
    {
        SolicitacaoDTO solicitacao;
        List<Produto> listaProduto = new List<Produto>();
        List<Produto> listaProdutoAdicionados = new List<Produto>();
        List<Produto> listaProdutoAdicionadosEditar = new List<Produto>();
        List<Produto> listaAtual = new List<Produto>();
        double valor = 0.00;
        public NovaSolicitacaoView(SolicitacaoDTO _solicitacao)
        {
            InitializeComponent();
            Theme.Apply(this);
            listaProduto = new PadraoDAO().ListaProduto();
            listaAtual = listaProduto;
            Global.user.CashbackUsuario = new PadraoDAO().CashbackUsuario();
            cbFornecedor.DataSource = new PadraoDAO().NomesFornecedores();
            Carregar(listaProduto);

            if (_solicitacao != null)
            {
                label1.Text = "Editar Solicitação";
                solicitacao = _solicitacao;
                edtDes.Text = solicitacao.Descricao;
                dtValidade.Value = solicitacao.Data;
                CarregarListaAdicionada();
            }

        }

        private void CarregarListaAdicionada()
        {

            listaProdutoAdicionados = new PadraoDAO().ListaProdutoAdicionados(solicitacao.Id);
            flowLayoutPanel2.Controls.Clear();

            foreach (var produto in listaProdutoAdicionados)
            {
                var c = new CardProduto(produto);

                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Editar", null, EditarClick);
                menu.Items.Add("Excluir", null, ExcluirClick);

                c.ContextMenuStrip = menu;
                c.MouseClick += (s, e) =>
                {
                    menu.Show(this, e.Location);
                };
                c.MouseDown += CardClickDown;
                flowLayoutPanel2.Controls.Add(c);

            }
            Informacoes();
            Carregar(listaAtual);
        }

        private void Carregar(List<Produto> lista)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.AllowDrop = true;
            flowLayoutPanel2.DragEnter += Flow_DragEnter;
            flowLayoutPanel2.DragDrop += Flow_DragDrop;

            var newList = lista.Where(x => DateTime.Now < x.Validade && !listaProdutoAdicionados.Any(w => w.Id == x.Id)).ToList();



            foreach (var produto in newList)
            {


                var c = new CardProduto(produto);
                c.MouseDown += CardClickDown;
                flowLayoutPanel1.Controls.Add(c);


            }
        }

        public void QuantidadeItens(int qtd, CardProduto card, bool valido)
        {
            //Adicionar produtos
            if (!valido)
            {
                MessageBox.Show("Quantidade Invalida ou sem estoque!");
                return;
            }

            var destino = (FlowLayoutPanel)flowLayoutPanel2;
            if (card != null)
            {
                card.Parent.Controls.Remove(card);
                destino.Controls.Add(card);
            }
            card.produto.qtdAdicionada = qtd;
            listaProdutoAdicionados.Add(card.produto);
            if (solicitacao != null)
            {
                listaProdutoAdicionadosEditar.Add(card.produto);

            }
            flowLayoutPanel2.Controls.Clear();

            foreach (var produto in listaProdutoAdicionados)
            {
                var c = new CardProduto(produto);

                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Editar", null, EditarClick);
                menu.Items.Add("Excluir", null, ExcluirClick);

                c.ContextMenuStrip = menu;
                c.MouseClick += (s, e) =>
                {
                    menu.Show(this, e.Location);
                };
                c.MouseDown += CardClickDown;
                flowLayoutPanel2.Controls.Add(c);

            }
            Informacoes();

        }

        private void ExcluirClick(object sender, EventArgs e)
        {
            var t = (ToolStripMenuItem)sender;
            var p = (ContextMenuStrip)t.Owner;
            var c = (CardProduto)p.SourceControl;

            if (solicitacao != null)
            {
                new PadraoDAO().ExcluirProdutoSolicitacao(solicitacao.Id, c.produto.Id);
                listaProdutoAdicionados.Remove(c.produto);
                if (listaProdutoAdicionadosEditar.Contains(c.produto))
                    listaProdutoAdicionadosEditar.Remove(c.produto);
            }
            else
            {
                listaProdutoAdicionados.Remove(c.produto);
                if (listaProdutoAdicionadosEditar.Contains(c.produto))
                    listaProdutoAdicionadosEditar.Remove(c.produto);
            }
            flowLayoutPanel2.Controls.Clear();

            foreach (var produto in listaProdutoAdicionados)
            {
                var _c = new CardProduto(produto);

                ContextMenuStrip menu = new ContextMenuStrip();
                menu.Items.Add("Editar", null, EditarClick);
                menu.Items.Add("Excluir", null, ExcluirClick);

                c.ContextMenuStrip = menu;
                c.MouseClick += (s, _e) =>
                {
                    menu.Show(this, _e.Location);
                };
                c.MouseDown += CardClickDown;
                flowLayoutPanel2.Controls.Add(_c);

            }
            Informacoes();
            Carregar(listaAtual);
        }

        private void EditarClick(object sender, EventArgs e)
        {
        }

        private void CardClickDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var c = (Control)sender;

                if (c.Parent == flowLayoutPanel1)
                {
                    c.DoDragDrop(c, DragDropEffects.Move);
                }

            }
        }

        private void Flow_DragDrop(object sender, DragEventArgs e)
        {


            var card = (CardProduto)e.Data.GetData(typeof(CardProduto));
            new ModalEstoque(this, card).ShowDialog();

        }

        private void Flow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CardProduto)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }


        private void NovaSolicitacaoView_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pHigi_Click(object sender, EventArgs e)
        {
            var filtro = listaProduto.Where(x => x.Tipoid == 1).ToList();
            listaAtual = filtro;
            Carregar(filtro);
        }

        private void pMedi_Click(object sender, EventArgs e)
        {
            var filtro = listaProduto.Where(x => x.Tipoid == 3).ToList();
            listaAtual = filtro;
            Carregar(filtro);
        }

        private void pEqui_Click(object sender, EventArgs e)
        {
            var filtro = listaProduto.Where(x => x.Tipoid == 2).ToList();
            listaAtual = filtro;
            Carregar(filtro);
        }

        private void edtBusca_TextChanged(object sender, EventArgs e)
        {
            var filtro = listaAtual.Where(x => x.nome.Contains(edtBusca.Text)).ToList();
            Carregar(filtro);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (edtDes.Text.Length < 15 || edtDes.Text.Length >= 50)
            {
                MessageBox.Show("A descricao tem que ter no minimo 15 caracteres e no maximo 50");
                return;
            }

            if (dtValidade.Value.Date < DateTime.Now.AddDays(15))
            {
                MessageBox.Show("A data de validadae precisa ser pelo menos 15 dias de diferença da data atual!");
                return;
            }

            Solicitacao s = new Solicitacao();
            s.Descricao = edtDes.Text;
            s.Validade = dtValidade.Value;
            //Editar
            if (solicitacao != null)
            {
                listaProdutoAdicionados = listaProdutoAdicionadosEditar;
                foreach (var item in listaProdutoAdicionados)
                {
                    ProdutoSolicitacao ps = new ProdutoSolicitacao();
                    ps.SolicitacaoId = solicitacao.Id;
                    ps.produtoID = item.Id;
                    ps.Quantidade = item.qtdAdicionada;
                    ps.EstoqueAtual = item.Estoque - item.qtdAdicionada;
                    new PadraoDAO().AtualizarEstoque(ps);
                    new PadraoDAO().CadastrarProdutoSolicitacao(ps);

                }
                new PadraoDAO().UpdateSolicitacao(s);
                MessageBox.Show("Solicitacao atualizada com sucesso!");
                this.Close();
                new Form1().Show();
                return;


            }

            //Cadastrar solicitacao

            int idSolicitacao = new PadraoDAO().CadastrarSolicitacao(s);
            new PadraoDAO().CadastrarSolicitacao(s);

            foreach (var item in listaProdutoAdicionados)
            {
                ProdutoSolicitacao ps = new ProdutoSolicitacao();
                ps.SolicitacaoId = idSolicitacao;
                ps.produtoID = item.Id;
                ps.Quantidade = item.qtdAdicionada;
                ps.EstoqueAtual = item.Estoque - item.qtdAdicionada;
                new PadraoDAO().CadastrarProdutoSolicitacao(ps);
                new PadraoDAO().AtualizarEstoque(ps);

            }


            double cash = valor / 100;

            new PadraoDAO().GerarCashback(idSolicitacao, cash);


            MessageBox.Show("Solicitacao cadastrada com sucesso!");
            this.Close();
            new Form1().Show();
            //Cadastrar ProdutosSolicitacao
            //Descontar do estoque
            //Gerar 1% de cashback


        }

        private void Informacoes()
        {
            int qtd = 0;
            valor = 0;
            foreach (var filtro in listaProdutoAdicionados)
            {
                qtd += filtro.qtdAdicionada;
                valor += filtro.Valor * filtro.qtdAdicionada;
            }
            valor = 0;
            foreach (var filtro in listaProdutoAdicionados)
            {
                valor += filtro.Valor * filtro.qtdAdicionada;
            }

            if (!chCash.Checked)
            {
                txtcash.Text = "R$0";
                txtValor.Text = "R$" + valor;
            }
            else
            {
                txtcash.Text = "R$" + Global.user.CashbackUsuario;
                valor = valor - Global.user.CashbackUsuario;
                txtValor.Text = "R$" + valor;
            }

            txtDesconto.Text = "R$0";
            txtQtdProduto.Text = "" + qtd;
            txtValor.Text = "R$" + valor;
        }

        private void chCash_CheckedChanged(object sender, EventArgs e)
        {
            valor = 0;
            foreach (var filtro in listaProdutoAdicionados)
            {
                valor += filtro.Valor * filtro.qtdAdicionada;
            }

            if (!chCash.Checked)
            {
                txtcash.Text = "R$0";
                txtValor.Text = "R$" + valor;
            }
            else
            {
                txtcash.Text = "R$" + Global.user.CashbackUsuario;
                if (Global.user.CashbackUsuario > valor)
                    txtValor.Text = "R$" + 00.0;
                valor = valor - Global.user.CashbackUsuario;
                txtValor.Text = "R$" + valor;
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<DetalhesProdutosDTO> dto = new List<DetalhesProdutosDTO>();

            foreach (var i in listaProdutoAdicionados)
            {
                dto.Add(new DetalhesProdutosDTO
                {
                    Nome = i.nome,
                    fornecedor = new PadraoDAO().NomeFornecedor(i.Id),
                    desconto = 0,
                    preco = i.Valor,
                    Quantidade = i.qtdAdicionada,
                    subtotal = i.Valor * i.qtdAdicionada,
                    Validade = i.Validade,

                });
            }
            new DetalhesProdutos(dto).Show();
        }

        private void cbFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form1().Show();
        }
    }
}
