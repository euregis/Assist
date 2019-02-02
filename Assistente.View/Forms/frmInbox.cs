using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using Assistente.Controle;
using Assistente.Entidades;
using Assistente.Excecoes;

namespace Assistente.View.Forms
{
    public partial class frmInbox : Form
    {
        

        public frmInbox()
        {
            InitializeComponent();
            WinControls.CarregaCombo<Projeto>(ref cboProjeto, 
                Conexao.TrataDAO.getAcesso<Projeto>().Retorna(x => x.Inativo == false).OrderBy(x=>x.Nome).ToList<Projeto>());
            Controle.WinControls.CarregaComboEnum<enuStatusTarefa>(ref cboStatus, false);

        }
        public void Carregar()
        {
            try
            {
                if (cboProjeto.Items.Count > 0) 
                    cboProjeto.SelectedItem = cboProjeto.Items[0];

                Microsoft.Office.Interop.Outlook.MAPIFolder inboxFolder = null;
                Microsoft.Office.Interop.Outlook.Application app = null;
                Microsoft.Office.Interop.Outlook._NameSpace ns = null;
                Microsoft.Office.Interop.Outlook.MailItem item = null;

                app = new Microsoft.Office.Interop.Outlook.Application();
                ns = app.GetNamespace("MAPI");
                ns.Logon(null, null, false, false);
                inboxFolder = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);

                for (int i = 1; i <= inboxFolder.Items.Count; i++)
                {
                    item = (Microsoft.Office.Interop.Outlook.MailItem)inboxFolder.Items[i];
                    dgvInbox.Rows.Add(item.ToString(), item.SenderName, item.Subject, item.LastModificationTime.ToShortDateString(), item.Body.Replace("\r\n\r\n", "\r\n"));
                }

                this.ShowDialog();
            }
            catch (System.Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInbox.SelectedRows.Count == 0) return;

                Tarefa entidade = new Tarefa();
                entidade.Codigo = Conexao.TrataDAO.getAcessoUtil().NovoCodigo<Tarefa>();
                if (dgvInbox[colAssunto.Index, dgvInbox.SelectedRows[0].Index].Value.ToString().Trim().Length > 3
                        && dgvInbox[colAssunto.Index, dgvInbox.SelectedRows[0].Index].Value.ToString().Trim()[3] == ':')
                    entidade.Descricao = dgvInbox[colAssunto.Index, dgvInbox.SelectedRows[0].Index].Value.ToString().Substring(4).Trim();
                else
                    entidade.Descricao = dgvInbox[colAssunto.Index, dgvInbox.SelectedRows[0].Index].Value.ToString().Trim();
                entidade.Cliente = (Projeto)cboProjeto.SelectedItem;
                entidade.Solicitante = dgvInbox[colDe.Index, dgvInbox.SelectedRows[0].Index].Value.ToString().Trim();
                entidade.Responsavel = txtResponsavel.Text.Trim();
                entidade.Status = (short)(int)cboStatus.SelectedValue;
                entidade.Prioridade = (short)enuPrioridadeTarefa.Normal;
                entidade.Categoria = (short)enuCategoriaTarefa.Indefinida;
                entidade.DataCadastro = DateTime.Parse(dgvInbox[colData.Index, dgvInbox.SelectedRows[0].Index].Value.ToString().Trim());
                entidade.PrazoTermino = entidade.DataCadastro.AddDays(1);
                entidade.Anotacoes = "[" + DateTime.Now.ToShortDateString() + " " 
                    + DateTime.Now.ToShortTimeString() + "]\r\n" +                     txtAnotacoes.Text.Trim();

                Conexao.TrataDAO.getAcesso<Tarefa>().Salvar(entidade);
            }
            catch (System.Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private void dgvInbox_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvInbox.SelectedRows.Count == 0) return;
             
                if (dgvInbox[colAnotacoes.Index, dgvInbox.SelectedRows[0].Index].Value.ToString().Length > 5000)
                    txtAnotacoes.Text = dgvInbox[colAnotacoes.Index, dgvInbox.SelectedRows[0].Index].Value.ToString().Substring(0,4997)+"...";
                else
                    txtAnotacoes.Text = dgvInbox[colAnotacoes.Index, dgvInbox.SelectedRows[0].Index].Value.ToString();

            }
            catch (System.Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
            }
        }

        private void frmInbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

    }
}
