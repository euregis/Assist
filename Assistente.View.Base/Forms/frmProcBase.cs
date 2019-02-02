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
using Assistente.Entidades.Filtros;

namespace Assistente.View.Base.Forms
{
    public partial class frmProcBase<T> : frmBase where T : Assistente.Entidades.Base.BaseID
    {
        protected TrataFiltros trataFiltros = null;
        protected enum TipoColuna { TextBox, Imagem, Combo }
        protected IList<T> entidades;
        protected bool Erro;

        protected enum TipoTela { Cadastro, Retorno }
        protected TipoTela tipoTela = TipoTela.Cadastro;

        public frmProcBase()
        {
            try
            {
                ExibirBotoes(Botoes.Novo, Botoes.Filtros, Botoes.SepSair);
                entidades = new List<T>();
                InitializeComponent();
                CarregarFiltros();
            }

            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }
        public frmProcBase(string Titulo)
            : this()
        {
            tslTitulo.Text = "Procura";
        }
        public virtual void Carregar()
        {
            Carregar(false);
        }
        public override void Carregar(bool showDialog)
        {
            CarregarGrade();
            base.Carregar(showDialog);
        }
        public virtual T Carregar(string filtro)
        {
            tipoTela = TipoTela.Retorno;
            OcultarBotoes();
            ExibirBotoes(Botoes.Confirmar, Botoes.Cancelar);
            txtFiltro.Text = filtro;
            CarregarGrade();
            txtFiltro_TextChanged(null, null);

            T entidade = EntidadeFiltrada();
            if (entidade != null)
                return entidade;

            base.Carregar(true);

            if (entidades.Count == 1) return entidades[0];
            else return null;
        }
        protected override void Confirmar(object sender, EventArgs e)
        {
            try
            {
                base.Confirmar(sender, e);
                foreach (var item in this.Controls)
                {
                    if (item.GetType() == typeof(DataGridView))
                    {
                        if (((DataGridView)item).SelectedRows.Count == 1)
                        {
                            trataFiltros = new TrataFiltros();
                            trataFiltros.IncluirFiltroNumInteiro(typeof(T).GetProperty("Id"), TipoProcura.Exato, "",
                            ((DataGridView)item).SelectedRows[0].Cells["colId"].Value.ToString(), 0, 0, 0);
                            trataFiltros.Filtros[0].Utilizado = true;
                            entidades = Conexao.TrataDAO.getAcesso<T>().Retorna_pFiltros(trataFiltros.Filtros);
                            this.Sair(sender, e);
                        }
                        else if (((DataGridView)item).SelectedRows.Count == 0)
                            BarraMensagem("Nenhum registro foi selecionado.");
                        else
                            BarraMensagem("Selecione apenas um registro.");
                    }
                }
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
                base.Confirmar(sender, e);
                foreach (var item in this.Controls)
                {
                    if (item.GetType() == typeof(DataGridView))
                    {
                        if (((DataGridView)item).SelectedRows.Count == 1)
                        {
                            T ent = Conexao.TrataDAO.getAcesso<T>().
                    Retorna_pId(int.Parse(((DataGridView)item).CurrentRow.Cells["colId"].Value.ToString()));
                            if (ent == null || MessageBox.Show("Deseja realmente exluir item?", "Confirmação de Exclusão",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                return;

                            Conexao.TrataDAO.getAcesso<T>().Excluir(ent);
                            CarregarGrade();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }
        protected override void Cancelar(object sender, EventArgs e)
        {
            try
            {
                base.Cancelar(sender, e);
                entidades = new List<T>();
                this.Sair(sender, e);
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        protected virtual void CampoFiltro()
        {

        }
        public virtual void CarregarGrade()
        {
            CarregarEntidades();
        }
        protected virtual void CarregarEntidades()
        {
            if (trataFiltros != null && trataFiltros.filtroUtilizado)
                entidades = Conexao.TrataDAO.getAcesso<T>().Retorna_pFiltros(trataFiltros.Filtros);
            else
                entidades = Conexao.TrataDAO.getAcesso<T>().Retorna();
        }
        public override void Filtros(object sender, EventArgs e)
        {
            try
            {
                base.Filtros(sender, e);
                frmFiltros lfrmFiltros = new frmFiltros();
                lfrmFiltros.Carregar(trataFiltros);
                CarregarGrade();
                tsbFiltros.Checked = trataFiltros != null && trataFiltros.filtroUtilizado;
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        protected virtual void CarregarFiltros()
        {
            if (trataFiltros != null) return;
            trataFiltros = new TrataFiltros();
        }

        protected virtual void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in this.Controls)
                {
                    if (item.GetType() == typeof(DataGridView))
                    {
                        short contem = 0;
                        string[] filtros = txtFiltro.Text.Trim().ToUpper().Split(' ');
                        foreach (DataGridViewRow itemR in ((DataGridView)item).Rows)
                        {
                            contem = 0;
                            foreach (var filtro in filtros)
                            {
                                foreach (DataGridViewCell itemC in itemR.Cells)
                                {
                                    if (itemC.OwningColumn.Visible && itemC.Value != null && itemC.Value.ToString().ToUpper().Contains(filtro))
                                    {
                                        contem++;
                                        break;
                                    }

                                }
                            }
                            itemR.Visible = (contem == filtros.Count()) || itemR.IsNewRow;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private T EntidadeFiltrada() 
        {
            try
            {
                int rowsVisiveis = 0;
                int idEntidade = 0;
                foreach (var item in this.Controls)
                {
                    if (item.GetType() == typeof(DataGridView))
                    {
                        
                        foreach (DataGridViewRow itemR in ((DataGridView)item).Rows)
                        {
                            if (itemR.Visible)
                            {
                                rowsVisiveis++;
                                idEntidade = int.Parse(itemR.Cells["colId"].Value.ToString());
                            }
                        }
                    }
                }
                if (rowsVisiveis == 1 && idEntidade > 0)
                    return Conexao.TrataDAO.getAcesso<T>().Retorna_pId(idEntidade);
                else
                    return null;
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
                return null;
            }
        
        }

        //protected void CarregarColunas()
        //{
        //    IList<Entidade> entidades= Conexao.TrataDAO.getEntidade().Retorna_pNome(typeof(T).Name);
        //    if(entidades.Count>0)
        //    foreach (var item in entidades[0].Propriedades)
        //    {


        //    }
        //}
        //public override void Excluir(object sender, EventArgs e)
        //{
        //    if (dgvProc.SelectedRows.Count == 0) return;
        //    Conexao.TrataDAO.getAcesso<T>().Excluir(
        //        Conexao.TrataDAO.getAcesso<T>().Retorna_pId(
        //            int.Parse(dgvProc.SelectedRows[0].Cells[colId.Index].Value.ToString())));
        //    Procurar(sender, e);
        //}

        //public override void Novo(object sender, EventArgs e)
        //{

        //}

        //public override void Procurar(object sender, EventArgs e)
        //{
        //    entidades = Conexao.TrataDAO.getAcesso<T>().Retorna();
        //    PreencherGrid();
        //}

        //protected virtual bool PreencherGrid()
        //{
        //    return true;
        //}

        //protected bool AddCol(string nome,string header, TipoColuna tipo, short tamanho, bool visivel)
        //{
        //    try
        //    {
        //        DataGridViewColumn col;

        //        switch (tipo)
        //        {
        //            case TipoColuna.TextBox:
        //                col = new DataGridViewTextBoxColumn();
        //                break;
        //            case TipoColuna.Imagem:
        //                col = new DataGridViewImageColumn(); 
        //                break;
        //            case TipoColuna.Combo:
        //                col = new DataGridViewComboBoxColumn(); 
        //                break;
        //            default:
        //                return false;
        //        }

        //        col.Name = nome;
        //        col.HeaderText = header;
        //        col.Width = tamanho;
        //        col.Visible = visivel;

        //        dgvProc.Columns.Add(col);

        //        return true;
        //    }
        //    catch (Exception) { return false; }
        //}
    }
}

