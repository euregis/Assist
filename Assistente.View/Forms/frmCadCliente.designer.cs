namespace Assistente.View.Forms
{
    partial class frmCadCliente
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
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.fbdCaminho = new System.Windows.Forms.FolderBrowserDialog();
            this.mtbCodigo = new System.Windows.Forms.MaskedTextBox();
            this.tabCliente = new System.Windows.Forms.TabControl();
            this.tabPastas = new System.Windows.Forms.TabPage();
            this.dgvPastas = new System.Windows.Forms.DataGridView();
            this.chkInativo = new System.Windows.Forms.CheckBox();
            this.colPastasId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPastasCaminho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPastasDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodRegis = new System.Windows.Forms.TextBox();
            this.tabCliente.SuspendLayout();
            this.tabPastas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPastas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(323, 28);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 3;
            this.lblNome.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNome.Location = new System.Drawing.Point(323, 44);
            this.txtNome.MaxLength = 60;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(305, 20);
            this.txtNome.TabIndex = 4;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(9, 28);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.Text = "Código";
            // 
            // mtbCodigo
            // 
            this.mtbCodigo.Enabled = false;
            this.mtbCodigo.Location = new System.Drawing.Point(9, 44);
            this.mtbCodigo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.mtbCodigo.Name = "mtbCodigo";
            this.mtbCodigo.PromptChar = ' ';
            this.mtbCodigo.Size = new System.Drawing.Size(69, 20);
            this.mtbCodigo.TabIndex = 2;
            // 
            // tabCliente
            // 
            this.tabCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCliente.Controls.Add(this.tabPastas);
            this.tabCliente.Location = new System.Drawing.Point(9, 72);
            this.tabCliente.Name = "tabCliente";
            this.tabCliente.SelectedIndex = 0;
            this.tabCliente.Size = new System.Drawing.Size(671, 255);
            this.tabCliente.TabIndex = 5;
            // 
            // tabPastas
            // 
            this.tabPastas.Controls.Add(this.dgvPastas);
            this.tabPastas.Location = new System.Drawing.Point(4, 22);
            this.tabPastas.Name = "tabPastas";
            this.tabPastas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPastas.Size = new System.Drawing.Size(663, 229);
            this.tabPastas.TabIndex = 2;
            this.tabPastas.Text = "Atalhos";
            this.tabPastas.UseVisualStyleBackColor = true;
            // 
            // dgvPastas
            // 
            this.dgvPastas.AllowUserToAddRows = false;
            this.dgvPastas.AllowUserToDeleteRows = false;
            this.dgvPastas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPastas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPastas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPastas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPastasId,
            this.colPastasCaminho,
            this.colPastasDescricao});
            this.dgvPastas.Location = new System.Drawing.Point(0, 4);
            this.dgvPastas.Name = "dgvPastas";
            this.dgvPastas.RowHeadersVisible = false;
            this.dgvPastas.Size = new System.Drawing.Size(663, 229);
            this.dgvPastas.TabIndex = 0;
            this.dgvPastas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPastas_CellEndEdit);
            this.dgvPastas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvPastas_KeyUp);
            // 
            // chkInativo
            // 
            this.chkInativo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInativo.AutoSize = true;
            this.chkInativo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkInativo.Location = new System.Drawing.Point(634, 28);
            this.chkInativo.Name = "chkInativo";
            this.chkInativo.Size = new System.Drawing.Size(43, 31);
            this.chkInativo.TabIndex = 6;
            this.chkInativo.Text = "Inativo";
            this.chkInativo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkInativo.UseVisualStyleBackColor = true;
            // 
            // colPastasId
            // 
            this.colPastasId.HeaderText = "Id";
            this.colPastasId.Name = "colPastasId";
            this.colPastasId.ReadOnly = true;
            this.colPastasId.Visible = false;
            // 
            // colPastasCaminho
            // 
            this.colPastasCaminho.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPastasCaminho.HeaderText = "Caminho";
            this.colPastasCaminho.Name = "colPastasCaminho";
            // 
            // colPastasDescricao
            // 
            this.colPastasDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPastasDescricao.HeaderText = "Descrição";
            this.colPastasDescricao.Name = "colPastasDescricao";
            this.colPastasDescricao.Width = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Código Regis";
            // 
            // txtCodRegis
            // 
            this.txtCodRegis.Location = new System.Drawing.Point(84, 44);
            this.txtCodRegis.MaxLength = 60;
            this.txtCodRegis.Name = "txtCodRegis";
            this.txtCodRegis.Size = new System.Drawing.Size(225, 20);
            this.txtCodRegis.TabIndex = 8;
            // 
            // frmCadCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 357);
            this.Controls.Add(this.txtCodRegis);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkInativo);
            this.Controls.Add(this.tabCliente);
            this.Controls.Add(this.mtbCodigo);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblCodigo);
            this.Name = "frmCadCliente";
            this.Text = "Cadastro de Projeto";
            this.Controls.SetChildIndex(this.lblCodigo, 0);
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.lblNome, 0);
            this.Controls.SetChildIndex(this.mtbCodigo, 0);
            this.Controls.SetChildIndex(this.tabCliente, 0);
            this.Controls.SetChildIndex(this.chkInativo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtCodRegis, 0);
            this.tabCliente.ResumeLayout(false);
            this.tabPastas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPastas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.FolderBrowserDialog fbdCaminho;
        private System.Windows.Forms.MaskedTextBox mtbCodigo;
        private System.Windows.Forms.TabControl tabCliente;
        private System.Windows.Forms.TabPage tabPastas;
        private System.Windows.Forms.DataGridView dgvPastas;
        private System.Windows.Forms.CheckBox chkInativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPastasId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPastasCaminho;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPastasDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodRegis;
    }
}