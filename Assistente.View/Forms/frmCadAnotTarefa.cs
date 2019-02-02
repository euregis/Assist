using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Assistente.Entidades;
using Assistente.View.Base.Forms;
using Assistente.Controle;
using Assistente.Negocio;
using Assistente.Excecoes;

namespace Assistente.View.Forms
{
    public partial class frmCadAnotTarefa : frmCTarefa
    {
        private bool dadosValidados;
        public frmCadAnotTarefa()
            : base()
        {
            try
            {
                tslTitulo.Text = "Cadastro de Tarefa";
                InitializeComponent();
                Controle.WinControls.CarregaComboEnum<enuStatusTarefa>(ref cboStatus, false);
                txtResponsavel.Focus();
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }
        public override bool PreencherObjeto()
        {
            if (entidade.Id == 0)
            {
                entidade.Codigo = Conexao.TrataDAO.getAcessoUtil().NovoCodigo<Tarefa>();
                entidade.DataCadastro = DateTime.Now;
            }
            else
                entidade.Codigo = int.Parse(mtbCodigo.Text.Trim());
            entidade.Responsavel = txtResponsavel.Text.Trim();
            entidade.Status = (short)(int)cboStatus.SelectedValue;
            entidade.Anotacoes += "\r\n\r\n[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "]\r\n" + txtAnotações.Text;
            entidade.Anotacoes = entidade.Anotacoes.Trim();
            return true;
        }
        public override bool PreencherCampos()
        {
            base.PreencherCampos();
            mtbCodigo.Text = entidade.Codigo.ToString();
            txtDescricao.Text = entidade.Descricao;
            txtResponsavel.Text = entidade.Responsavel;
            cboStatus.SelectedValue = entidade.Status > 0 ? (enuStatusTarefa)entidade.Status : enuStatusTarefa.Aguardando;
            txtAnotações.Text = "";
            
            /*if (entidade.Id > 0 && Conexao.TrataDAO.getHorario().Retorna_pTarefa(entidade).Count > 0)
                OcultarBotoes(Botoes.Excluir);
            else
                ExibirBotoes(Botoes.Excluir);*/
            return true;
        }

        protected override bool DadosValidos()
        {
            //bool ret = true;
            Validacoes = new List<Validacao>();
            AddValidacao("Validação da Descrição", txtDescricao.Text, txtDescricao, lblDescricao, TipoValidacao.Preenchido);
            AddValidacao("Validação da Anotação", txtAnotações.Text, txtAnotações, lblDescricao, TipoValidacao.Preenchido);
            //AddValidacao("Validação do Valor", txtValor.Text, txtValor, lblValor, (TipoValidacao)cboFormato.SelectedValue);
            dadosValidados = base.DadosValidos();
            return dadosValidados;
            //Validacoes.Add(new Assistente.Negocio.Validacao(){ 
            //ret = ret && Negocio.Util.Validador.FormatoValido((TipoValidacao)entidade.Validacao, entidade.Valor);
            //lobjRow 
            //return ret;
        }
        public override void Salvar(object sender, EventArgs e)
        {
            base.Salvar(sender, e);
            if (dadosValidados) this.Sair(sender, e); 
        }
       
    }
    public partial class frmCTarefa : frmCadBase<Tarefa> { }
    
}
