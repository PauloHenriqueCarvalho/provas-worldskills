namespace Sessao2._1302.View
{
    partial class NovaSolicitacaoView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.edtDes = new System.Windows.Forms.TextBox();
            this.dtValidade = new System.Windows.Forms.DateTimePicker();
            this.cbFornecedor = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.edtBusca = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtQtdProduto = new System.Windows.Forms.Label();
            this.txtDesconto = new System.Windows.Forms.Label();
            this.txtcash = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.Label();
            this.chCash = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pMedi = new System.Windows.Forms.PictureBox();
            this.pEqui = new System.Windows.Forms.PictureBox();
            this.pHigi = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pMedi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pEqui)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHigi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(316, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nova Solicitação";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descrição";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Validade";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(578, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fornecedor";
            // 
            // edtDes
            // 
            this.edtDes.Location = new System.Drawing.Point(36, 132);
            this.edtDes.Multiline = true;
            this.edtDes.Name = "edtDes";
            this.edtDes.Size = new System.Drawing.Size(201, 64);
            this.edtDes.TabIndex = 5;
            // 
            // dtValidade
            // 
            this.dtValidade.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtValidade.Location = new System.Drawing.Point(375, 132);
            this.dtValidade.Name = "dtValidade";
            this.dtValidade.Size = new System.Drawing.Size(142, 20);
            this.dtValidade.TabIndex = 6;
            // 
            // cbFornecedor
            // 
            this.cbFornecedor.FormattingEnabled = true;
            this.cbFornecedor.Location = new System.Drawing.Point(581, 135);
            this.cbFornecedor.Name = "cbFornecedor";
            this.cbFornecedor.Size = new System.Drawing.Size(121, 21);
            this.cbFornecedor.TabIndex = 7;
            this.cbFornecedor.SelectedIndexChanged += new System.EventHandler(this.cbFornecedor_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.edtBusca);
            this.groupBox1.Controls.Add(this.pMedi);
            this.groupBox1.Controls.Add(this.pEqui);
            this.groupBox1.Controls.Add(this.pHigi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(36, 217);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 370);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Produtos";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Produtos Selecionados";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AllowDrop = true;
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(21, 231);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(717, 118);
            this.flowLayoutPanel2.TabIndex = 11;
            this.flowLayoutPanel2.WrapContents = false;
            this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AllowDrop = true;
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(21, 92);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(717, 116);
            this.flowLayoutPanel1.TabIndex = 10;
            this.flowLayoutPanel1.WrapContents = false;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Resultados da Busca";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Buscar";
            // 
            // edtBusca
            // 
            this.edtBusca.Location = new System.Drawing.Point(28, 34);
            this.edtBusca.Name = "edtBusca";
            this.edtBusca.Size = new System.Drawing.Size(212, 20);
            this.edtBusca.TabIndex = 7;
            this.edtBusca.TextChanged += new System.EventHandler(this.edtBusca_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(592, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tipo de Medicamentos";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 597);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Quantidade Produtos:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 622);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Desconto:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(33, 650);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Cashback:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(33, 678);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Valor Total: R$";
            // 
            // txtQtdProduto
            // 
            this.txtQtdProduto.AutoSize = true;
            this.txtQtdProduto.Location = new System.Drawing.Point(149, 597);
            this.txtQtdProduto.Name = "txtQtdProduto";
            this.txtQtdProduto.Size = new System.Drawing.Size(19, 13);
            this.txtQtdProduto.TabIndex = 13;
            this.txtQtdProduto.Text = "00";
            // 
            // txtDesconto
            // 
            this.txtDesconto.AutoSize = true;
            this.txtDesconto.Location = new System.Drawing.Point(92, 622);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(19, 13);
            this.txtDesconto.TabIndex = 13;
            this.txtDesconto.Text = "00";
            // 
            // txtcash
            // 
            this.txtcash.AutoSize = true;
            this.txtcash.Location = new System.Drawing.Point(92, 650);
            this.txtcash.Name = "txtcash";
            this.txtcash.Size = new System.Drawing.Size(19, 13);
            this.txtcash.TabIndex = 14;
            this.txtcash.Text = "00";
            // 
            // txtValor
            // 
            this.txtValor.AutoSize = true;
            this.txtValor.Location = new System.Drawing.Point(117, 678);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(19, 13);
            this.txtValor.TabIndex = 15;
            this.txtValor.Text = "00";
            // 
            // chCash
            // 
            this.chCash.AutoSize = true;
            this.chCash.Location = new System.Drawing.Point(196, 674);
            this.chCash.Name = "chCash";
            this.chCash.Size = new System.Drawing.Size(74, 17);
            this.chCash.TabIndex = 16;
            this.chCash.Text = "Cashback";
            this.chCash.UseVisualStyleBackColor = true;
            this.chCash.CheckedChanged += new System.EventHandler(this.chCash_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(372, 597);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(49, 13);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Detalhes";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(668, 666);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 30);
            this.button1.TabIndex = 17;
            this.button1.Text = "Salvar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(532, 666);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 30);
            this.button2.TabIndex = 18;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pMedi
            // 
            this.pMedi.Image = global::Sessao2._1302.Properties.Resources.medicamento;
            this.pMedi.Location = new System.Drawing.Point(632, 34);
            this.pMedi.Name = "pMedi";
            this.pMedi.Size = new System.Drawing.Size(50, 42);
            this.pMedi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pMedi.TabIndex = 6;
            this.pMedi.TabStop = false;
            this.pMedi.Click += new System.EventHandler(this.pMedi_Click);
            // 
            // pEqui
            // 
            this.pEqui.Image = global::Sessao2._1302.Properties.Resources.equipamento;
            this.pEqui.Location = new System.Drawing.Point(688, 34);
            this.pEqui.Name = "pEqui";
            this.pEqui.Size = new System.Drawing.Size(50, 42);
            this.pEqui.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pEqui.TabIndex = 5;
            this.pEqui.TabStop = false;
            this.pEqui.Click += new System.EventHandler(this.pEqui_Click);
            // 
            // pHigi
            // 
            this.pHigi.Image = global::Sessao2._1302.Properties.Resources.higiene;
            this.pHigi.Location = new System.Drawing.Point(576, 34);
            this.pHigi.Name = "pHigi";
            this.pHigi.Size = new System.Drawing.Size(50, 42);
            this.pHigi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pHigi.TabIndex = 4;
            this.pHigi.TabStop = false;
            this.pHigi.Click += new System.EventHandler(this.pHigi_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sessao2._1302.Properties.Resources.PonteDourada;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(227, 38);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // NovaSolicitacaoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 712);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.chCash);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtcash);
            this.Controls.Add(this.txtDesconto);
            this.Controls.Add(this.txtQtdProduto);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbFornecedor);
            this.Controls.Add(this.dtValidade);
            this.Controls.Add(this.edtDes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "NovaSolicitacaoView";
            this.Text = "Ponte Dourada - Solicitações";
            this.Load += new System.EventHandler(this.NovaSolicitacaoView_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pMedi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pEqui)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHigi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edtDes;
        private System.Windows.Forms.DateTimePicker dtValidade;
        private System.Windows.Forms.ComboBox cbFornecedor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox edtBusca;
        private System.Windows.Forms.PictureBox pMedi;
        private System.Windows.Forms.PictureBox pEqui;
        private System.Windows.Forms.PictureBox pHigi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label txtQtdProduto;
        private System.Windows.Forms.Label txtDesconto;
        private System.Windows.Forms.Label txtcash;
        private System.Windows.Forms.Label txtValor;
        private System.Windows.Forms.CheckBox chCash;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}