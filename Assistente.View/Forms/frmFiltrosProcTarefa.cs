using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Assistente.View.Base.Forms;
using Assistente.Entidades.Filtros;
using Assistente.Entidades;
using Assistente.Controle;
using Assistente.Negocio.Util;

namespace Assistente.View.Forms
{
    public partial class frmFiltrosProcTarefa : frmFiltros
    {
        public frmFiltrosProcTarefa()
        {
            InitializeComponent();
            ExibirBotoes(Botoes.Confirmar, Botoes.Cancelar, Botoes.Limpar, Botoes.SepSair);
            tslTitulo.Text = "Filtros";
        }
        public TrataFiltros Carregar()//TrataFiltros tFiltros, IList<Projeto> projs, IList<short> status)
        {
            //this.trataFiltros = tFiltros;

            lstProjetos.SelectedItems.Clear();
            foreach (var item in Conexao.TrataDAO.getAcesso<Projeto>().Retorna().OrderBy(x => x.Inativo).ThenBy(n => n.Nome))
            {
                lstProjetos.Items.Add(item);
                if (frmTarefas.FiltroTar.Projetos != null && frmTarefas.FiltroTar.Projetos.Contains(item))
                    lstProjetos.SelectedItems.Add(item);
            }

            lstStatus.DataSource = new BindingSource(TrataEnum.Listar(typeof(enuStatusTarefa), false), null);
            lstStatus.DisplayMember = "Value";
            lstStatus.ValueMember = "Key";

            lstStatus.SelectedItems.Clear();
            for (int i = 0; i < lstStatus.Items.Count; i++)
                if (frmTarefas.FiltroTar.Status.Contains((short)(enuStatusTarefa)((KeyValuePair<Enum, string>)lstStatus.Items[i]).Key))
                    lstStatus.SelectedItems.Add(lstStatus.Items[i]);
            
            //chkInativo.CheckState = frmProcTarefa.FiltroTar.Inativo;

            this.ShowDialog();
            
            return this.trataFiltros;
        }
        protected override void Confirmar(object sender, EventArgs e)
        {
            frmTarefas.FiltroTar.Status.Clear();
            foreach (var item in lstStatus.SelectedItems)
                frmTarefas.FiltroTar.Status.Add((short)(enuStatusTarefa)((KeyValuePair<Enum, string>)item).Key);

            frmTarefas.FiltroTar.Projetos.Clear();
            foreach (var item in lstProjetos.SelectedItems)
                frmTarefas.FiltroTar.Projetos.Add((Projeto)item);

            //frmProcTarefa.FiltroTar.Inativo = chkInativo.CheckState;

            this.Sair(sender, e);
        }
        protected override void Limpar(object sender, EventArgs e)
        {
            frmTarefas.FiltroTar = new frmTarefas.FiltroTarefas();
            this.Sair(sender, e);
        }

    }
}
