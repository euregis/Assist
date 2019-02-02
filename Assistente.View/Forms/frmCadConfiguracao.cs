using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Assistente.Entidades;
using Assistente.Negocio;
using Assistente.Controle;
using Assistente.Excecoes;
using Assistente.View.Base.Forms;

namespace Assistente.View.Forms
{

    public partial class frmCadConfiguracao : frmCConfiguracao
    {
        public frmCadConfiguracao()
            : base()
        {
            tslTitulo.Text = "Cadastro de Configuração";
            InitializeComponent();
            Controle.WinControls.CarregaComboEnum<TipoValidacao>(ref cboFormato,false);
            OcultarBotoes(Botoes.Novo, Botoes.Excluir);
        }
       
        public override bool PreencherObjeto()
        {
            if (entidade.Id == 0)
                entidade.Codigo = Conexao.TrataDAO.getAcessoUtil().NovoCodigo<Configuracao>();
            else
                entidade.Codigo = int.Parse(mtbCodigo.Text.Trim());
            entidade.Descricao= txtDescricao.Text.Trim();
            entidade.Validacao = (short)(TipoValidacao)cboFormato.SelectedValue;
            entidade.Valor = txtValor.Text;
            return true;
        }
        public override bool PreencherCampos()
        {
            base.PreencherCampos();
            mtbCodigo.Tag= entidade.Id.ToString();
            mtbCodigo.Text = entidade.Codigo.ToString();
            txtDescricao.Enabled = true;
            txtDescricao.Text = entidade.Descricao;
            txtDescricao.Enabled = false;
            cboFormato.Enabled = true;
            cboFormato.SelectedValue=(TipoValidacao)entidade.Validacao;
            if (entidade.Validacao == (short)TipoValidacao.ModoExibicaoAssistente)
            {
                txtValor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtValor.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtValor.AutoCompleteCustomSource.Add(
                     Negocio.Util.TrataEnum.ObterDescricao(ModoExibicaoAssistente.Systray_Compacto));
                txtValor.AutoCompleteCustomSource.Add(
                    Negocio.Util.TrataEnum.ObterDescricao(ModoExibicaoAssistente.SysTray));
                txtValor.AutoCompleteCustomSource.Add(
                    Negocio.Util.TrataEnum.ObterDescricao(ModoExibicaoAssistente.Compacto));
                
            }
            cboFormato.Enabled = false; 
            txtValor.Text = entidade.Valor;
            return true;
        }

        protected override bool DadosValidos()
        {
            //bool ret = true;
            Validacoes = new List<Validacao>();
            AddValidacao("Validação da Descrição", txtDescricao.Text, txtDescricao, lblDescricao, TipoValidacao.Preenchido);
            AddValidacao("Validação do Valor", txtValor.Text, txtValor, lblValor, (TipoValidacao)cboFormato.SelectedValue);

            return base.DadosValidos();
            //Validacoes.Add(new Assistente.Negocio.Validacao(){ 
            //ret = ret && Negocio.Util.Validador.FormatoValido((TipoValidacao)entidade.Validacao, entidade.Valor);
            //lobjRow 
            //return ret;
        }
    }
    public class frmCConfiguracao : frmCadBase<Configuracao> { }
}
