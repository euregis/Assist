using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Assistente.Controle;
using Assistente.Excecoes;

namespace Assistente.View.Base.Forms
{
    public partial class frmBase : Form
    {
        protected enum Botoes
        {
            [Description("tsbConfirmar")]
            Confirmar,
            [Description("tsbCancelar")]
            Cancelar,
            [Description("tsbProcurar")]
            Procurar,
            [Description("tsbLimpar")]
            Limpar,
            [Description("tsbFiltros")]
            Filtros,
            [Description("tsbExcel")]
            Excel,
            [Description("tsbSalvar")]
            Salvar,
            [Description("tsbExcluir")]
            Excluir,
            [Description("tsbNovo")]
            Novo,
            [Description("tssSepSair")]
            SepSair,
            [Description("tsbSair")]
            Sair
        }
        public frmBase()
        {
            InitializeComponent();
        }

        protected void ExibirBotoes(params Botoes[] botoes)
        {
            try
            {
                VisualizacaoBotoes(true, botoes);
            }
            catch (Exception ex)
            {
                throw AssistErroException.TratarErro(ex);
            }
        }

        protected void OcultarBotoes(params Botoes[] botoes)
        {
            try
            {
                VisualizacaoBotoes(false, botoes);
            }
            catch (Exception ex)
            {
                throw AssistErroException.TratarErro(ex);
            }
        }
        protected void VisualizacaoBotoes(bool exibir, params Botoes[] botoes)
        {
            if (botoes.Count() == 0 || botoes.Count() == Enum.GetNames(typeof(Botoes)).Count())
            {
                foreach (var item in tstComandos.Items)
                    if (item is ToolStripButton)
                        ((ToolStripButton)item).Visible = exibir;
                    else if (item is ToolStripSeparator)
                        ((ToolStripSeparator)item).Visible = exibir;
            }
            else
            {
                foreach (var item in botoes)
                {
                    tstComandos.Items[Negocio.Util.TrataEnum.ObterDescricao(item)].Visible = exibir;
                }
            }
        }
        public void BarraMensagem(string Mensagem)
        {
            try
            {
                tssStatus.Text = Mensagem;
            }
            catch (Exception ex)
            {
                throw AssistErroException.TratarErro(ex);
            }
        }
        private bool TelaAberta() {

            if (Application.OpenForms.Count > 1)
                foreach (var item in Application.OpenForms)
                    if (((Form)item).Name == this.Name
                        && ((Form)item).CompanyName == this.CompanyName)
                    {
                        MessageBox.Show("Esta tela já está sendo utilizada.", "Tela já Aberta");
                        if (((Form)item).Visible) ((Form)item).Activate();

                        return true;
                    }

            return false;
        }
        public virtual void Carregar(bool showDialog)
        {
            try
            {
                if (TelaAberta())   
                    return;
                        
                if (showDialog)
                    this.ShowDialog();
                else
                    this.Show();
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }
        public virtual void Carregar(Form formOwner)
        {
            try
            {
                if (TelaAberta())
                    return;

                this.Owner = formOwner;
                this.Show(); 
                formOwner.Hide();
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        protected struct mv
        {
            public static int X;
            public static int Y;
        }

        protected void Mover_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.Button != MouseButtons.Left) return;
            //this.Left = mv.X + MousePosition.X;
            //this.Top = mv.Y + MousePosition.Y;
            //if (this.Top < 0) this.Top = 0;
            //if (this.Left < 0) this.Left = 0;
        }
        protected void Soltar_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button != MouseButtons.Left) return;
            //mv.X = this.Left - MousePosition.X;
            //mv.Y = this.Top - MousePosition.Y;
        }

        public virtual void Sair(object sender, EventArgs e)
        {
            this.Close();
        }


        public virtual void Salvar(object sender, EventArgs e)
        {
        }
        public virtual void Excluir(object sender, EventArgs e)
        {
        }
        public virtual void Novo(object sender, EventArgs e)
        {
        }

        public virtual void Procurar(object sender, EventArgs e)
        {

        }

        public virtual void Filtros(object sender, EventArgs e)
        {

        }

        protected virtual void Confirmar(object sender, EventArgs e)
        {
        }

        protected virtual void Cancelar(object sender, EventArgs e)
        {
        }

        protected virtual void Limpar(object sender, EventArgs e)
        {

        }

        protected virtual void Excel(object sender, EventArgs e)
        {

        }

        private void frmBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                switch (e.KeyCode)
                {
                    case Keys.E:
                        if (tsbExcluir.Visible)
                            Excluir(null, null);
                        break;
                    case Keys.S:
                        if (tsbSalvar.Visible)
                            Salvar(null, null);
                        break;
                    case Keys.N:
                        if (tsbNovo.Visible)
                            Novo(null, null);
                        break;
                    case Keys.L:
                        if (tsbLimpar.Visible)
                            Limpar(null, null);
                        break;
                    case Keys.Enter:
                        if (tsbConfirmar.Visible)
                            Confirmar(null, null);
                        break;
                    case Keys.Escape:
                        if (tsbCancelar.Visible)
                            Cancelar(null, null);
                        break;
                    case Keys.F:
                        if (tsbFiltros.Visible)
                            Filtros(null, null);
                        break;
                    default:
                        break;
                }

        }

        public virtual void FormFechando(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.None) e.Cancel =true;
            if (this.Owner != null && !this.Owner.Visible)
            {
                this.Owner.Visible = true;
                
                
            }
        }

    }
}
