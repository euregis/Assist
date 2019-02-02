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
using Assistente.View.Base.Forms;
using Assistente.Negocio;
using Assistente.Entidades.Filtros;
using Assistente.Excecoes;

namespace Assistente.View.Forms
{
    public partial class frmProcConfiguracao : frmPConfiguracao
    {
        public frmProcConfiguracao()
        {
            InitializeComponent();
            OcultarBotoes(Botoes.Novo);
            tslTitulo.Text = "Configurações";
        }
        public override void CarregarGrade()
        {
            base.CarregarGrade();
            CarregarEntidades();
            dgvProc.Rows.Clear();
            foreach (var item in entidades)
            {
                object[] obj = { item.Id.ToString(), item.Codigo.ToString(), 
                                     item.Descricao == null ? "" : item.Descricao, 
                                     Negocio.Util.TrataEnum.ObterDescricao((TipoValidacao) item.Validacao), 
                                     item.Valor };
                dgvProc.Rows.Add(obj);
            }
        }

        //private void txtFiltro_TextChanged(object sender, EventArgs e)
        //{
        //    bool contem=false;
        //    string[] filtros = txtFiltro.Text.Trim().Split(' ');
        //    foreach (DataGridViewRow itemR in dgvProc.Rows)
        //    {
        //        foreach (var filtro in filtros)
        //        {
        //            contem = false;
        //            foreach (DataGridViewCell itemC in itemR.Cells)
        //            {
        //                if (itemC.OwningColumn.Visible)
        //                {
        //                    if (itemC.Value.ToString().Contains(filtro))
        //                    {
        //                        contem = true;
        //                        break;
        //                    }
        //                    if (contem) break;
        //                }
        //            }
        //        }
        //        itemR.Visible = contem;
        //    }
        //}

        public override void Novo(object sender, EventArgs e)
        {
            try
            {
                base.Novo(sender, e);
                frmCadConfiguracao lfrmCad = new frmCadConfiguracao();
                lfrmCad.Carregar(this);
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private void dgvProc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    frmCadConfiguracao lfrmCad = new frmCadConfiguracao();
                    lfrmCad.Carregar(int.Parse(dgvProc.Rows[e.RowIndex].Cells[colId.Index].Value.ToString()), this);
                }
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private void dgvConfiguracoes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgvTemp = (DataGridView)sender;
                if (!String.IsNullOrEmpty(dgvTemp.CurrentRow.Cells[colDescricao.Index].Value.ToString().Trim())
                    && !String.IsNullOrEmpty(dgvTemp.CurrentRow.Cells[colValor.Index].Value.ToString().Trim()))
                {
                    Configuracao config = Conexao.TrataDAO.getAcesso<Configuracao>().
                        Retorna_pId(int.Parse(dgvTemp.CurrentRow.Cells[colId.Index].Value.ToString()));

                    if (config == null)
                        return;

                    config.Descricao = dgvTemp.CurrentRow.Cells[colDescricao.Index].Value.ToString().Trim();
                    config.Valor = dgvTemp.CurrentRow.Cells[colValor.Index].Value.ToString().Trim();

                    //if (Assistente.Negocio.Util.Validacao.FormatoValido(config.Valor, config.Formato))
                    //    Conexao.TrataDAO.getAcesso<Configuracao>().Salvar(config);

                    CarregarGrade();
                }
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }
        protected override void CarregarFiltros()
        {
            if (trataFiltros != null) return;
            trataFiltros = new Assistente.Entidades.Filtros.TrataFiltros();

            trataFiltros.IncluirFiltroNumInteiro(typeof(Configuracao).GetProperty("Codigo"), TipoProcura.Exato, "Código", "", "", "", "");
            trataFiltros.IncluirFiltroTexto(typeof(Configuracao).GetProperty("Descricao"), PosicaoProcura.Qualquer, "Descrição", "", "");

        }
    }
    public partial class frmPConfiguracao : frmProcBase<Configuracao> { }

}