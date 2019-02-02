namespace Assistente.View.Forms
{
    partial class frmProcConfiguracao
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
            this.dgvProc = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFormato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProc)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFiltro
            // 
            this.txtFiltro.Size = new System.Drawing.Size(772, 20);
            //this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // dgvProc
            // 
            this.dgvProc.AllowUserToAddRows = false;
            this.dgvProc.AllowUserToDeleteRows = false;
            this.dgvProc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colCodigo,
            this.colDescricao,
            this.colFormato,
            this.colValor});
            this.dgvProc.Location = new System.Drawing.Point(8, 52);
            this.dgvProc.MultiSelect = false;
            this.dgvProc.Name = "dgvProc";
            this.dgvProc.RowHeadersVisible = false;
            this.dgvProc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProc.Size = new System.Drawing.Size(804, 405);
            this.dgvProc.TabIndex = 5;
            this.dgvProc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProc_CellDoubleClick);
            this.dgvProc.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConfiguracoes_CellEndEdit);
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colCodigo
            // 
            this.colCodigo.HeaderText = "Código";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            this.colCodigo.Width = 70;
            // 
            // colDescricao
            // 
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            this.colDescricao.Width = 350;
            // 
            // colFormato
            // 
            this.colFormato.HeaderText = "Formato";
            this.colFormato.Name = "colFormato";
            this.colFormato.ReadOnly = true;
            this.colFormato.Width = 150;
            // 
            // colValor
            // 
            this.colValor.HeaderText = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.ReadOnly = true;
            this.colValor.Width = 220;
            // 
            // frmProcConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 482);
            this.Controls.Add(this.dgvProc);
            this.Name = "frmProcConfiguracao";
            this.Text = "Configurações";
            this.Controls.SetChildIndex(this.lblFiltro, 0);
            this.Controls.SetChildIndex(this.dgvProc, 0);
            this.Controls.SetChildIndex(this.txtFiltro, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormato;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;



    }
}