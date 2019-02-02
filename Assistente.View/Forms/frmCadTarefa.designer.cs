namespace Assistente.View.Forms
{
    partial class frmCadTarefa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.mtbCodigo = new System.Windows.Forms.MaskedTextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSolicitante = new System.Windows.Forms.Label();
            this.txtSolicitante = new System.Windows.Forms.TextBox();
            this.cboPrioridade = new System.Windows.Forms.ComboBox();
            this.lblPrioridade = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.dtpPrazoTermino = new System.Windows.Forms.DateTimePicker();
            this.lblPrazoTermino = new System.Windows.Forms.Label();
            this.dtpDataTermino = new System.Windows.Forms.DateTimePicker();
            this.lblDataTermino = new System.Windows.Forms.Label();
            this.tabTarefa = new System.Windows.Forms.TabControl();
            this.tabPendencias = new System.Windows.Forms.TabPage();
            this.dgvPendencias = new System.Windows.Forms.DataGridView();
            this.colPendenciasId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPendenciasConcluido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPendenciasDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPastas = new System.Windows.Forms.TabPage();
            this.dgvPastas = new System.Windows.Forms.DataGridView();
            this.colPastasId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPastasCaminho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPastasDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabAnotacoes = new System.Windows.Forms.TabPage();
            this.txtAnotações = new System.Windows.Forms.TextBox();
            this.btnCliente = new System.Windows.Forms.Button();
            this.lblResponsavel = new System.Windows.Forms.Label();
            this.txtResponsavel = new System.Windows.Forms.TextBox();
            this.tabTarefa.SuspendLayout();
            this.tabPendencias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendencias)).BeginInit();
            this.tabPastas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPastas)).BeginInit();
            this.tabAnotacoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(9, 69);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(40, 13);
            this.lblCliente.TabIndex = 5;
            this.lblCliente.Text = "Projeto";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(12, 129);
            this.cboStatus.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(160, 21);
            this.cboStatus.TabIndex = 12;
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
            this.txtDescricao.Location = new System.Drawing.Point(119, 41);
            this.txtDescricao.MaxLength = 60;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(438, 20);
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
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(9, 85);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(236, 20);
            this.txtCliente.TabIndex = 6;
            this.txtCliente.Leave += new System.EventHandler(this.txtCliente_Leave);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 113);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Status";
            // 
            // lblSolicitante
            // 
            this.lblSolicitante.AutoSize = true;
            this.lblSolicitante.Location = new System.Drawing.Point(279, 69);
            this.lblSolicitante.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblSolicitante.Name = "lblSolicitante";
            this.lblSolicitante.Size = new System.Drawing.Size(56, 13);
            this.lblSolicitante.TabIndex = 7;
            this.lblSolicitante.Text = "Solicitante";
            // 
            // txtSolicitante
            // 
            this.txtSolicitante.Location = new System.Drawing.Point(279, 85);
            this.txtSolicitante.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.txtSolicitante.Name = "txtSolicitante";
            this.txtSolicitante.Size = new System.Drawing.Size(160, 20);
            this.txtSolicitante.TabIndex = 8;
            // 
            // cboPrioridade
            // 
            this.cboPrioridade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrioridade.FormattingEnabled = true;
            this.cboPrioridade.Location = new System.Drawing.Point(178, 129);
            this.cboPrioridade.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.cboPrioridade.Name = "cboPrioridade";
            this.cboPrioridade.Size = new System.Drawing.Size(95, 21);
            this.cboPrioridade.TabIndex = 14;
            // 
            // lblPrioridade
            // 
            this.lblPrioridade.AutoSize = true;
            this.lblPrioridade.Location = new System.Drawing.Point(178, 113);
            this.lblPrioridade.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblPrioridade.Name = "lblPrioridade";
            this.lblPrioridade.Size = new System.Drawing.Size(54, 13);
            this.lblPrioridade.TabIndex = 13;
            this.lblPrioridade.Text = "Prioridade";
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(279, 129);
            this.cboCategoria.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(160, 21);
            this.cboCategoria.TabIndex = 16;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(279, 113);
            this.lblCategoria.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(52, 13);
            this.lblCategoria.TabIndex = 15;
            this.lblCategoria.Text = "Categoria";
            // 
            // dtpPrazoTermino
            // 
            this.dtpPrazoTermino.Checked = false;
            this.dtpPrazoTermino.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPrazoTermino.Location = new System.Drawing.Point(445, 85);
            this.dtpPrazoTermino.Name = "dtpPrazoTermino";
            this.dtpPrazoTermino.ShowCheckBox = true;
            this.dtpPrazoTermino.Size = new System.Drawing.Size(112, 20);
            this.dtpPrazoTermino.TabIndex = 10;
            // 
            // lblPrazoTermino
            // 
            this.lblPrazoTermino.AutoSize = true;
            this.lblPrazoTermino.Location = new System.Drawing.Point(445, 69);
            this.lblPrazoTermino.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblPrazoTermino.Name = "lblPrazoTermino";
            this.lblPrazoTermino.Size = new System.Drawing.Size(75, 13);
            this.lblPrazoTermino.TabIndex = 9;
            this.lblPrazoTermino.Text = "Prazo Termino";
            // 
            // dtpDataTermino
            // 
            this.dtpDataTermino.Checked = false;
            this.dtpDataTermino.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataTermino.Location = new System.Drawing.Point(445, 129);
            this.dtpDataTermino.Name = "dtpDataTermino";
            this.dtpDataTermino.ShowCheckBox = true;
            this.dtpDataTermino.Size = new System.Drawing.Size(112, 20);
            this.dtpDataTermino.TabIndex = 18;
            // 
            // lblDataTermino
            // 
            this.lblDataTermino.AutoSize = true;
            this.lblDataTermino.Location = new System.Drawing.Point(445, 113);
            this.lblDataTermino.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblDataTermino.Name = "lblDataTermino";
            this.lblDataTermino.Size = new System.Drawing.Size(71, 13);
            this.lblDataTermino.TabIndex = 17;
            this.lblDataTermino.Text = "Data Termino";
            // 
            // tabTarefa
            // 
            this.tabTarefa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabTarefa.Controls.Add(this.tabPendencias);
            this.tabTarefa.Controls.Add(this.tabPastas);
            this.tabTarefa.Controls.Add(this.tabAnotacoes);
            this.tabTarefa.Location = new System.Drawing.Point(9, 205);
            this.tabTarefa.Name = "tabTarefa";
            this.tabTarefa.SelectedIndex = 0;
            this.tabTarefa.Size = new System.Drawing.Size(548, 320);
            this.tabTarefa.TabIndex = 19;
            // 
            // tabPendencias
            // 
            this.tabPendencias.BackColor = System.Drawing.Color.Transparent;
            this.tabPendencias.Controls.Add(this.dgvPendencias);
            this.tabPendencias.Location = new System.Drawing.Point(4, 22);
            this.tabPendencias.Name = "tabPendencias";
            this.tabPendencias.Padding = new System.Windows.Forms.Padding(3);
            this.tabPendencias.Size = new System.Drawing.Size(540, 294);
            this.tabPendencias.TabIndex = 0;
            this.tabPendencias.Text = "Pendências";
            this.tabPendencias.UseVisualStyleBackColor = true;
            // 
            // dgvPendencias
            // 
            this.dgvPendencias.AllowUserToAddRows = false;
            this.dgvPendencias.AllowUserToDeleteRows = false;
            this.dgvPendencias.AllowUserToResizeColumns = false;
            this.dgvPendencias.AllowUserToResizeRows = false;
            this.dgvPendencias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPendencias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPendencias.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPendencias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPendencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendencias.ColumnHeadersVisible = false;
            this.dgvPendencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPendenciasId,
            this.colPendenciasConcluido,
            this.colPendenciasDescricao});
            this.dgvPendencias.GridColor = System.Drawing.SystemColors.Window;
            this.dgvPendencias.Location = new System.Drawing.Point(1, 0);
            this.dgvPendencias.Name = "dgvPendencias";
            this.dgvPendencias.RowHeadersVisible = false;
            this.dgvPendencias.Size = new System.Drawing.Size(538, 294);
            this.dgvPendencias.TabIndex = 5;
            this.dgvPendencias.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPendencias_CellEndEdit);
            this.dgvPendencias.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvPendencias_KeyUp);
            this.dgvPendencias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPendencias_CellContentClick);
            // 
            // colPendenciasId
            // 
            this.colPendenciasId.HeaderText = "Id";
            this.colPendenciasId.Name = "colPendenciasId";
            this.colPendenciasId.Visible = false;
            // 
            // colPendenciasConcluido
            // 
            this.colPendenciasConcluido.HeaderText = "Concluído";
            this.colPendenciasConcluido.Name = "colPendenciasConcluido";
            this.colPendenciasConcluido.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPendenciasConcluido.Width = 25;
            // 
            // colPendenciasDescricao
            // 
            this.colPendenciasDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colPendenciasDescricao.DefaultCellStyle = dataGridViewCellStyle1;
            this.colPendenciasDescricao.HeaderText = "Descrição";
            this.colPendenciasDescricao.Name = "colPendenciasDescricao";
            // 
            // tabPastas
            // 
            this.tabPastas.Controls.Add(this.dgvPastas);
            this.tabPastas.Location = new System.Drawing.Point(4, 22);
            this.tabPastas.Name = "tabPastas";
            this.tabPastas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPastas.Size = new System.Drawing.Size(540, 294);
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
            this.dgvPastas.Location = new System.Drawing.Point(0, 0);
            this.dgvPastas.Name = "dgvPastas";
            this.dgvPastas.RowHeadersVisible = false;
            this.dgvPastas.Size = new System.Drawing.Size(540, 277);
            this.dgvPastas.TabIndex = 1;
            this.dgvPastas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPastas_CellEndEdit);
            this.dgvPastas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvPastas_KeyUp);
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
            this.colPastasDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPastasDescricao.HeaderText = "Descrição";
            this.colPastasDescricao.Name = "colPastasDescricao";
            this.colPastasDescricao.Width = 200;
            // 
            // tabAnotacoes
            // 
            this.tabAnotacoes.BackColor = System.Drawing.Color.Transparent;
            this.tabAnotacoes.Controls.Add(this.txtAnotações);
            this.tabAnotacoes.Location = new System.Drawing.Point(4, 22);
            this.tabAnotacoes.Name = "tabAnotacoes";
            this.tabAnotacoes.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnotacoes.Size = new System.Drawing.Size(540, 294);
            this.tabAnotacoes.TabIndex = 1;
            this.tabAnotacoes.Text = "Anotações";
            this.tabAnotacoes.UseVisualStyleBackColor = true;
            // 
            // txtAnotações
            // 
            this.txtAnotações.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnotações.Location = new System.Drawing.Point(3, 0);
            this.txtAnotações.MaxLength = 1000;
            this.txtAnotações.Multiline = true;
            this.txtAnotações.Name = "txtAnotações";
            this.txtAnotações.Size = new System.Drawing.Size(537, 277);
            this.txtAnotações.TabIndex = 0;
            // 
            // btnCliente
            // 
            this.btnCliente.Location = new System.Drawing.Point(251, 83);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(22, 23);
            this.btnCliente.TabIndex = 20;
            this.btnCliente.Text = "+";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // lblResponsavel
            // 
            this.lblResponsavel.AutoSize = true;
            this.lblResponsavel.Location = new System.Drawing.Point(12, 158);
            this.lblResponsavel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblResponsavel.Name = "lblResponsavel";
            this.lblResponsavel.Size = new System.Drawing.Size(69, 13);
            this.lblResponsavel.TabIndex = 21;
            this.lblResponsavel.Text = "Responsável";
            // 
            // txtResponsavel
            // 
            this.txtResponsavel.Location = new System.Drawing.Point(12, 174);
            this.txtResponsavel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.txtResponsavel.Name = "txtResponsavel";
            this.txtResponsavel.Size = new System.Drawing.Size(160, 20);
            this.txtResponsavel.TabIndex = 22;
            // 
            // frmCadTarefa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 553);
            this.Controls.Add(this.lblResponsavel);
            this.Controls.Add(this.txtResponsavel);
            this.Controls.Add(this.btnCliente);
            this.Controls.Add(this.tabTarefa);
            this.Controls.Add(this.dtpDataTermino);
            this.Controls.Add(this.lblDataTermino);
            this.Controls.Add(this.dtpPrazoTermino);
            this.Controls.Add(this.lblPrazoTermino);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.cboPrioridade);
            this.Controls.Add(this.lblPrioridade);
            this.Controls.Add(this.lblSolicitante);
            this.Controls.Add(this.txtSolicitante);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.mtbCodigo);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblStatus);
            this.Name = "frmCadTarefa";
            this.Text = "Cadastro de Tarefa";
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.Controls.SetChildIndex(this.txtCliente, 0);
            this.Controls.SetChildIndex(this.lblCodigo, 0);
            this.Controls.SetChildIndex(this.txtDescricao, 0);
            this.Controls.SetChildIndex(this.lblDescricao, 0);
            this.Controls.SetChildIndex(this.mtbCodigo, 0);
            this.Controls.SetChildIndex(this.cboStatus, 0);
            this.Controls.SetChildIndex(this.lblCliente, 0);
            this.Controls.SetChildIndex(this.txtSolicitante, 0);
            this.Controls.SetChildIndex(this.lblSolicitante, 0);
            this.Controls.SetChildIndex(this.lblPrioridade, 0);
            this.Controls.SetChildIndex(this.cboPrioridade, 0);
            this.Controls.SetChildIndex(this.lblCategoria, 0);
            this.Controls.SetChildIndex(this.cboCategoria, 0);
            this.Controls.SetChildIndex(this.lblPrazoTermino, 0);
            this.Controls.SetChildIndex(this.dtpPrazoTermino, 0);
            this.Controls.SetChildIndex(this.lblDataTermino, 0);
            this.Controls.SetChildIndex(this.dtpDataTermino, 0);
            this.Controls.SetChildIndex(this.tabTarefa, 0);
            this.Controls.SetChildIndex(this.btnCliente, 0);
            this.Controls.SetChildIndex(this.txtResponsavel, 0);
            this.Controls.SetChildIndex(this.lblResponsavel, 0);
            this.tabTarefa.ResumeLayout(false);
            this.tabPendencias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendencias)).EndInit();
            this.tabPastas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPastas)).EndInit();
            this.tabAnotacoes.ResumeLayout(false);
            this.tabAnotacoes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.MaskedTextBox mtbCodigo;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblSolicitante;
        private System.Windows.Forms.TextBox txtSolicitante;
        private System.Windows.Forms.ComboBox cboPrioridade;
        private System.Windows.Forms.Label lblPrioridade;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.DateTimePicker dtpPrazoTermino;
        private System.Windows.Forms.Label lblPrazoTermino;
        private System.Windows.Forms.DateTimePicker dtpDataTermino;
        private System.Windows.Forms.Label lblDataTermino;
        private System.Windows.Forms.TabControl tabTarefa;
        private System.Windows.Forms.TabPage tabPendencias;
        private System.Windows.Forms.TabPage tabAnotacoes;
        private System.Windows.Forms.DataGridView dgvPendencias;
        private System.Windows.Forms.TextBox txtAnotações;
        private System.Windows.Forms.TabPage tabPastas;
        private System.Windows.Forms.DataGridView dgvPastas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPastasId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPastasCaminho;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPastasDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPendenciasId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPendenciasConcluido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPendenciasDescricao;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Label lblResponsavel;
        private System.Windows.Forms.TextBox txtResponsavel;

    }
}