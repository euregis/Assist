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
using Assistente.Entidades;
using Assistente.Negocio;

namespace Assistente.View.Base.Forms
{
    public partial class frmCadBase<T> : frmBase where T : Assistente.Entidades.Base.BaseID
    {
        protected T entidade;
        protected List<Negocio.Validacao> Validacoes = new List<Negocio.Validacao>();

        AssistValidacaoException aVException = null;

        public frmCadBase()
        {
            ExibirBotoes(Botoes.Novo, Botoes.Salvar, Botoes.Excluir, Botoes.SepSair);
            entidade = (T)Activator.CreateInstance(typeof(T));
            InitializeComponent();
        }
        public frmCadBase(string Titulo)
            : this()
        {
            tslTitulo.Text = "Cadastro";
        }
        public virtual void Carregar(int id)
        {
            Abrir(id);
            this.ShowDialog();
            if (entidade != null && entidade.Id > 0)
                entidade = Conexao.TrataDAO.getAcesso<T>().Retorna_pId(entidade.Id);
        }
        public virtual void Carregar(int id, Form formOwner)
        {
            this.Carregar(formOwner);
            Abrir(id);
            if (entidade != null && entidade.Id > 0)
                entidade = Conexao.TrataDAO.getAcesso<T>().Retorna_pId(entidade.Id);
        }
        public override void Carregar(bool showDialog)
        {
            Limpar();
            base.Carregar(showDialog);
        }
        public override void Carregar(Form formOwner)
        {
            Limpar();
            base.Carregar(formOwner);
        }

        protected virtual bool DadosValidos()
        {
            aVException = new AssistValidacaoException();
            //Conexao.TrataDAO.getAcesso<Entidades.Validacao>().
            frmApresValidacoes<T> lfrmValidacoes = new frmApresValidacoes<T>();
            return lfrmValidacoes.Carregar(Validacoes, entidade);
        }
        public virtual bool PreencherObjeto()
        {
            try
            {
                if (entidade == null)
                    entidade = (T)Activator.CreateInstance(typeof(T));
                BarraMensagem("");
                return true;
            }
            catch (Exception ex)
            {
                throw AssistErroException.TratarErro(ex);

            }
        }
        public virtual bool PreencherCampos()
        {
            try
            {
                if (entidade == null)
                    entidade = (T)Activator.CreateInstance(typeof(T));
                BarraMensagem("");
                return true;
            }
            catch (Exception ex)
            {
                throw AssistErroException.TratarErro(ex);
            }
        }

        public virtual bool Abrir(int id)
        {
            if (id > 0)
                entidade = Conexao.TrataDAO.getAcesso<T>().Retorna_pId(id);
            else
                entidade = (T)Activator.CreateInstance(typeof(T));
            PreencherCampos();
            return true;
        }

        public override void Salvar(object sender, EventArgs e)
        {
            try
            {
                PreencherObjeto();
                if (!DadosValidos()) return;
                //Conexao.TrataDAO.getAcesso<T>().Salvar(entidade);
                Abrir(entidade.Id);
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }
        public override void Excluir(object sender, EventArgs e)
        {
            try
            {
                if (entidade.Id >= 0 &&
                    MessageBox.Show("Deseja realmente excluir este registro?", "Excluir", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    if (Conexao.TrataDAO.getAcesso<T>().Excluir(entidade))
                        this.Sair(sender, e);//Limpar();
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));

            }
        }

        public override void Novo(object sender, EventArgs e)
        {
            try
            {
                Limpar();
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        public virtual void Limpar()
        {
            entidade = (T)Activator.CreateInstance(typeof(T));
            PreencherCampos();
        }

        protected void AddValidacao(string vstrDecricao, object vobjValor, object vobjCampo,
                                        object vobjLabel, params TipoValidacao[] vobjTipo)
        {
            Validacao valid = new Validacao
            {
                Ordem = Validacoes.Count + 1,
                Descricao = vstrDecricao,
                Tipos = vobjTipo,
                Status = StatusValidacao.Aguardando,
                Valores = new object[] { vobjValor },
                MsgRetorno = "",
                Campo = vobjCampo,
                Label = vobjLabel
            };

            Validacoes.Add(valid);
        }
        protected void AddValidacao(string vstrDecricao, object vobjCampo,
                                        object vobjLabel, TipoValidacao vobjTipo, params object[] vobjValor)
        {
            Validacao valid = new Validacao
            {
                Ordem = Validacoes.Count + 1,
                Descricao = vstrDecricao,
                Tipos = new TipoValidacao[] { vobjTipo },
                Status = StatusValidacao.Aguardando,
                Valores = vobjValor,
                MsgRetorno = "",
                Campo = vobjCampo,
                Label = vobjLabel
            };

            Validacoes.Add(valid);
        }
        public override void FormFechando(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null && !this.Owner.Visible)
            {
                this.Owner.Visible = true;
                if (this.Owner.GetType().IsSubclassOf(typeof(frmProcBase<T>)))
                    ((frmProcBase<T>)this.Owner).CarregarGrade();
            }
        }    
    }
}
