namespace Assistente.View.Forms
{
    partial class frmInbox
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
            this.dgvInbox = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssunto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnotacoes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAnotacoes = new System.Windows.Forms.TextBox();
            this.cboProjeto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblResponsavel = new System.Windows.Forms.Label();
            this.txtResponsavel = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInbox)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInbox
            // 
            this.dgvInbox.AllowUserToAddRows = false;
            this.dgvInbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInbox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInbox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colDe,
            this.colAssunto,
            this.colData,
            this.colAnotacoes});
            this.dgvInbox.Location = new System.Drawing.Point(12, 12);
            this.dgvInbox.Name = "dgvInbox";
            this.dgvInbox.RowHeadersVisible = false;
            this.dgvInbox.RowTemplate.Height = 20;
            this.dgvInbox.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInbox.Size = new System.Drawing.Size(718, 169);
            this.dgvInbox.TabIndex = 0;
            this.dgvInbox.SelectionChanged += new System.EventHandler(this.dgvInbox_SelectionChanged);
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colDe
            // 
            this.colDe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colDe.HeaderText = "De";
            this.colDe.Name = "colDe";
            this.colDe.ReadOnly = true;
            this.colDe.Width = 46;
            // 
            // colAssunto
            // 
            this.colAssunto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAssunto.HeaderText = "Assunto";
            this.colAssunto.Name = "colAssunto";
            this.colAssunto.ReadOnly = true;
            // 
            // colData
            // 
            this.colData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 55;
            // 
            // colAnotacoes
            // 
            this.colAnotacoes.HeaderText = "Anotacoes";
            this.colAnotacoes.Name = "colAnotacoes";
            this.colAnotacoes.Visible = false;
            // 
            // txtAnotacoes
            // 
            this.txtAnotacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnotacoes.Location = new System.Drawing.Point(12, 203);
            this.txtAnotacoes.Multiline = true;
            this.txtAnotacoes.Name = "txtAnotacoes";
            this.txtAnotacoes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAnotacoes.Size = new System.Drawing.Size(718, 386);
            this.txtAnotacoes.TabIndex = 1;
            // 
            // cboProjeto
            // 
            this.cboProjeto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboProjeto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProjeto.FormattingEnabled = true;
            this.cboProjeto.Location = new System.Drawing.Point(12, 611);
            this.cboProjeto.Name = "cboProjeto";
            this.cboProjeto.Size = new System.Drawing.Size(260, 21);
            this.cboProjeto.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 595);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Projeto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Anotações";
            // 
            // cboStatus
            // 
            this.cboStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(278, 611);
            this.cboStatus.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(184, 21);
            this.cboStatus.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(275, 595);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "Status";
            // 
            // lblResponsavel
            // 
            this.lblResponsavel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResponsavel.AutoSize = true;
            this.lblResponsavel.Location = new System.Drawing.Point(465, 595);
            this.lblResponsavel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblResponsavel.Name = "lblResponsavel";
            this.lblResponsavel.Size = new System.Drawing.Size(69, 13);
            this.lblResponsavel.TabIndex = 23;
            this.lblResponsavel.Text = "Responsável";
            // 
            // txtResponsavel
            // 
            this.txtResponsavel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtResponsavel.Location = new System.Drawing.Point(468, 611);
            this.txtResponsavel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.txtResponsavel.Name = "txtResponsavel";
            this.txtResponsavel.Size = new System.Drawing.Size(181, 20);
            this.txtResponsavel.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(655, 609);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Importar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmInbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 642);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblResponsavel);
            this.Controls.Add(this.txtResponsavel);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboProjeto);
            this.Controls.Add(this.txtAnotacoes);
            this.Controls.Add(this.dgvInbox);
            this.Name = "frmInbox";
            this.Text = "Inbox";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInbox_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInbox;
        private System.Windows.Forms.TextBox txtAnotacoes;
        private System.Windows.Forms.ComboBox cboProjeto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblResponsavel;
        private System.Windows.Forms.TextBox txtResponsavel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssunto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnotacoes;
    }
}