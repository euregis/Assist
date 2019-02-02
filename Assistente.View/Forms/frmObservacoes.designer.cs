namespace Assistente.View.Forms
{
    partial class frmObservacoes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPendencias = new System.Windows.Forms.DataGridView();
            this.colPendenciasConcluido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPendenciasDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.txtDescricaoHorario = new System.Windows.Forms.TextBox();
            this.lblPendencias = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendencias)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPendencias
            // 
            this.dgvPendencias.AllowUserToAddRows = false;
            this.dgvPendencias.AllowUserToDeleteRows = false;
            this.dgvPendencias.AllowUserToOrderColumns = true;
            this.dgvPendencias.AllowUserToResizeColumns = false;
            this.dgvPendencias.AllowUserToResizeRows = false;
            this.dgvPendencias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPendencias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPendencias.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPendencias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPendencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendencias.ColumnHeadersVisible = false;
            this.dgvPendencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPendenciasConcluido,
            this.colPendenciasDescricao});
            this.dgvPendencias.GridColor = System.Drawing.SystemColors.Window;
            this.dgvPendencias.Location = new System.Drawing.Point(10, 41);
            this.dgvPendencias.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.dgvPendencias.Name = "dgvPendencias";
            this.dgvPendencias.RowHeadersVisible = false;
            this.dgvPendencias.Size = new System.Drawing.Size(454, 276);
            this.dgvPendencias.TabIndex = 5;
            this.dgvPendencias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPendencias_CellContentClick);
            // 
            // colPendenciasConcluido
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = false;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.colPendenciasConcluido.DefaultCellStyle = dataGridViewCellStyle5;
            this.colPendenciasConcluido.HeaderText = "Concluído";
            this.colPendenciasConcluido.Name = "colPendenciasConcluido";
            this.colPendenciasConcluido.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPendenciasConcluido.Width = 25;
            // 
            // colPendenciasDescricao
            // 
            this.colPendenciasDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colPendenciasDescricao.DefaultCellStyle = dataGridViewCellStyle6;
            this.colPendenciasDescricao.HeaderText = "Descrição";
            this.colPendenciasDescricao.Name = "colPendenciasDescricao";
            this.colPendenciasDescricao.ReadOnly = true;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservacao.Location = new System.Drawing.Point(10, 338);
            this.txtObservacao.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtObservacao.Size = new System.Drawing.Size(454, 54);
            this.txtObservacao.TabIndex = 4;
            this.txtObservacao.TextChanged += new System.EventHandler(this.txtObservacao_TextChanged);
            // 
            // txtDescricaoHorario
            // 
            this.txtDescricaoHorario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricaoHorario.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtDescricaoHorario.Location = new System.Drawing.Point(10, 413);
            this.txtDescricaoHorario.Multiline = true;
            this.txtDescricaoHorario.Name = "txtDescricaoHorario";
            this.txtDescricaoHorario.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescricaoHorario.Size = new System.Drawing.Size(454, 63);
            this.txtDescricaoHorario.TabIndex = 6;
            this.txtDescricaoHorario.TextChanged += new System.EventHandler(this.txtDescricaoHorario_TextChanged);
            // 
            // lblPendencias
            // 
            this.lblPendencias.AutoSize = true;
            this.lblPendencias.Location = new System.Drawing.Point(10, 25);
            this.lblPendencias.Name = "lblPendencias";
            this.lblPendencias.Size = new System.Drawing.Size(112, 13);
            this.lblPendencias.TabIndex = 7;
            this.lblPendencias.Text = "Pendências da Tarefa";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Obeservações do Digitadas";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 397);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Descrição do Horário";
            // 
            // frmObservacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 501);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPendencias);
            this.Controls.Add(this.txtDescricaoHorario);
            this.Controls.Add(this.dgvPendencias);
            this.Controls.Add(this.txtObservacao);
            this.Name = "frmObservacoes";
            this.Text = "Observações";
            this.Controls.SetChildIndex(this.txtObservacao, 0);
            this.Controls.SetChildIndex(this.dgvPendencias, 0);
            this.Controls.SetChildIndex(this.txtDescricaoHorario, 0);
            this.Controls.SetChildIndex(this.lblPendencias, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPendencias;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.TextBox txtDescricaoHorario;
        private System.Windows.Forms.Label lblPendencias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPendenciasConcluido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPendenciasDescricao;
    }
}