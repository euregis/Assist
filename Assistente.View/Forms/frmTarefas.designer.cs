namespace Assistente.View.Forms
{
    partial class frmTarefas
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTarefas = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResponsavel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPrioridade = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPrazo = new Assistente.View.Forms.CalendarColumn();
            this.colQtPendencias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnotacoes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddAnotacao = new System.Windows.Forms.DataGridViewImageColumn();
            this.lnkProjetos = new System.Windows.Forms.LinkLabel();
            this.lnkConfig = new System.Windows.Forms.LinkLabel();
            this.txtAnotacoes = new System.Windows.Forms.TextBox();
            this.dgvPendencias = new System.Windows.Forms.DataGridView();
            this.colPendenciasId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPendenciasConcluido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPendenciasDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGravar = new System.Windows.Forms.Button();
            this.lnkInbox = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarefas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendencias)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFiltro
            // 
            this.txtFiltro.Size = new System.Drawing.Size(810, 20);
            // 
            // dgvTarefas
            // 
            this.dgvTarefas.AllowUserToDeleteRows = false;
            this.dgvTarefas.AllowUserToResizeRows = false;
            this.dgvTarefas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTarefas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTarefas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvTarefas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTarefas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colCliente,
            this.colDescricao,
            this.colResponsavel,
            this.colStatus,
            this.colPrioridade,
            this.colPrazo,
            this.colQtPendencias,
            this.colAnotacoes,
            this.colAddAnotacao});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTarefas.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvTarefas.GridColor = System.Drawing.SystemColors.Window;
            this.dgvTarefas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvTarefas.Location = new System.Drawing.Point(8, 54);
            this.dgvTarefas.MultiSelect = false;
            this.dgvTarefas.Name = "dgvTarefas";
            this.dgvTarefas.RowHeadersVisible = false;
            this.dgvTarefas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTarefas.Size = new System.Drawing.Size(841, 250);
            this.dgvTarefas.TabIndex = 5;
            this.dgvTarefas.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTarefas_CellMouseUp);
            this.dgvTarefas.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgvTarefas_SortCompare);
            //this.dgvTarefas.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTarefas_CellMouseLeave);
            this.dgvTarefas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTarefas_CellDoubleClick);
            this.dgvTarefas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTarefas_CellFormatting);
            //this.dgvTarefas.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTarefas_CellMouseEnter);
            this.dgvTarefas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTarefas_CellEndEdit);
            this.dgvTarefas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTarefas_CellClick);
            this.dgvTarefas.SelectionChanged += new System.EventHandler(this.dgvTarefas_SelectionChanged);
            // 
            // colId
            // 
            this.colId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.colId.DefaultCellStyle = dataGridViewCellStyle1;
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 41;
            // 
            // colCliente
            // 
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.colCliente.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCliente.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colCliente.HeaderText = "Projeto";
            this.colCliente.Name = "colCliente";
            this.colCliente.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCliente.Width = 101;
            // 
            // colDescricao
            // 
            this.colDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colDescricao.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDescricao.FillWeight = 321F;
            this.colDescricao.HeaderText = "Descrição";
            this.colDescricao.MinimumWidth = 321;
            this.colDescricao.Name = "colDescricao";
            this.colDescricao.ReadOnly = true;
            // 
            // colResponsavel
            // 
            this.colResponsavel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colResponsavel.DefaultCellStyle = dataGridViewCellStyle4;
            this.colResponsavel.HeaderText = "Responsável";
            this.colResponsavel.Name = "colResponsavel";
            this.colResponsavel.Width = 94;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.colStatus.DefaultCellStyle = dataGridViewCellStyle5;
            this.colStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 100;
            this.colStatus.Name = "colStatus";
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colPrioridade
            // 
            this.colPrioridade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.colPrioridade.DefaultCellStyle = dataGridViewCellStyle6;
            this.colPrioridade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colPrioridade.HeaderText = "Prior.";
            this.colPrioridade.MinimumWidth = 80;
            this.colPrioridade.Name = "colPrioridade";
            this.colPrioridade.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPrioridade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colPrioridade.Visible = false;
            // 
            // colPrazo
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.colPrazo.DefaultCellStyle = dataGridViewCellStyle7;
            this.colPrazo.HeaderText = "Prazo";
            this.colPrazo.Name = "colPrazo";
            this.colPrazo.Width = 80;
            // 
            // colQtPendencias
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.Window;
            this.colQtPendencias.DefaultCellStyle = dataGridViewCellStyle8;
            this.colQtPendencias.HeaderText = "Pend.";
            this.colQtPendencias.Name = "colQtPendencias";
            this.colQtPendencias.ReadOnly = true;
            this.colQtPendencias.Width = 35;
            // 
            // colAnotacoes
            // 
            this.colAnotacoes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colAnotacoes.DefaultCellStyle = dataGridViewCellStyle9;
            this.colAnotacoes.FillWeight = 150F;
            this.colAnotacoes.HeaderText = "Anotações";
            this.colAnotacoes.MinimumWidth = 150;
            this.colAnotacoes.Name = "colAnotacoes";
            // 
            // colAddAnotacao
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.NullValue = null;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.colAddAnotacao.DefaultCellStyle = dataGridViewCellStyle10;
            this.colAddAnotacao.HeaderText = "";
            this.colAddAnotacao.Image = global::Assistente.View.Properties.Resources.salvar;
            this.colAddAnotacao.MinimumWidth = 15;
            this.colAddAnotacao.Name = "colAddAnotacao";
            this.colAddAnotacao.ReadOnly = true;
            this.colAddAnotacao.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAddAnotacao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colAddAnotacao.Width = 30;
            // 
            // lnkProjetos
            // 
            this.lnkProjetos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkProjetos.AutoSize = true;
            this.lnkProjetos.Location = new System.Drawing.Point(805, 448);
            this.lnkProjetos.Name = "lnkProjetos";
            this.lnkProjetos.Size = new System.Drawing.Size(45, 13);
            this.lnkProjetos.TabIndex = 9;
            this.lnkProjetos.TabStop = true;
            this.lnkProjetos.Text = "Projetos";
            this.lnkProjetos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkProjetos_LinkClicked);
            // 
            // lnkConfig
            // 
            this.lnkConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkConfig.AutoSize = true;
            this.lnkConfig.Location = new System.Drawing.Point(809, 466);
            this.lnkConfig.Name = "lnkConfig";
            this.lnkConfig.Size = new System.Drawing.Size(40, 13);
            this.lnkConfig.TabIndex = 10;
            this.lnkConfig.TabStop = true;
            this.lnkConfig.Text = "Config.";
            this.lnkConfig.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkConfig_LinkClicked);
            // 
            // txtAnotacoes
            // 
            this.txtAnotacoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnotacoes.Location = new System.Drawing.Point(412, 310);
            this.txtAnotacoes.Multiline = true;
            this.txtAnotacoes.Name = "txtAnotacoes";
            this.txtAnotacoes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAnotacoes.Size = new System.Drawing.Size(340, 169);
            this.txtAnotacoes.TabIndex = 12;
            this.txtAnotacoes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAnotações_MouseClick);
            this.txtAnotacoes.Enter += new System.EventHandler(this.txtAnotações_Enter);
            // 
            // dgvPendencias
            // 
            this.dgvPendencias.AllowUserToAddRows = false;
            this.dgvPendencias.AllowUserToDeleteRows = false;
            this.dgvPendencias.AllowUserToResizeColumns = false;
            this.dgvPendencias.AllowUserToResizeRows = false;
            this.dgvPendencias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.dgvPendencias.Location = new System.Drawing.Point(8, 310);
            this.dgvPendencias.Name = "dgvPendencias";
            this.dgvPendencias.RowHeadersVisible = false;
            this.dgvPendencias.Size = new System.Drawing.Size(398, 169);
            this.dgvPendencias.TabIndex = 11;
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
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colPendenciasDescricao.DefaultCellStyle = dataGridViewCellStyle12;
            this.colPendenciasDescricao.HeaderText = "Descrição";
            this.colPendenciasDescricao.Name = "colPendenciasDescricao";
            // 
            // btnGravar
            // 
            this.btnGravar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGravar.Location = new System.Drawing.Point(758, 310);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(85, 23);
            this.btnGravar.TabIndex = 13;
            this.btnGravar.Text = "&Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // lnkInbox
            // 
            this.lnkInbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkInbox.AutoSize = true;
            this.lnkInbox.Location = new System.Drawing.Point(816, 430);
            this.lnkInbox.Name = "lnkInbox";
            this.lnkInbox.Size = new System.Drawing.Size(33, 13);
            this.lnkInbox.TabIndex = 14;
            this.lnkInbox.TabStop = true;
            this.lnkInbox.Text = "Inbox";
            this.lnkInbox.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkInbox_LinkClicked);
            // 
            // frmTarefas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 508);
            this.Controls.Add(this.lnkInbox);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.dgvPendencias);
            this.Controls.Add(this.txtAnotacoes);
            this.Controls.Add(this.lnkConfig);
            this.Controls.Add(this.lnkProjetos);
            this.Controls.Add(this.dgvTarefas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(569, 508);
            this.Name = "frmTarefas";
            this.Text = "Gerenciamento de Tarefas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTarefas_KeyDown);
            this.Controls.SetChildIndex(this.lblFiltro, 0);
            this.Controls.SetChildIndex(this.txtFiltro, 0);
            this.Controls.SetChildIndex(this.dgvTarefas, 0);
            this.Controls.SetChildIndex(this.lnkProjetos, 0);
            this.Controls.SetChildIndex(this.lnkConfig, 0);
            this.Controls.SetChildIndex(this.txtAnotacoes, 0);
            this.Controls.SetChildIndex(this.dgvPendencias, 0);
            this.Controls.SetChildIndex(this.btnGravar, 0);
            this.Controls.SetChildIndex(this.lnkInbox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarefas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTarefas;
        private System.Windows.Forms.LinkLabel lnkProjetos;
        private System.Windows.Forms.LinkLabel lnkConfig;
        private System.Windows.Forms.TextBox txtAnotacoes;
        private System.Windows.Forms.DataGridView dgvPendencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPendenciasId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPendenciasConcluido;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPendenciasDescricao;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.LinkLabel lnkInbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResponsavel;
        private System.Windows.Forms.DataGridViewComboBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPrioridade;
        private CalendarColumn colPrazo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtPendencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnotacoes;
        private System.Windows.Forms.DataGridViewImageColumn colAddAnotacao;
        private System.Windows.Forms.ToolTip toolTip1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn colPrazo;
    }
}