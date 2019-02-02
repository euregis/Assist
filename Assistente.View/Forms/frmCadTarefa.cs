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
    public partial class frmCadTarefa : frmCTarefa
    {
        public frmCadTarefa()
            : base()
        {
            try
            {
                tslTitulo.Text = "Cadastro de Tarefa";
                InitializeComponent();
                Controle.WinControls.CarregaComboEnum<enuStatusTarefa>(ref cboStatus, false);
                Controle.WinControls.CarregaComboEnum<enuPrioridadeTarefa>(ref cboPrioridade, false);
                Controle.WinControls.CarregaComboEnum<enuCategoriaTarefa>(ref cboCategoria, false);
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }
        public override bool PreencherObjeto()
        {
            string anot = null;
            Tarefa tarOld = null;

            if (entidade.Id == 0)
            {
                entidade.Codigo = Conexao.TrataDAO.getAcessoUtil().NovoCodigo<Tarefa>();
                entidade.DataCadastro = DateTime.Now;
            }
            else
            {
                tarOld = Negocio.Geral.Clonar( Conexao.TrataDAO.getTarefa().Retorna_pId(entidade.Id));
                entidade.Codigo = int.Parse(mtbCodigo.Text.Trim());
            }
            entidade.Descricao = txtDescricao.Text.Trim();
            entidade.Cliente = txtCliente.Tag != null
                    && txtCliente.Tag.ToString() != "" && txtCliente.Tag.ToString() != "0" ?
                Conexao.TrataDAO.getCliente().Retorna_pId(int.Parse(txtCliente.Tag.ToString())) : null;
            entidade.Solicitante = txtSolicitante.Text.Trim();
            entidade.Responsavel = txtResponsavel.Text.Trim();
            entidade.Status = (short)(int)cboStatus.SelectedValue;
            entidade.Prioridade = (short)(int)cboPrioridade.SelectedValue;
            entidade.Categoria = (short)(int)cboCategoria.SelectedValue;
            if (entidade.Id == 0) entidade.DataCadastro = DateTime.Now;
            entidade.PrazoTermino = dtpPrazoTermino.Checked ? dtpPrazoTermino.Value.Date : (DateTime?)null;
            entidade.DataTermino = dtpDataTermino.Checked ? dtpDataTermino.Value.Date : (DateTime?)null;

            if (entidade.Id != 0)
                anot = Negocio.Geral.ObtemMudancas(tarOld, entidade);

            if (anot != null)
                anot = "[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "]\r\n" 
                    + anot + "\r\n\r\n" + txtAnotações.Text.Trim();
            else
                anot = txtAnotações.Text.Trim();

            entidade.Anotacoes = anot;
            
            return true;
        }
        public override bool PreencherCampos()
        {
            base.PreencherCampos();
            mtbCodigo.Text = entidade.Codigo.ToString();
            txtDescricao.Text = entidade.Descricao;
            if (entidade.Cliente != null)
            {
                txtCliente.Text = entidade.Cliente.Codigo.ToString() + " - " + entidade.Cliente.Nome;
                txtCliente.Tag = entidade.Cliente.Id;
            }
            else
            {
                txtCliente.Text = "";
                txtCliente.Tag = "0";
            }
            txtSolicitante.Text = entidade.Solicitante;
            txtResponsavel.Text = entidade.Responsavel;
            cboStatus.SelectedValue = entidade.Status > 0 ? (enuStatusTarefa)entidade.Status : enuStatusTarefa.Aguardando;
            cboPrioridade.SelectedValue = entidade.Prioridade > 0 ? (enuPrioridadeTarefa)entidade.Prioridade : enuPrioridadeTarefa.Normal;
            cboCategoria.SelectedValue = entidade.Categoria > 0 ? (enuCategoriaTarefa)entidade.Categoria : enuCategoriaTarefa.Indefinida;
            if (entidade.Id == 0) entidade.DataCadastro = DateTime.Now;
            if (entidade.PrazoTermino != null) { dtpPrazoTermino.Checked = true; dtpPrazoTermino.Value = (DateTime)entidade.PrazoTermino; }
            else dtpPrazoTermino.Checked = false;

            if (entidade.DataTermino != null) { dtpDataTermino.Checked = true; dtpDataTermino.Value = (DateTime)entidade.DataTermino; }
            else dtpDataTermino.Checked = false;

            txtAnotações.Text = entidade.Anotacoes;
            //chkInativo.Checked =entidade.Inativo;
            CarregarPendencias();
            CarregarPastas();
            ExibirBotoes(Botoes.Excluir);
            return true;
        }

        protected override bool DadosValidos()
        {
            //bool ret = true;
            Validacoes = new List<Validacao>();
            AddValidacao("Validação da Descrição", txtDescricao.Text, txtDescricao, lblDescricao, TipoValidacao.Preenchido);
            //AddValidacao("Validação do Valor", txtValor.Text, txtValor, lblValor, (TipoValidacao)cboFormato.SelectedValue);

            return base.DadosValidos();
            //Validacoes.Add(new Assistente.Negocio.Validacao(){ 
            //ret = ret && Negocio.Util.Validador.FormatoValido((TipoValidacao)entidade.Validacao, entidade.Valor);
            //lobjRow 
            //return ret;
        }

        private void CarregarPastas()
        {
            try
            {
                dgvPastas.Rows.Clear();
                if (entidade.Id == 0) return;
            
                dgvPastas.Rows.Add("0", "", "");
                foreach (var item in Conexao.TrataDAO.getAcesso<Pasta>()
                    .Retorna(x => x.Tarefa == entidade && x.Ambiente == Geral.AmbienteLocal))
                {
                    String[] pasta = { item.Id.ToString(), item.Caminho, item.Descricao };

                    dgvPastas.Rows.Add(pasta);
                }
            }
            catch (Exception) { }
        }
        private void CarregarPendencias()
        {
            try
            {
                //carregando = true;
                dgvPendencias.Rows.Clear();
                if (entidade.Id == 0) return;

                dgvPendencias.Rows.Add(0, CheckState.Unchecked, "", new DataGridViewButtonCell());
                foreach (var item in Conexao.TrataDAO.getAcesso<Pendencia>().Retorna(x => x.Tarefa == entidade).OrderBy(x => x.DataConclusao))
                {
                    Object[] pendencia = { item.Id, item.DataConclusao == null ? CheckState.Unchecked : CheckState.Checked, item.Descricao, new DataGridViewButtonCell() };

                    dgvPendencias.Rows.Add(pendencia);
                }
                //if (tarefa.Pendencias.Count > 4) colPendenciasDescricao.Width = 241;
                //else colPendenciasDescricao.Width = 258;
                //carregando = false;
            }
            catch (Exception) { }
        }
        private void dgvPendencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgvTemp = (DataGridView)sender;
                if (int.Parse(dgvTemp[colPendenciasId.Index, e.RowIndex].Value.ToString()) > 0
                    && e.ColumnIndex == colPendenciasConcluido.Index)
                {
                    Pendencia pendencia = Conexao.TrataDAO.getAcesso<Pendencia>().Retorna_pId(int.Parse(dgvTemp[colPendenciasId.Index, e.RowIndex].Value.ToString()));

                    if (pendencia != null)
                    {
                        if (System.Convert.ToBoolean(dgvTemp.CurrentRow.Cells[colPendenciasConcluido.Index].Value))
                            pendencia.DataConclusao = null;
                        else
                            pendencia.DataConclusao = DateTime.Now;
                        Conexao.TrataDAO.getAcesso<Pendencia>().Salvar(pendencia);
                    }
                }
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private void dgvPendencias_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgvTemp = (DataGridView)sender;
                if (dgvTemp[colPendenciasDescricao.Index, e.RowIndex].Value != null 
                    && !string.IsNullOrEmpty( dgvTemp[colPendenciasDescricao.Index, e.RowIndex].Value.ToString().Trim()))
                {
                    Pendencia pendencia = Conexao.TrataDAO.getAcesso<Pendencia>().Retorna_pId(int.Parse(dgvTemp[colPendenciasId.Index, e.RowIndex].Value.ToString()));

                    if (pendencia == null)
                    {
                        pendencia = new Pendencia();
                        pendencia.DataCadastro = DateTime.Now;
                        if ((CheckState)dgvTemp[colPendenciasConcluido.Index, e.RowIndex].Value == CheckState.Unchecked)
                            pendencia.DataConclusao = null;
                        else
                            pendencia.DataConclusao = DateTime.Now;
                    }

                    pendencia.Descricao = dgvTemp[colPendenciasDescricao.Index, e.RowIndex].Value.ToString().Trim();

                    pendencia.Tarefa = entidade;
                    if (pendencia.Tarefa != null)
                        pendencia.Tarefa.AddPendencia(pendencia);
                    Conexao.TrataDAO.getAcesso<Pendencia>().Salvar(pendencia);
                    CarregarPendencias();
                }
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private void dgvPendencias_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (((DataGridView)sender).CurrentCell != null && 
                    ((DataGridView)sender).CurrentCell.IsInEditMode == false && e.KeyCode == Keys.Delete)
                {
                    Pendencia pendencia = Conexao.TrataDAO.getAcesso<Pendencia>().Retorna_pId(int.Parse(((DataGridView)sender).CurrentRow.Cells[colPendenciasId.Index].Value.ToString()));
                    if (pendencia != null)
                    {
                        entidade.Pendencias.Remove(pendencia);
                        Conexao.TrataDAO.getAcesso<Pendencia>().Excluir(pendencia);
                        CarregarPendencias();
                    }
                }
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private void dgvPastas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgvTemp = (DataGridView)sender;
                if (!String.IsNullOrEmpty(dgvTemp.CurrentRow.Cells[colPastasCaminho.Index].Value.ToString().Trim())
                    && !String.IsNullOrEmpty(dgvTemp.CurrentRow.Cells[colPastasDescricao.Index].Value.ToString().Trim()))
                {
                    Pasta pasta = Conexao.TrataDAO.getAcesso<Pasta>().Retorna_pId(int.Parse(dgvTemp.CurrentRow.Cells[colPastasId.Index].Value.ToString()));

                    if (pasta == null)
                        pasta = new Pasta();

                    pasta.Caminho = dgvTemp.CurrentRow.Cells[colPastasCaminho.Index].Value.ToString().Trim();
                    pasta.Descricao = dgvTemp.CurrentRow.Cells[colPastasDescricao.Index].Value.ToString().Trim();
                    pasta.Tarefa = entidade;
                    if (pasta.Tarefa != null)
                        pasta.Tarefa.AddPasta(pasta);
                    pasta.Ambiente = Geral.AmbienteLocal;
                    Conexao.TrataDAO.getAcesso<Pasta>().Salvar(pasta);
                    CarregarPastas();
                }
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private void dgvPastas_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (((DataGridView)sender).CurrentCell != null && 
                    ((DataGridView)sender).CurrentCell.IsInEditMode == false && e.KeyCode == Keys.Delete)
                {
                    Pasta pasta = Conexao.TrataDAO.getAcesso<Pasta>().Retorna_pId(int.Parse(((DataGridView)sender).CurrentRow.Cells[colPastasId.Index].Value.ToString()));
                    if (pasta != null)
                    {
                        entidade.Pastas.Remove(pasta);
                        Conexao.TrataDAO.getAcesso<Pasta>().Excluir(pasta);
                        CarregarPastas();
                    }
                }
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private void txtCliente_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCliente.Text.Trim().Length > 0)
                    entidade.Cliente = new frmProcCliente().Carregar(txtCliente.Text.Trim());
                if (entidade.Cliente != null)
                {
                    txtCliente.Tag = entidade.Cliente.Id;
                    txtCliente.Text = "" + entidade.Cliente.Codigo + " - " + entidade.Cliente.Nome;
                }
                else
                {
                    txtCliente.Tag = null;
                    txtCliente.Text = "";
                }
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmCadCliente lfrmCad = new frmCadCliente();
            lfrmCad.Carregar(true);
        }
    }
    public partial class frmCTarefa : frmCadBase<Tarefa> { }
    
}
