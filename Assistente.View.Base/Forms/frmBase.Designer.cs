namespace Assistente.View.Base.Forms
{
    public partial class frmBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBase));
            this.tstComandos = new System.Windows.Forms.ToolStrip();
            this.tsbNovo = new System.Windows.Forms.ToolStripButton();
            this.tsbSalvar = new System.Windows.Forms.ToolStripButton();
            this.tsbExcluir = new System.Windows.Forms.ToolStripButton();
            this.tsbConfirmar = new System.Windows.Forms.ToolStripButton();
            this.tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this.tsbLimpar = new System.Windows.Forms.ToolStripButton();
            this.tsbProcurar = new System.Windows.Forms.ToolStripButton();
            this.tsbFiltros = new System.Windows.Forms.ToolStripButton();
            this.tsbExcel = new System.Windows.Forms.ToolStripButton();
            this.tssSepSair = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSair = new System.Windows.Forms.ToolStripButton();
            this.tslTitulo = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tstComandos.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tstComandos
            // 
            this.tstComandos.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tstComandos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNovo,
            this.tsbSalvar,
            this.tsbExcluir,
            this.tsbConfirmar,
            this.tsbCancelar,
            this.tsbLimpar,
            this.tsbProcurar,
            this.tsbFiltros,
            this.tsbExcel,
            this.tssSepSair,
            this.tsbSair,
            this.tslTitulo});
            this.tstComandos.Location = new System.Drawing.Point(0, 0);
            this.tstComandos.Name = "tstComandos";
            this.tstComandos.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tstComandos.Size = new System.Drawing.Size(321, 25);
            this.tstComandos.TabIndex = 0;
            this.tstComandos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Soltar_MouseDown);
            this.tstComandos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mover_MouseMove);
            // 
            // tsbNovo
            // 
            this.tsbNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNovo.Image = global::Assistente.View.Base.Properties.Resources._new;
            this.tsbNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNovo.Name = "tsbNovo";
            this.tsbNovo.Size = new System.Drawing.Size(23, 22);
            this.tsbNovo.Text = "&Novo";
            this.tsbNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.tsbNovo.Visible = false;
            this.tsbNovo.Click += new System.EventHandler(this.Novo);
            // 
            // tsbSalvar
            // 
            this.tsbSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSalvar.Image = global::Assistente.View.Base.Properties.Resources.floppy_disk_blue;
            this.tsbSalvar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalvar.Name = "tsbSalvar";
            this.tsbSalvar.Size = new System.Drawing.Size(23, 22);
            this.tsbSalvar.Text = "&Salvar";
            this.tsbSalvar.Visible = false;
            this.tsbSalvar.Click += new System.EventHandler(this.Salvar);
            // 
            // tsbExcluir
            // 
            this.tsbExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExcluir.Image = global::Assistente.View.Base.Properties.Resources.deletered;
            this.tsbExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExcluir.Name = "tsbExcluir";
            this.tsbExcluir.Size = new System.Drawing.Size(23, 22);
            this.tsbExcluir.Text = "&Excluir";
            this.tsbExcluir.Visible = false;
            this.tsbExcluir.Click += new System.EventHandler(this.Excluir);
            // 
            // tsbConfirmar
            // 
            this.tsbConfirmar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbConfirmar.Image = global::Assistente.View.Base.Properties.Resources.v_cinza;
            this.tsbConfirmar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConfirmar.Name = "tsbConfirmar";
            this.tsbConfirmar.Size = new System.Drawing.Size(23, 22);
            this.tsbConfirmar.Text = "Confirmar";
            this.tsbConfirmar.Visible = false;
            this.tsbConfirmar.Click += new System.EventHandler(this.Confirmar);
            // 
            // tsbCancelar
            // 
            this.tsbCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCancelar.Image = global::Assistente.View.Base.Properties.Resources.stop__2_;
            this.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancelar.Name = "tsbCancelar";
            this.tsbCancelar.Size = new System.Drawing.Size(23, 22);
            this.tsbCancelar.Text = "Cancelar";
            this.tsbCancelar.Visible = false;
            this.tsbCancelar.Click += new System.EventHandler(this.Cancelar);
            // 
            // tsbLimpar
            // 
            this.tsbLimpar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLimpar.Image = global::Assistente.View.Base.Properties.Resources.clean;
            this.tsbLimpar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLimpar.Name = "tsbLimpar";
            this.tsbLimpar.Size = new System.Drawing.Size(23, 22);
            this.tsbLimpar.Text = "Limpar";
            this.tsbLimpar.Visible = false;
            this.tsbLimpar.Click += new System.EventHandler(this.Limpar);
            // 
            // tsbProcurar
            // 
            this.tsbProcurar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbProcurar.Image = ((System.Drawing.Image)(resources.GetObject("tsbProcurar.Image")));
            this.tsbProcurar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProcurar.Name = "tsbProcurar";
            this.tsbProcurar.Size = new System.Drawing.Size(23, 22);
            this.tsbProcurar.Text = "Procurar";
            this.tsbProcurar.Visible = false;
            this.tsbProcurar.Click += new System.EventHandler(this.Procurar);
            // 
            // tsbFiltros
            // 
            this.tsbFiltros.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFiltros.Image = ((System.Drawing.Image)(resources.GetObject("tsbFiltros.Image")));
            this.tsbFiltros.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFiltros.Name = "tsbFiltros";
            this.tsbFiltros.Size = new System.Drawing.Size(23, 22);
            this.tsbFiltros.Text = "Filtros";
            this.tsbFiltros.Visible = false;
            this.tsbFiltros.Click += new System.EventHandler(this.Filtros);
            // 
            // tsbExcel
            // 
            this.tsbExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExcel.Image = global::Assistente.View.Base.Properties.Resources.Excel_icon;
            this.tsbExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExcel.Name = "tsbExcel";
            this.tsbExcel.Size = new System.Drawing.Size(23, 22);
            this.tsbExcel.Text = "Excel";
            this.tsbExcel.Visible = false;
            this.tsbExcel.Click += new System.EventHandler(this.Excel);
            // 
            // tssSepSair
            // 
            this.tssSepSair.Name = "tssSepSair";
            this.tssSepSair.Size = new System.Drawing.Size(6, 25);
            this.tssSepSair.Visible = false;
            // 
            // tsbSair
            // 
            this.tsbSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSair.Image = global::Assistente.View.Base.Properties.Resources.application_exit;
            this.tsbSair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSair.Name = "tsbSair";
            this.tsbSair.Size = new System.Drawing.Size(23, 22);
            this.tsbSair.Text = "Sair";
            this.tsbSair.Click += new System.EventHandler(this.Sair);
            // 
            // tslTitulo
            // 
            this.tslTitulo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslTitulo.Name = "tslTitulo";
            this.tslTitulo.Size = new System.Drawing.Size(38, 22);
            this.tslTitulo.Text = "Título";
            this.tslTitulo.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStatus,
            this.tssStatus});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 132);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(321, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Soltar_MouseDown);
            this.statusStrip1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mover_MouseMove);
            // 
            // tslStatus
            // 
            this.tslStatus.Name = "tslStatus";
            this.tslStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // tssStatus
            // 
            this.tssStatus.Name = "tssStatus";
            this.tssStatus.Size = new System.Drawing.Size(16, 17);
            this.tssStatus.Text = "   ";
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 154);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tstComandos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Soltar_MouseDown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFechando);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Mover_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBase_KeyDown);
            this.tstComandos.ResumeLayout(false);
            this.tstComandos.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip tstComandos;
        public System.Windows.Forms.ToolStripButton tsbNovo;
        public System.Windows.Forms.ToolStripButton tsbExcluir;
        public System.Windows.Forms.ToolStripButton tsbSalvar;
        public System.Windows.Forms.ToolStripSeparator tssSepSair;
        public System.Windows.Forms.ToolStripButton tsbSair;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
        protected System.Windows.Forms.ToolStripLabel tslTitulo;
        private System.Windows.Forms.ToolStripButton tsbProcurar;
        private System.Windows.Forms.ToolStripButton tsbConfirmar;
        private System.Windows.Forms.ToolStripButton tsbCancelar;
        public System.Windows.Forms.ToolStripStatusLabel tssStatus;
        protected System.Windows.Forms.ToolStripButton tsbFiltros;
        private System.Windows.Forms.ToolStripButton tsbLimpar;
        private System.Windows.Forms.ToolStripButton tsbExcel;
    }
}

