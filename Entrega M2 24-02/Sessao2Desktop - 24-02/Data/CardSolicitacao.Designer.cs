namespace Sessao2Desktop2.Data
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtNome = new System.Windows.Forms.Label();
            this.txtdata = new System.Windows.Forms.Label();
            this.txtDes = new System.Windows.Forms.Label();
            this.txtPreco = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sessao2Desktop2.Properties.Resources.medicamento;
            this.pictureBox1.Location = new System.Drawing.Point(20, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtNome
            // 
            this.txtNome.AutoSize = true;
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(17, 99);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(46, 18);
            this.txtNome.TabIndex = 1;
            this.txtNome.Text = "label1";
            // 
            // txtdata
            // 
            this.txtdata.AutoSize = true;
            this.txtdata.Location = new System.Drawing.Point(17, 137);
            this.txtdata.Name = "txtdata";
            this.txtdata.Size = new System.Drawing.Size(35, 13);
            this.txtdata.TabIndex = 2;
            this.txtdata.Text = "label2";
            // 
            // txtDes
            // 
            this.txtDes.AutoSize = true;
            this.txtDes.Location = new System.Drawing.Point(17, 124);
            this.txtDes.Name = "txtDes";
            this.txtDes.Size = new System.Drawing.Size(35, 13);
            this.txtDes.TabIndex = 2;
            this.txtDes.Text = "label2";
            // 
            // txtPreco
            // 
            this.txtPreco.AutoSize = true;
            this.txtPreco.Location = new System.Drawing.Point(17, 151);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(35, 13);
            this.txtPreco.TabIndex = 3;
            this.txtPreco.Text = "label4";
            // 
            // txtStatus
            // 
            this.txtStatus.AutoSize = true;
            this.txtStatus.Location = new System.Drawing.Point(106, 151);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(35, 13);
            this.txtStatus.TabIndex = 4;
            this.txtStatus.Text = "label5";
            // 
            // CardSolicitacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.txtDes);
            this.Controls.Add(this.txtdata);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CardSolicitacao";
            this.Size = new System.Drawing.Size(162, 179);
            this.Load += new System.EventHandler(this.CardSolicitacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtNome;
        private System.Windows.Forms.Label txtdata;
        private System.Windows.Forms.Label txtDes;
        private System.Windows.Forms.Label txtPreco;
        private System.Windows.Forms.Label txtStatus;
    }
}
