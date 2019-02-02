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

    public partial class frmCadCliente : frmCCliente
    {
        bool nomeAlterado = false;
        public frmCadCliente()
            : base()
        {
            tslTitulo.Text = "Cadastro de Projeto";
            InitializeComponent();
        }

        public override bool PreencherObjeto()
        {
            if (entidade.Id == 0)
                entidade.Codigo = Conexao.TrataDAO.getCliente().NovoCodigo();
            else
                entidade.Codigo = int.Parse(mtbCodigo.Text.Trim());
            if (!String.IsNullOrEmpty(entidade.Nome) && entidade.Nome != txtNome.Text.Trim()) nomeAlterado = true;
            entidade.CodigoRegis = txtCodRegis.Text.Trim();
            entidade.Nome = txtNome.Text.Trim();
            entidade.Inativo = chkInativo.Checked;
            return true;
        }
        public override bool PreencherCampos()
        {
            base.PreencherCampos();
            mtbCodigo.Tag = entidade.Id.ToString();
            mtbCodigo.Text = entidade.Codigo.ToString();
            txtCodRegis.Text = entidade.CodigoRegis;
            txtNome.Text = entidade.Nome;
            chkInativo.Checked = entidade.Inativo;
            CarregarPastas();
            return true;
        }

        private void CarregarPastas()
        {
            try
            {
                dgvPastas.Rows.Clear();
                if (entidade.Id == 0) return;
                dgvPastas.Rows.Add("0", "", "");
                foreach (var item in Conexao.TrataDAO.getAcesso<Pasta>()
                    .Retorna(x => x.Cliente == entidade && x.Ambiente == Geral.AmbienteLocal))
                {
                    String[] pasta = { item.Id.ToString(), item.Caminho, item.Descricao };

                    dgvPastas.Rows.Add(pasta);
                }
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private void dgvPastas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {try{
            DataGridView dgvTemp = (DataGridView)sender;
            if (!String.IsNullOrEmpty(dgvTemp.CurrentRow.Cells[colPastasCaminho.Index].Value.ToString().Trim())
                && !String.IsNullOrEmpty(dgvTemp.CurrentRow.Cells[colPastasDescricao.Index].Value.ToString().Trim()))
            {
                Pasta pasta = Conexao.TrataDAO.getAcesso<Pasta>().Retorna_pId(int.Parse(dgvTemp.CurrentRow.Cells[colPastasId.Index].Value.ToString()));

                if (pasta == null)
                    pasta = new Pasta();

                pasta.Ambiente = Geral.AmbienteLocal;
                pasta.Caminho = dgvTemp.CurrentRow.Cells[colPastasCaminho.Index].Value.ToString().Trim();
                pasta.Descricao = dgvTemp.CurrentRow.Cells[colPastasDescricao.Index].Value.ToString().Trim();
                pasta.Cliente = entidade;

                Conexao.TrataDAO.getAcesso<Pasta>().Salvar(pasta);
                //CarregarPastas();
            }
        }
        catch (Exception ex)
        {
            WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
        }
        }

        private void dgvPastas_KeyUp(object sender, KeyEventArgs e)
        {try{
            if (((DataGridView)sender).CurrentCell != null && 
                ((DataGridView)sender).CurrentCell.IsInEditMode == false && e.KeyCode == Keys.Delete)
            {
                Pasta pasta = Conexao.TrataDAO.getAcesso<Pasta>().Retorna_pId(
                    int.Parse(((DataGridView)sender).CurrentRow.Cells[colPastasId.Index].Value.ToString()));
                if (pasta != null)
                {
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
        protected override bool DadosValidos()
        {
            //bool ret = true;
            Validacoes = new List<Validacao>();
            AddValidacao("Nome Preenchido", txtNome.Text, txtNome, lblNome, TipoValidacao.Preenchido);
            if(entidade.Id == 0 || nomeAlterado)
                AddValidacao("Nome já existe", txtNome.Text, txtNome, lblNome, TipoValidacao.NomeClienteDuplicado);

            return base.DadosValidos();
        }

    }
    public class frmCCliente : frmCadBase<Projeto> { }
}
