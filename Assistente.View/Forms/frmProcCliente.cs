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
    public partial class frmProcCliente : frmPCliente
    {
        public frmProcCliente()
        {
            InitializeComponent();
            tslTitulo.Text = "Projetos";
            ExibirBotoes(Botoes.Excluir);
        }

        public override void CarregarGrade()
        {
            base.CarregarGrade();
            CarregarEntidades();
            dgvProc.Rows.Clear();
            foreach (var item in entidades)
            {
                object[] obj = { item.Id.ToString(), item.Codigo.ToString(), 
                                     item.Nome == null ? "" : item.Nome};
                dgvProc.Rows.Add(obj);
            }
            txtFiltro_TextChanged(null, null);
        }
        public override void Novo(object sender, EventArgs e)
        {
            base.Novo(sender, e);
            frmCadCliente lfrmCad = new frmCadCliente();
            lfrmCad.Carregar(this);
        }
        protected override void CarregarEntidades()
        {
            if (trataFiltros != null && trataFiltros.filtroUtilizado)
                entidades = Conexao.TrataDAO.getAcesso<Projeto>().Retorna_pFiltros(trataFiltros.Filtros);
            else
                entidades = Conexao.TrataDAO.getAcesso<Projeto>().Retorna(x => x.Inativo == false);//(byte)CheckState.Unchecked);
        }
        private void dgvProc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && tipoTela == TipoTela.Cadastro)
                {
                    frmCadCliente lfrmCad = new frmCadCliente();
                    lfrmCad.Carregar(int.Parse(dgvProc.Rows[e.RowIndex].Cells[colId.Index].Value.ToString()), this);
                }
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private void dgvProc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgvTemp = (DataGridView)sender;
                if (!String.IsNullOrEmpty(dgvTemp.CurrentRow.Cells[colNome.Index].Value.ToString().Trim()))
                {
                    Projeto clie = Conexao.TrataDAO.getAcesso<Projeto>().
                        Retorna_pId(int.Parse(dgvTemp.CurrentRow.Cells[colId.Index].Value.ToString()));

                    if (clie == null)
                        return;
                    clie.Nome = dgvTemp.CurrentRow.Cells[colNome.Index].Value.ToString().Trim();
                    CarregarGrade();
                }
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }
        //public override void Excluir(object sender, EventArgs e)
        //{
        //    if (dgvProc.CurrentRow!= null)
        //    {
        //        Cliente clie = Conexao.TrataDAO.getAcesso<Cliente>().
        //            Retorna_pId(int.Parse(dgvProc.CurrentRow.Cells[colId.Index].Value.ToString()));
        //        if (clie == null || MessageBox.Show("Deseja realmente exluir item?", "Confirmação de Exclusão",
        //                MessageBoxButtons.YesNo,MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)== DialogResult.No)
        //            return;

        //        Conexao.TrataDAO.getAcesso<Cliente>().Excluir(clie);
        //        CarregarGrade();
        //    }
        //}
        protected override void CarregarFiltros()
        {
            if (trataFiltros != null) return;
            trataFiltros = new Assistente.Entidades.Filtros.TrataFiltros();

            trataFiltros.IncluirFiltroNumInteiro(typeof(Projeto).GetProperty("Codigo"), TipoProcura.Exato, "Código", 0, 0, 0, 0);
            trataFiltros.IncluirFiltroTexto(typeof(Projeto).GetProperty("Nome"), PosicaoProcura.Qualquer, "Nome", "", "");
            trataFiltros.IncluirFiltroCheckbox(typeof(Projeto).GetProperty("Inativo"), "Encerrado", (byte)CheckState.Unchecked, (byte)CheckState.Unchecked);
        }
    }
    public partial class frmPCliente : frmProcBase<Projeto> { }

}
