namespace Assistente.View.Base.Forms
{
    partial class frmApresValidacoes<T>
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvErros = new System.Windows.Forms.DataGridView();
            this.tmrFechamento = new System.Windows.Forms.Timer(this.components);
            this.colValidacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrigem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.colMensagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErros)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvErros
            // 
            this.dgvErros.AllowUserToAddRows = false;
            this.dgvErros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvErros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvErros.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvErros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colValidacao,
            this.colOrigem,
            this.colDescricao,
            this.colStatus,
            this.colMensagem});
            this.dgvErros.Location = new System.Drawing.Point(0, 25);
            this.dgvErros.Name = "dgvErros";
            this.dgvErros.RowHeadersVisible = false;
            this.dgvErros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErros.Size = new System.Drawing.Size(583, 269);
            this.dgvErros.TabIndex = 2;
            // 
            // tmrFechamento
            // 
            this.tmrFechamento.Interval = 1000;
            this.tmrFechamento.Tick += new System.EventHandler(this.tmrFechamento_Tick);
            // 
            // colValidacao
            // 
            this.colValidacao.HeaderText = "Validacao";
            this.colValidacao.Name = "colValidacao";
            this.colValidacao.ReadOnly = true;
            this.colValidacao.Visible = false;
            this.colValidacao.Width = 60;
            // 
            // colOrigem
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colOrigem.DefaultCellStyle = dataGridViewCellStyle1;
            this.colOrigem.HeaderText = "Num.";
            this.colOrigem.Name = "colOrigem";
            this.colOrigem.ReadOnly = true;
            this.colOrigem.Width = 57;
            // 
            // colDescricao
            // 
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            this.colDescricao.Width = 80;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 43;
            // 
            // colMensagem
            // 
            this.colMensagem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colMensagem.DefaultCellStyle = dataGridViewCellStyle2;
            this.colMensagem.HeaderText = "Mensagem";
            this.colMensagem.Name = "colMensagem";
            this.colMensagem.ReadOnly = true;
            // 
            // frmApresValidacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 316);
            this.Controls.Add(this.dgvErros);
            this.Name = "frmApresValidacoes";
            this.Text = "ApresErro";
            this.TopMost = true;
            this.Controls.SetChildIndex(this.dgvErros, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvErros;
        private System.Windows.Forms.Timer tmrFechamento;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValidacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrigem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewImageColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMensagem;
    }
}