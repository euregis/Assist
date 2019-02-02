namespace Assistente.View.Forms
{
    partial class frmCadAnotTarefa
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
            this.mtbCodigo = new System.Windows.Forms.MaskedTextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblResponsavel = new System.Windows.Forms.Label();
            this.txtResponsavel = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtAnotações = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mtbCodigo
            // 
            this.mtbCodigo.Enabled = false;
            this.mtbCodigo.Location = new System.Drawing.Point(9, 41);
            this.mtbCodigo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.mtbCodigo.Name = "mtbCodigo";
            this.mtbCodigo.PromptChar = ' ';
            this.mtbCodigo.Size = new System.Drawing.Size(104, 20);
            this.mtbCodigo.TabIndex = 1;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(119, 25);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 2;
            this.lblDescricao.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricao.Enabled = false;
            this.txtDescricao.Location = new System.Drawing.Point(119, 41);
            this.txtDescricao.MaxLength = 60;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(317, 20);
            this.txtDescricao.TabIndex = 3;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(9, 25);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código";
            // 
            // lblResponsavel
            // 
            this.lblResponsavel.AutoSize = true;
            this.lblResponsavel.Location = new System.Drawing.Point(209, 69);
            this.lblResponsavel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblResponsavel.Name = "lblResponsavel";
            this.lblResponsavel.Size = new System.Drawing.Size(69, 13);
            this.lblResponsavel.TabIndex = 21;
            this.lblResponsavel.Text = "Responsável";
            // 
            // txtResponsavel
            // 
            this.txtResponsavel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponsavel.Location = new System.Drawing.Point(209, 85);
            this.txtResponsavel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.txtResponsavel.Name = "txtResponsavel";
            this.txtResponsavel.Size = new System.Drawing.Size(227, 20);
            this.txtResponsavel.TabIndex = 22;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(9, 69);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Status";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(9, 85);
            this.cboStatus.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(194, 21);
            this.cboStatus.TabIndex = 12;
            // 
            // txtAnotações
            // 
            this.txtAnotações.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnotações.Location = new System.Drawing.Point(9, 131);
            this.txtAnotações.MaxLength = 1000;
            this.txtAnotações.Multiline = true;
            this.txtAnotações.Name = "txtAnotações";
            this.txtAnotações.Size = new System.Drawing.Size(427, 181);
            this.txtAnotações.TabIndex = 23;
            // 
            // frmCadAnotTarefa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 337);
            this.Controls.Add(this.txtAnotações);
            this.Controls.Add(this.mtbCodigo);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblResponsavel);
            this.Controls.Add(this.txtResponsavel);
            this.Name = "frmCadAnotTarefa";
            this.Text = "Cadastro de Tarefa";
            this.Controls.SetChildIndex(this.txtResponsavel, 0);
            this.Controls.SetChildIndex(this.lblResponsavel, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.Controls.SetChildIndex(this.lblCodigo, 0);
            this.Controls.SetChildIndex(this.txtDescricao, 0);
            this.Controls.SetChildIndex(this.cboStatus, 0);
            this.Controls.SetChildIndex(this.lblDescricao, 0);
            this.Controls.SetChildIndex(this.mtbCodigo, 0);
            this.Controls.SetChildIndex(this.txtAnotações, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtbCodigo;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblResponsavel;
        private System.Windows.Forms.TextBox txtResponsavel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.TextBox txtAnotações;

    }
}