namespace Assistente.View.Forms
{
    partial class frmCadConfiguracao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

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
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblFormato = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.fbdCaminho = new System.Windows.Forms.FolderBrowserDialog();
            this.mtbCodigo = new System.Windows.Forms.MaskedTextBox();
            this.cboFormato = new System.Windows.Forms.ComboBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(122, 28);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 22;
            this.lblDescricao.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(122, 44);
            this.txtDescricao.MaxLength = 60;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(190, 20);
            this.txtDescricao.TabIndex = 17;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(12, 133);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(300, 20);
            this.txtValor.TabIndex = 20;
            // 
            // lblFormato
            // 
            this.lblFormato.AutoSize = true;
            this.lblFormato.Location = new System.Drawing.Point(12, 72);
            this.lblFormato.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblFormato.Name = "lblFormato";
            this.lblFormato.Size = new System.Drawing.Size(54, 13);
            this.lblFormato.TabIndex = 18;
            this.lblFormato.Text = "Validacao";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(12, 28);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 14;
            this.lblCodigo.Text = "Código";
            // 
            // mtbCodigo
            // 
            this.mtbCodigo.Enabled = false;
            this.mtbCodigo.Location = new System.Drawing.Point(12, 44);
            this.mtbCodigo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.mtbCodigo.Name = "mtbCodigo";
            this.mtbCodigo.PromptChar = ' ';
            this.mtbCodigo.Size = new System.Drawing.Size(104, 20);
            this.mtbCodigo.TabIndex = 23;
            // 
            // cboFormato
            // 
            this.cboFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormato.FormattingEnabled = true;
            this.cboFormato.Location = new System.Drawing.Point(12, 88);
            this.cboFormato.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.cboFormato.Name = "cboFormato";
            this.cboFormato.Size = new System.Drawing.Size(300, 21);
            this.cboFormato.TabIndex = 24;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(12, 117);
            this.lblValor.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(31, 13);
            this.lblValor.TabIndex = 25;
            this.lblValor.Text = "Valor";
            // 
            // frmCadConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 179);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.cboFormato);
            this.Controls.Add(this.mtbCodigo);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.lblFormato);
            this.Name = "frmCadConfiguracao";
            this.Text = "Cadastro de Configuração";
            this.Controls.SetChildIndex(this.lblFormato, 0);
            this.Controls.SetChildIndex(this.txtValor, 0);
            this.Controls.SetChildIndex(this.lblCodigo, 0);
            this.Controls.SetChildIndex(this.txtDescricao, 0);
            this.Controls.SetChildIndex(this.lblDescricao, 0);
            this.Controls.SetChildIndex(this.mtbCodigo, 0);
            this.Controls.SetChildIndex(this.cboFormato, 0);
            this.Controls.SetChildIndex(this.lblValor, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblFormato;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.FolderBrowserDialog fbdCaminho;
        private System.Windows.Forms.MaskedTextBox mtbCodigo;
        private System.Windows.Forms.ComboBox cboFormato;
        private System.Windows.Forms.Label lblValor;
    }
}