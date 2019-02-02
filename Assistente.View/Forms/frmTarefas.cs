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
using Assistente.Entidades.Filtros;
using System.Collections;
using Assistente.Excecoes;
using System.Diagnostics;

namespace Assistente.View.Forms
{
    public partial class frmTarefas : frmPTarefa
    {
        private ContextMenu popUpMenu;

        public static FiltroTarefas FiltroTar = new FiltroTarefas();

        public class FiltroTarefas
        {
            public IList<short> Status = new List<short>();
            public IList<Projeto> Projetos = new List<Projeto>();
            //public CheckState Inativo = CheckState.Unchecked;
            public FiltroTarefas()
            {
                Status = new List<short>();
                Status.Add((short)enuStatusTarefa.Aguardando);
                Status.Add((short)enuStatusTarefa.ASAP);
                Status.Add((short)enuStatusTarefa.Atrasado);
                //Status.Add((short)enuStatusTarefa.Disponibilizar);
                Status.Add((short)enuStatusTarefa.Projeto);
                /*Status.Add((short)enuStatusTarefa.Encaminhar);
                Status.Add((short)enuStatusTarefa.Parado);*/

                Projetos = new List<Projeto>();
                Projetos = Conexao.TrataDAO.getAcesso<Projeto>().Retorna(x => x.Inativo == false);

                //Inativo = CheckState.Unchecked;
            }
        }


        public frmTarefas()
        {
            InitializeComponent();
            toolTip1.AutoPopDelay = 100;
            OcultarBotoes(Botoes.SepSair, Botoes.Sair);
            tslTitulo.Text = "Gerenciamento de Tarefa";
            colAnotacoes.Visible = Assistente.Negocio.Util.Conversor.ParaBool((Conexao.TrataDAO.getConfiguracao()
                .Retorna_pCodigo((int)enuConfiguracao.ExibirColunaAnotacoes)).Valor);
            
            Configuracao config = Conexao.TrataDAO.getConfiguracao().Retorna_pCodigo((int)
                    enuConfiguracao.ExibirColunaAnotacoes);
            colAnotacoes.Visible = Negocio.Util.Conversor.ParaBool(config.Valor);

            config = Conexao.TrataDAO.getConfiguracao().Retorna_pCodigo((int)
                    enuConfiguracao.CentralizadorDados);
            Negocio.Geral.CentralizadorDados = config.Valor;
            CarregarGrade();
            
        }
        public override void Novo(object sender, EventArgs e)
        {
            try
            {
                base.Novo(sender, e);
                frmCadTarefa lfrmCadTarefa = new frmCadTarefa();
                lfrmCadTarefa.Carregar(this);
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }
        public void DefineCores(enuStatusTarefa status, int linha, DateTime? prazo)
        {
            dgvTarefas.Rows[linha].DefaultCellStyle = new DataGridViewRow().DefaultCellStyle;

            if (status == enuStatusTarefa.Concluido)
                dgvTarefas.Rows[linha].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            else
            {
                if (status == enuStatusTarefa.Atrasado)
                    dgvTarefas.Rows[linha].DefaultCellStyle.BackColor = Color.Red;
                else 
                {
                    if (status == enuStatusTarefa.ASAP)
                        dgvTarefas.Rows[linha].DefaultCellStyle.BackColor = Color.Orange;
                    else if (status == enuStatusTarefa.Aguardando)
                    {
                        dgvTarefas.Rows[linha].DefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro;
                        dgvTarefas.Rows[linha].DefaultCellStyle.Font= new Font(dgvTarefas.DefaultCellStyle.Font,FontStyle.Italic);
                    }
                    else
                        dgvTarefas.Rows[linha].DefaultCellStyle.BackColor = System.Drawing.Color.White;

                    if (prazo != null && ((DateTime)prazo).Date < DateTime.Today)
                        dgvTarefas[colPrazo.Index, linha].Style.BackColor = Color.Red;

                    

                }
                
            }

            if (dgvTarefas[colResponsavel.Index, linha].Value.ToString().Trim().ToUpper() == "REGINALDO")
            {
                dgvTarefas[colResponsavel.Index, linha].Value = "REGINALDO";
                dgvTarefas[colResponsavel.Index, linha].Style.BackColor = Color.Yellow;
            }
            else
                dgvTarefas[colResponsavel.Index, linha].Style.BackColor = dgvTarefas.Rows[linha].DefaultCellStyle.BackColor;

            if (int.Parse(dgvTarefas[colQtPendencias.Index, linha].Value.ToString()) > 0)
                dgvTarefas[colQtPendencias.Index, linha].Style.BackColor = Color.Yellow;
            else
                dgvTarefas[colQtPendencias.Index, linha].Style.BackColor = dgvTarefas.Rows[linha].DefaultCellStyle.BackColor;

        }
        public override void CarregarGrade()
        {
            try
            {
                base.CarregarGrade();
                dgvTarefas.Rows.Clear();
                txtFiltro.Text = "";

                IList<Projeto> clientes = Conexao.TrataDAO.getAcesso<Projeto>().Retorna().OrderBy(x => x.Inativo).ThenBy(n => n.Nome).ToList<Projeto>();//(x=> x.Inativo==false);
                colCliente.Items.Clear();
                colCliente.Items.Add("");
                foreach (Projeto c in clientes) colCliente.Items.Add(c.Nome);


                string[] statusTarefa = Enum.GetNames(typeof(enuStatusTarefa)).OrderBy(x=>x.ToString()).ToArray();
                colStatus.Items.Clear();
                foreach (string st in statusTarefa)
                {
                    if (st != Enum.GetName(typeof(enuStatusTarefa), enuStatusTarefa.Todos))
                        colStatus.Items.Add(st);
                }

                string[] priorTarefa = Enum.GetNames(typeof(enuPrioridadeTarefa));
                colPrioridade.Items.Clear();
                foreach (string prior in priorTarefa)
                {
                    if (prior != Enum.GetName(typeof(enuPrioridadeTarefa), enuPrioridadeTarefa.Todos))
                        colPrioridade.Items.Add(prior);
                }


                dgvTarefas.DataError += new DataGridViewDataErrorEventHandler(dgvCombo_DataError);
                foreach (Tarefa tarefa in entidades.Where(x => x.Status == (short)enuStatusTarefa.Projeto).OrderBy(x => x.Id))
                {
                    int pendencias = tarefa.Pendencias.Where(x => x.DataConclusao == null).Count();
                    object[] objetoTarefa = {tarefa.Id.ToString(), 
                                            tarefa.Cliente!=null?tarefa.Cliente.Nome:"",
                                            tarefa.Descricao, tarefa.Responsavel,
                                            Enum.GetName(typeof(enuStatusTarefa), tarefa.Status),
                                            Enum.GetName(typeof(enuPrioridadeTarefa), tarefa.Prioridade),
                                            tarefa.PrazoTermino,
                                            pendencias,tarefa.Anotacoes, Properties.Resources.Annotation};
                    dgvTarefas.Rows.Add(objetoTarefa);

                    DefineCores((enuStatusTarefa)tarefa.Status, dgvTarefas.Rows.Count - 2, tarefa.PrazoTermino);

                } foreach (Tarefa tarefa in entidades.Where(x => x.Status != (short)enuStatusTarefa.Projeto).OrderBy(x=>x.Id))
                {
                    int pendencias = tarefa.Pendencias.Where(x => x.DataConclusao == null).Count();
                    object[] objetoTarefa = {tarefa.Id.ToString(), 
                                            tarefa.Cliente!=null?tarefa.Cliente.Nome:"",
                                            tarefa.Descricao, tarefa.Responsavel,
                                            Enum.GetName(typeof(enuStatusTarefa), tarefa.Status),
                                            Enum.GetName(typeof(enuPrioridadeTarefa), tarefa.Prioridade),
                                            tarefa.PrazoTermino,
                                            pendencias,tarefa.Anotacoes, Properties.Resources.Annotation};
                    dgvTarefas.Rows.Add(objetoTarefa);

                    DefineCores((enuStatusTarefa)tarefa.Status, dgvTarefas.Rows.Count - 2, tarefa.PrazoTermino);

                }
                
                dgvTarefas[colCliente.Index, dgvTarefas.Rows.Count - 1].Value = colCliente.Items.Count > 0 ? colCliente.Items[1] : colCliente.Items[0];
                dgvTarefas[colStatus.Index, dgvTarefas.Rows.Count - 1].Value = Enum.GetName(typeof(enuStatusTarefa), enuStatusTarefa.Aguardando);
                dgvTarefas[colPrioridade.Index, dgvTarefas.Rows.Count - 1].Value = Enum.GetName(typeof(enuPrioridadeTarefa), enuPrioridadeTarefa.Normal);
                dgvTarefas[colDescricao.Index, dgvTarefas.Rows.Count - 1].Value = "";
                dgvTarefas[colResponsavel.Index, dgvTarefas.Rows.Count - 1].Value = "";
                dgvTarefas[colPrazo.Index, dgvTarefas.Rows.Count - 1].Value = "";
                dgvTarefas[colPrazo.Index, dgvTarefas.Rows.Count - 1].Value = "";
                dgvTarefas[colAnotacoes.Index, dgvTarefas.Rows.Count - 1].Value = "";

                    dgvTarefas[colAddAnotacao.Index, dgvTarefas.Rows.Count - 1].Value = Properties.Resources.salvar;
                dgvTarefas[colDescricao.Index, dgvTarefas.RowCount - 1].ReadOnly = false;
                dgvTarefas[colCliente.Index, dgvTarefas.RowCount - 1].ReadOnly = false;

                
                VerificarInconsistencias();
                txtFiltro_TextChanged(null, null);
            }
            catch (Exception ex) {  WinControls.ApresentarErro(AssistErroException.TratarErro(ex));}
        }
        void dgvCombo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // (No need to write anything in here)
        }

        private void dgvTarefas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridView dgvTmp = (DataGridView)sender;
                if (dgvTmp.CurrentCell.ColumnIndex == colAddAnotacao.Index
                    && dgvTmp[colId.Index, dgvTmp.CurrentRow.Index].Value!=null)
                {
                    frmCadAnotTarefa lfrmCadAnotTarefa = new frmCadAnotTarefa();
                    lfrmCadAnotTarefa.Carregar(int.Parse(dgvTarefas[colId.Index, dgvTmp.CurrentRow.Index].Value.ToString()), this);
                }
                if (dgvTmp.CurrentCell.ColumnIndex ==colAddAnotacao.Index )
                {
                    if (dgvTmp[colId.Index, dgvTmp.CurrentRow.Index].Value==null)
                    {
                        if (String.IsNullOrEmpty(dgvTmp[colDescricao.Index, dgvTmp.CurrentRow.Index].Value.ToString().Trim()))
                        {
                            MessageBox.Show("Informe a descrição da tarefa.", "Descrição não informada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvTmp[colDescricao.Index, e.RowIndex].Selected = true;
                        }
                        Tarefa tarefa = new Tarefa();
                        tarefa.Codigo = Conexao.TrataDAO.getAcessoUtil().NovoCodigo<Tarefa>();

                        if (dgvTmp[colCliente.Index, dgvTmp.CurrentRow.Index].Value != null)
                        {
                            IList<Projeto> clientes = Conexao.TrataDAO.getAcesso<Projeto>().Retorna(x => x.Nome == dgvTmp[colCliente.Index, dgvTmp.CurrentRow.Index].Value.ToString());
                            tarefa.Cliente = clientes.Count > 0 ? clientes[0] : null;
                        }
                        else
                            tarefa.Cliente = null;
                        tarefa.DataCadastro = DateTime.Now;
                        tarefa.Categoria = (short)(int)enuCategoriaTarefa.Indefinida;
                        tarefa.Descricao = dgvTmp[colDescricao.Index, dgvTmp.CurrentRow.Index].Value.ToString().Trim();
                        tarefa.Responsavel = dgvTmp[colResponsavel.Index, dgvTmp.CurrentRow.Index].Value.ToString().Trim();
                        tarefa.Status = (short)(int)Enum.Parse(typeof(enuStatusTarefa), dgvTmp[colStatus.Index, dgvTmp.CurrentRow.Index].Value.ToString(), true);
                        
                        if (dgvTarefas[colPrazo.Index, dgvTarefas.CurrentRow.Index].Value == null || dgvTarefas[colPrazo.Index, dgvTarefas.CurrentRow.Index].Value == "")
                            tarefa.PrazoTermino = null;
                        else
                            tarefa.PrazoTermino = DateTime.Parse(dgvTarefas[colPrazo.Index, dgvTarefas.CurrentRow.Index].Value.ToString().Trim());
                        
                        if (!colPrioridade.Visible)
                            tarefa.Prioridade = (short)enuPrioridadeTarefa.Normal;
                        else
                            tarefa.Prioridade = (short)(int)Enum.Parse(typeof(enuPrioridadeTarefa), dgvTmp[colPrioridade.Index, dgvTmp.CurrentRow.Index].Value.ToString(), true);

                        if (dgvTmp[colAnotacoes.Index, dgvTmp.CurrentRow.Index].Value == null)
                            tarefa.Anotacoes = "";
                        else
                            tarefa.Anotacoes = dgvTmp[colAnotacoes.Index, dgvTmp.CurrentRow.Index].Value.ToString().Trim();

                        Conexao.TrataDAO.getAcesso<Tarefa>().Salvar(tarefa);
                        CarregarGrade();
                    }
                    else if (dgvTarefas[colStatus.Index, dgvTarefas.CurrentRow.Index].Value.ToString() == enuStatusTarefa.Concluido.ToString())
                    {
                        return;
                    }
                   
                    
                }
               
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        
        private void dgvTarefas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > colId.Index && e.ColumnIndex < colAddAnotacao.Index && 
                    dgvTarefas[colId.Index, dgvTarefas.CurrentRow.Index].Value != null )
                {
                    Tarefa tarefa = Conexao.TrataDAO.getAcesso<Tarefa>().Retorna_pId(int.Parse(dgvTarefas[colId.Index, dgvTarefas.CurrentRow.Index].Value.ToString()));
                    if (tarefa == null) return;

                    Tarefa tarOld = Negocio.Geral.Clonar(Conexao.TrataDAO.getTarefa().Retorna_pId(int.Parse(dgvTarefas[colId.Index, dgvTarefas.CurrentRow.Index].Value.ToString())));
                    string anot = null;

                    
                    
                    if (dgvTarefas[colCliente.Index, dgvTarefas.CurrentRow.Index].Value != null)
                    {
                        IList<Projeto> clientes = Conexao.TrataDAO.getAcesso<Projeto>().Retorna(x => x.Nome == dgvTarefas[colCliente.Index, dgvTarefas.CurrentRow.Index].Value.ToString());
                        tarefa.Cliente = clientes.Count > 0 ? clientes[0] : null;
                    }
                    else
                        tarefa.Cliente = null;
                    tarefa.Descricao = dgvTarefas[colDescricao.Index, dgvTarefas.CurrentRow.Index].Value.ToString().Trim();
                    tarefa.Responsavel = dgvTarefas[colResponsavel.Index, dgvTarefas.CurrentRow.Index].Value.ToString().Trim();
                    tarefa.Status = (short)(int)Enum.Parse(typeof(enuStatusTarefa), dgvTarefas[colStatus.Index, dgvTarefas.CurrentRow.Index].Value.ToString(), true);
                    if (dgvTarefas[colPrazo.Index, dgvTarefas.CurrentRow.Index].Value == null || dgvTarefas[colPrazo.Index, dgvTarefas.CurrentRow.Index].Value=="")
                        tarefa.PrazoTermino = null;
                    else
                        tarefa.PrazoTermino = DateTime.Parse( dgvTarefas[colPrazo.Index, dgvTarefas.CurrentRow.Index].Value.ToString().Trim());
                    tarefa.Prioridade = (short)(int)Enum.Parse(typeof(enuPrioridadeTarefa), dgvTarefas[colPrioridade.Index, dgvTarefas.CurrentRow.Index].Value.ToString(), true);

                    anot = Negocio.Geral.ObtemMudancas(tarOld, tarefa);
                    if (anot != null)
                        anot = "[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "]\r\n" + anot
                            + "\r\n\r\n" ;
                    else
                        anot = "";

                    if (dgvTarefas[colAnotacoes.Index, e.RowIndex].Value != null)
                        anot = anot + dgvTarefas[colAnotacoes.Index, e.RowIndex].Value.ToString().Trim();
                    
                    dgvTarefas[colAnotacoes.Index, e.RowIndex].Value = anot.Trim();
                    tarefa.Anotacoes = anot.Trim();
                    Conexao.TrataDAO.getAcesso<Tarefa>().Salvar(tarefa);

                    DefineCores((enuStatusTarefa)tarefa.Status, e.RowIndex, tarefa.PrazoTermino);
                }
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }
        
        private void dgvTarefas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgvTemp = (DataGridView)sender;
                if (e.RowIndex >= 0)
                {
                    if (dgvTarefas[colId.Index, dgvTemp.CurrentRow.Index].Value == null) return;
                    int id = int.Parse(dgvTarefas[colId.Index, dgvTemp.CurrentRow.Index].Value.ToString());
                    if (id == 0) return;

                    frmCadTarefa lfrCadTarefa = new frmCadTarefa();
                    lfrCadTarefa.Carregar(int.Parse(dgvTarefas[colId.Index, dgvTemp.CurrentRow.Index].Value.ToString()), this);
                }
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private void dgvTarefas_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right && e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    if (e.ColumnIndex <= colDescricao.Index && dgvTarefas[colId.Index, e.RowIndex].Value!=null)
                    {
                        Rectangle a = ((DataGridView)sender).GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                        EventHandler eventoPasta = new System.EventHandler(Pasta_Click);
                        popUpMenu = Menus.carregaContextMenuTarefa(
                            int.Parse(dgvTarefas[colId.Index, e.RowIndex].Value.ToString()), ref eventoPasta);
                        popUpMenu.Show(dgvTarefas, new Point(e.X + a.X, e.Y + a.Y));
                    }
                }
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }
        private void Pasta_Click(Object sender, System.EventArgs e)
        {
            try
            {
                Int32 Id;
                MenuItem menuItem = (MenuItem)sender;
                if (menuItem.Tag.ToString().Substring(0, menuItem.Tag.ToString().IndexOf(" ")) == "PastaD")
                {
                    if (Negocio.Util.Arquivos.ArquivoExiste(Negocio.Geral.CentralizadorDados))
                        Process.Start(Negocio.Geral.CentralizadorDados, menuItem.Tag.ToString().Substring(menuItem.Tag.ToString().IndexOf(" ")));
                }
                else
                {
                    Id = Int32.Parse(menuItem.Tag.ToString().Substring(menuItem.Tag.ToString().IndexOf(" ")));

                    if (Id > 0)
                    {
                        Pasta pasta = Conexao.TrataDAO.getAcesso<Pasta>().Retorna_pId(Id);
                        if (pasta != null)
                            /*if (Menus.CheckURLValid(pasta.Caminho)|| pasta.Caminho.ToLower().StartsWith("starteam:")
                              || new System.IO.DirectoryInfo(pasta.Caminho).Exists || new System.IO.FileInfo(pasta.Caminho).Exists)*/
                            System.Diagnostics.Process.Start(pasta.Caminho);
                    }
                }
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }
        
        protected override void CarregarEntidades()
        {
            //if (FiltroTar.Inativo == CheckState.Indeterminate)
                entidades = Conexao.TrataDAO.getAcesso<Tarefa>().Retorna(x => FiltroTar.Status.Contains(x.Status)
                    && FiltroTar.Projetos.Contains(x.Cliente));
            /*else
                entidades = Conexao.TrataDAO.getAcesso<Tarefa>().Retorna(x => FiltroTar.Status.Contains(x.Status)
                && FiltroTar.Projetos.Contains(x.Cliente) && x.Inativo == (CheckState.Checked == FiltroTar.Inativo));*/
            
        }
        /*protected override void CarregarFiltros()
        {
            if (trataFiltros != null) return;
            trataFiltros = new Assistente.Entidades.Filtros.TrataFiltros();
            ArrayList itens = new ArrayList();
            foreach (var item in Conexao.TrataDAO.getAcesso<Projeto>().Retorna(x=>x.Inativo==false))
                itens.Add(item);
            itens.Add("");
            trataFiltros.IncluirFiltroCombo(typeof(Tarefa).GetProperty("Cliente"), "Projeto", "Todos", "Todos", false, true, itens, typeof(Projeto));
            trataFiltros.IncluirFiltroTexto(typeof(Tarefa).GetProperty("Descricao"), PosicaoProcura.Qualquer, "Descrição", "", "");
            trataFiltros.IncluirFiltroCombo(typeof(Tarefa).GetProperty("Status"), "Status", enuStatusTarefa.Todos, enuStatusTarefa.Todos, true, true, null, typeof(enuStatusTarefa));
            trataFiltros.IncluirFiltroCheckbox(typeof(Tarefa).GetProperty("Inativo"), "Inativo", (byte)CheckState.Unchecked, (byte)CheckState.Unchecked);

        }*/
        public override void Filtros(object sender, EventArgs e)
        {
            try
            {
                //ase.Filtros(sender, e);
                frmFiltrosProcTarefa lfrmFiltros = new frmFiltrosProcTarefa();
                lfrmFiltros.Carregar();
                CarregarGrade();
                tsbFiltros.Checked = trataFiltros != null && trataFiltros.filtroUtilizado;
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private void lnkProjetos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmProcCliente lfrmPCliente = new frmProcCliente();
                lfrmPCliente.Carregar();
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private void lnkConfig_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmProcConfiguracao lfrmPConfig = new frmProcConfiguracao();
                lfrmPConfig.Carregar();
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }
        private void VerificarInconsistencias()
        {
            tssStatus.Text = "";
            tssStatus.ForeColor = Color.Black;
            IList<Tarefa> tarefas = Conexao.TrataDAO.getAcesso<Tarefa>().Retorna();
            if (tarefas.Where(x => x.Status == (short)enuStatusTarefa.Concluido && x.Pendencias.Where(y => y.DataConclusao == null).Count() > 0).Count() > 0)
                tssStatus.Text = "Existem tarefas concluídas com pendencias.";

            if (tssStatus.Text.Trim().Length > 0)
                tssStatus.ForeColor = Color.Red;
        }

        private void dgvTarefas_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == colId.Index)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;//pass by the default sorting
            }

        }

        private void dgvTarefas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvTarefas.Rows[e.RowIndex].IsNewRow && e.ColumnIndex == colAddAnotacao.Index)
            {
                e.Value = Properties.Resources.salvar;
            }
            /*else if (e.ColumnIndex == colDescricao.Index && e.Value != null && dgvTarefas[colAnotacoes.Index, e.RowIndex].Value != null)
            {
                dgvTarefas.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = dgvTarefas[colAnotacoes.Index,e.RowIndex].Value.ToString();
                
            }*/
        }

        private void frmTarefas_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTarefas.SelectedCells.Count>0 && dgvTarefas[colId.Index, dgvTarefas.SelectedCells[0].RowIndex].Value != null)
                {
                    Tarefa tarefa = Conexao.TrataDAO.getAcesso<Tarefa>().Retorna_pId(int.Parse(dgvTarefas[colId.Index, dgvTarefas.CurrentRow.Index].Value.ToString()));
                    tarefa.Anotacoes = txtAnotacoes.Text;
                    
                    Conexao.TrataDAO.getAcesso<Tarefa>().Salvar(tarefa);

                    dgvTarefas[colAnotacoes.Index, dgvTarefas.SelectedCells[0].RowIndex].Value = txtAnotacoes.Text;
                    btnGravar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private void dgvTarefas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvTarefas.SelectedCells.Count > 0 && dgvTarefas[colAnotacoes.Index, dgvTarefas.SelectedCells[0].RowIndex].Value != null)
                {
                    txtAnotacoes.Text = dgvTarefas[colAnotacoes.Index, dgvTarefas.SelectedCells[0].RowIndex].Value.ToString();

                    CarregarPendencias();
                }
                else
                {
                    txtAnotacoes.Text = "";
                    dgvPendencias.Rows.Clear();
                }
                btnGravar.Enabled = false;
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }
        private void dgvPendencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgvTemp = (DataGridView)sender;
                if (int.Parse(dgvTemp[colPendenciasId.Index, e.RowIndex].Value.ToString()) > 0
                    && e.ColumnIndex == colPendenciasConcluido.Index
                    && dgvTarefas.SelectedCells.Count > 0 && dgvTarefas[colId.Index, dgvTarefas.SelectedCells[0].RowIndex].Value != null)
                {
                    Pendencia pendencia = Conexao.TrataDAO.getAcesso<Pendencia>().Retorna_pId(int.Parse(dgvTemp[colPendenciasId.Index, e.RowIndex].Value.ToString()));

                    if (pendencia != null)
                    {
                        if (System.Convert.ToBoolean(dgvTemp.CurrentRow.Cells[colPendenciasConcluido.Index].Value))
                        {
                            addAnotacao("REABERTA PENDENCIA:\r\n" + pendencia.Descricao);
                            pendencia.DataConclusao = null;
                        }
                        else
                        {
                            addAnotacao("CONCLUÍDA PENDENCIA:\r\n" + pendencia.Descricao);
                            pendencia.DataConclusao = DateTime.Now;
                        }
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
                    && !string.IsNullOrEmpty(dgvTemp[colPendenciasDescricao.Index, e.RowIndex].Value.ToString().Trim())
                    && dgvTarefas.SelectedCells.Count > 0 && dgvTarefas[colId.Index, dgvTarefas.SelectedCells[0].RowIndex].Value != null)
                {
                    Pendencia pendencia = Conexao.TrataDAO.getAcesso<Pendencia>().Retorna_pId(int.Parse(dgvTemp[colPendenciasId.Index, e.RowIndex].Value.ToString()));

                    if (pendencia == null)
                    {
                        pendencia = new Pendencia();
                        pendencia.DataCadastro = DateTime.Now;
                        if ((CheckState)dgvTemp[colPendenciasConcluido.Index, e.RowIndex].Value == CheckState.Unchecked)
                        {
                            addAnotacao("INCLUÍDA PENDENCIA:\r\n" + dgvTemp[colPendenciasDescricao.Index, e.RowIndex].Value.ToString().Trim());
                            pendencia.DataConclusao = null;
                        }
                        else
                        {
                            pendencia.DataConclusao = DateTime.Now;
                            addAnotacao("INCLUÍDA PENDENCIA:\r\n" + dgvTemp[colPendenciasDescricao.Index, e.RowIndex].Value.ToString().Trim() + " - CONCLUÍDA");
                        }
                    }
                    else if (pendencia.Descricao != dgvTemp[colPendenciasDescricao.Index, e.RowIndex].Value.ToString().Trim())
                    {
                        addAnotacao("ALTERADA PENDENCIA DE:\r\n" + pendencia.Descricao
                            + "\r\n\r\nPARA:\r\n" + dgvTemp[colPendenciasDescricao.Index, e.RowIndex].Value.ToString().Trim());
                    }

                    pendencia.Descricao = dgvTemp[colPendenciasDescricao.Index, e.RowIndex].Value.ToString().Trim();

                    Tarefa tarefa = Conexao.TrataDAO.getAcesso<Tarefa>().Retorna_pId(int.Parse(dgvTarefas[colId.Index, dgvTarefas.CurrentRow.Index].Value.ToString()));

                    pendencia.Tarefa = tarefa;
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
                    ((DataGridView)sender).CurrentCell.IsInEditMode == false && e.KeyCode == Keys.Delete
                    && dgvTarefas.SelectedCells.Count > 0 && dgvTarefas[colId.Index, dgvTarefas.SelectedCells[0].RowIndex].Value != null)
                {
                    Tarefa tarefa = Conexao.TrataDAO.getAcesso<Tarefa>().Retorna_pId(int.Parse(dgvTarefas[colId.Index, dgvTarefas.CurrentRow.Index].Value.ToString()));
                    Pendencia pendencia = Conexao.TrataDAO.getAcesso<Pendencia>().Retorna_pId(int.Parse(((DataGridView)sender).CurrentRow.Cells[colPendenciasId.Index].Value.ToString()));
                    if (pendencia != null)
                    {
                        addAnotacao("REMOVIDA PENDENCIA:\r\n" + pendencia.Descricao);
                        tarefa.Pendencias.Remove(pendencia);                        
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
        private void CarregarPendencias()
        {
            try
            {
                //carregando = true;
                Tarefa tarefa =null;
                dgvPendencias.Rows.Clear();
                if (dgvTarefas.SelectedCells.Count > 0 && dgvTarefas[colId.Index, dgvTarefas.SelectedCells[0].RowIndex].Value != null)
                {
                    tarefa = Conexao.TrataDAO.getAcesso<Tarefa>().Retorna_pId(int.Parse(dgvTarefas[colId.Index, dgvTarefas.CurrentRow.Index].Value.ToString()));

                    if (tarefa.Id == 0) return;

                    dgvPendencias.Rows.Add(0, CheckState.Unchecked, "", new DataGridViewButtonCell());
                    foreach (var item in Conexao.TrataDAO.getAcesso<Pendencia>().Retorna(x => x.Tarefa == tarefa).OrderBy(x => x.DataConclusao))
                    {
                        Object[] pendencia = { item.Id, item.DataConclusao == null ? CheckState.Unchecked : CheckState.Checked, item.Descricao, new DataGridViewButtonCell() };

                        dgvPendencias.Rows.Add(pendencia);
                    }

                    dgvTarefas[colQtPendencias.Index, dgvTarefas.SelectedCells[0].RowIndex].Value = tarefa.Pendencias.Where(x => x.DataConclusao == null).Count();
                    DefineCores((enuStatusTarefa)tarefa.Status, dgvTarefas.SelectedCells[0].RowIndex, tarefa.PrazoTermino);
                }
                //if (tarefa.Pendencias.Count > 4) colPendenciasDescricao.Width = 241;
                //else colPendenciasDescricao.Width = 258;
                //carregando = false;
            }
            catch (Exception) { }
        }

        private void txtAnotações_Enter(object sender, EventArgs e)
        {
            if (dgvTarefas.SelectedCells.Count > 0 && dgvTarefas[colAnotacoes.Index, dgvTarefas.SelectedCells[0].RowIndex].Value != null)
            {
                txtAnotacoes.Text = "[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "]\r\n\r\n\r\n\r" + dgvTarefas[colAnotacoes.Index, dgvTarefas.SelectedCells[0].RowIndex].Value.ToString();
                btnGravar.Enabled = true;
                if (txtAnotacoes.Text.Length > 19)
                    txtAnotacoes.SelectionStart = 20;
            }
        }

        private void addAnotacao(string p)
        {
            if (dgvTarefas.SelectedCells.Count > 0 && dgvTarefas[colId.Index, dgvTarefas.SelectedCells[0].RowIndex].Value != null)
            {
                Tarefa tarefa = Conexao.TrataDAO.getAcesso<Tarefa>().Retorna_pId(int.Parse(dgvTarefas[colId.Index, dgvTarefas.CurrentRow.Index].Value.ToString()));
                
                tarefa.Anotacoes= "[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "]\r\n" 
                    + p + "\r\n\r\n\r" + tarefa.Anotacoes;
                dgvTarefas[colAnotacoes.Index, dgvTarefas.SelectedCells[0].RowIndex].Value = tarefa.Anotacoes;
                txtAnotacoes.Text = tarefa.Anotacoes;
                
                Conexao.TrataDAO.getAcesso<Tarefa>().Salvar(tarefa);
            }
        }

        private void txtAnotações_MouseClick(object sender, MouseEventArgs e)
        {
            //txtAnotacoes.Text = "[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "]\r\n\r\n\r\n" + txtAnotacoes.Text;
            if (txtAnotacoes.Text.Length > 19)
                txtAnotacoes.SelectionStart = 20;
        }

        private void lnkInbox_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmInbox lfrInbox = new frmInbox();
                lfrInbox.Carregar();
                CarregarGrade();
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }
        
        protected override void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                short contem = 0;
                string[] filtros = txtFiltro.Text.Trim().ToUpper().Split(' ');
                foreach (DataGridViewRow itemR in dgvTarefas.Rows)
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
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        /*private void dgvTarefas_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colDescricao.Index && dgvTarefas[colAnotacoes.Index, e.RowIndex].Value != null)
            {
                //dgvTarefas.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = dgvTarefas[colAnotacoes.Index, e.RowIndex].Value.ToString();
                Rectangle cellRect = dgvTarefas.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                toolTip1.Show(dgvTarefas[colAnotacoes.Index, e.RowIndex].Value.ToString(),
                              this,
                              dgvTarefas.Location.X + cellRect.X + cellRect.Size.Width,
                              dgvTarefas.Location.Y + cellRect.Y + cellRect.Size.Height,
                              5000);    // Duration: 5 seconds.
            }

        }

        private void dgvTarefas_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            toolTip1.Hide(this);
        }    */    

    }

    public partial class frmPTarefa : frmProcBase<Tarefa> { }
}
