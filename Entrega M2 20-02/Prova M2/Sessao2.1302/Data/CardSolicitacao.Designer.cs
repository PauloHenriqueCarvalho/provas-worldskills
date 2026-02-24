namespace Sessao2._1302.Data
{
    partial class CardSolicitacao
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtTipo = new System.Windows.Forms.Label();
            this.txtDes = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sessao2._1302.Properties.Resources.medicamento;
            this.pictureBox1.Location = new System.Drawing.Point(18, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtTipo
            // 
            this.txtTipo.AutoSize = true;
            this.txtTipo.Location = new System.Drawing.Point(15, 139);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(35, 13);
            this.txtTipo.TabIndex = 1;
            this.txtTipo.Text = "label1";
            // 
            // txtDes
            // 
            this.txtDes.AutoSize = true;
            this.txtDes.Location = new System.Drawing.Point(15, 162);
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(35, 13);
            this.txtDes.TabIndex = 2;
            this.txtDes.Text = "label2";
            // 
            // txtData
            // 
            this.txtData.AutoSize = true;
            this.txtData.Location = new System.Drawing.Point(15, 189);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(35, 13);
            this.txtData.TabIndex = 3;
            this.txtData.Text = "label3";
            // 
            // txtValor
            // 
            this.txtValor.AutoSize = true;
            this.txtValor.Location = new System.Drawing.Point(15, 212);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(35, 13);
            this.txtValor.TabIndex = 4;
            this.txtValor.Text = "label4";
            // 
            // txtStatus
            // 
            this.txtStatus.AutoSize = true;
            this.txtStatus.Location = new System.Drawing.Point(139, 201);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(35, 13);
            this.txtStatus.TabIndex = 5;
            this.txtStatus.Text = "label5";
            // 
            // menu
            // 
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(61, 4);
            // 
            // CardSolicitacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.txtDes);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CardSolicitacao";
            this.Size = new System.Drawing.Size(191, 239);
            this.Load += new System.EventHandler(this.CardSolicitacao_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CardSolicitacao_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtTipo;
        private System.Windows.Forms.Label txtDes;
        private System.Windows.Forms.Label txtData;
        private System.Windows.Forms.Label txtValor;
        private System.Windows.Forms.Label txtStatus;
        private System.Windows.Forms.ContextMenuStrip menu;
    }
}
