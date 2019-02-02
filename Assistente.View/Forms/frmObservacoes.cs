using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Assistente.Entidades;
using Assistente.Controle;
using Assistente.Excecoes;

namespace Assistente.View.Forms
{
    public partial class frmObservacoes : Base.Forms.frmBase
    {
        private string descricaoPend = "";
        private bool carregandoDescr = false;
        Tarefa mobjTarefa = null;

        public frmObservacoes()
        {
            InitializeComponent();
            tslTitulo.Text = "Descrição do Horário";
            ExibirBotoes(Botoes.Confirmar);
            OcultarBotoes(Botoes.Sair);
        }
        public string Carregar(string vstrObserv, Tarefa vobjTarefa)
        {
            txtObservacao.Text = vstrObserv;
            this.mobjTarefa = vobjTarefa;
            CarregarPendencias();
            txtObservacao.SelectAll();
            Carregar(true);
            return txtDescricaoHorario.Text;
        }
        protected override void Confirmar(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtDescricaoHorario.Text.Trim()))
                {
                    MessageBox.Show("Informe uma descrição para o novo horário.", "Horário",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.Sair(sender, e);
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }
        private void CarregarPendencias()
        {
            dgvPendencias.Rows.Clear();

            IList<Pendencia> pendencias = Conexao.TrataDAO.getAcesso<Pendencia>().Retorna(x => x.Tarefa == mobjTarefa);

            foreach (var item in pendencias)
            {
                if (item.DataConclusao == null)
                {
                    CheckState cs = CheckState.Unchecked;
                    if (item.Descricao == txtObservacao.Text ||
                        (txtObservacao.Text.Contains(" (") &&
                        item.Descricao == txtObservacao.Text.Substring(0, txtObservacao.Text.IndexOf(" ("))))
                        cs = CheckState.Checked;
                    Object[] pendencia = { cs, item.Descricao };
                    dgvPendencias.Rows.Add(pendencia);
                }
            }
            //if (pendencias.Count > 4) colPendenciasDescricao.Width = 241;
            //else colPendenciasDescricao.Width = 216;

        }

        private void dgvPendencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                descricaoPend = "";
                txtObservacao.Text = "";
                foreach (DataGridViewRow item in dgvPendencias.Rows)
                {
                    if (item != dgvPendencias.CurrentRow)
                    {
                        if (!System.Convert.ToBoolean(dgvPendencias.CurrentRow.Cells[colPendenciasConcluido.Index].Value)
                          && System.Convert.ToBoolean(item.Cells[colPendenciasConcluido.Index].Value))
                        {
                            item.Cells[colPendenciasConcluido.Index].Value = CheckState.Unchecked;
                            if (item.Cells[colPendenciasDescricao.Index].Value.ToString() == txtObservacao.Text ||
                                        (txtObservacao.Text.Contains(" (") &&
                                        item.Cells[colPendenciasDescricao.Index].Value.ToString() == txtObservacao.Text.Substring(0, txtObservacao.Text.IndexOf(" ("))))
                                txtObservacao.Text = "";
                        }
                    }
                    else if (System.Convert.ToBoolean(item.Cells[colPendenciasConcluido.Index].EditedFormattedValue))
                    {
                        descricaoPend = item.Cells[colPendenciasDescricao.Index].Value.ToString().Trim();
                    }
                }
                CarregarDescricao();
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private void CarregarDescricao()
        {
            if (!carregandoDescr)
            {
                carregandoDescr = true;

                if (descricaoPend.Length > 0)
                {
                    txtDescricaoHorario.Text = descricaoPend;
                    if (txtObservacao.Text.Trim().Length > 0)
                        txtDescricaoHorario.Text += " (" + txtObservacao.Text.Trim() + ")";

                }
                else if (txtObservacao.Text.Trim().Length > 0)
                    txtDescricaoHorario.Text = txtObservacao.Text.Trim();
                else
                    txtDescricaoHorario.Text = "";

                carregandoDescr = false;
            }
        }

        private void txtObservacao_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CarregarDescricao();
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private void txtDescricaoHorario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CarregarDescricao();
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

    }
}
