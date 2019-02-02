using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Assistente.Entidades.Base;
using Assistente.Controle;
using Assistente.Negocio;
using Assistente.Excecoes;

namespace Assistente.View.Base.Forms
{
    public partial class frmApresValidacoes<T> : frmBase where T : Assistente.Entidades.Base.BaseID
    {
        private List<Negocio.Validacao> mobjValidacoes = null;
        private T mobjEntidade = null;
        private short mshtTempo = 0;

        public frmApresValidacoes()
        {
            tslTitulo.Text = "Validação";
            InitializeComponent();
        }

        internal bool Carregar(List<Assistente.Negocio.Validacao> vobjValidacoes, T vobjEntidade)
        {
            try
            {
                mobjValidacoes = vobjValidacoes;
                mobjEntidade = vobjEntidade;
                this.Show();
                CarregarValidacoes();
                return Validar();
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));
                return false;
            }

        }

        private void CarregarValidacoes()
        {
            dgvErros.Rows.Clear();

            foreach (Negocio.Validacao item in mobjValidacoes)
            {
                object[] lobjRow = {item, item.Ordem, item.Descricao,  Properties.Resources.Wait_icon, "" };
                dgvErros.Rows.Add(lobjRow);
            }
            if (mobjEntidade != null)
                dgvErros.Rows.Add(new object[] { null, dgvErros.Rows.Count + 1, "Salvar o registro", Properties.Resources.Wait_icon, "" });
        }

        private bool Validar()
        {
            bool lblnDadosValidos = true;

            for (int i = 0; i < dgvErros.Rows.Count; i++)
            {
                Validacao validacao = (Validacao)dgvErros.Rows[i].Cells[colValidacao.Index].Value;
                if (validacao != null)
                {
                    validacao.Valido = true;
                    foreach (var item in validacao.Tipos)
                    {
                        if (!Negocio.Util.Validador.ValidarObjeto(item, ref validacao))
                        {
                            if (validacao.Valido)
                            {
                                validacao.Valido = false;
                                dgvErros.Rows[i].Cells[colStatus.Index].Value = Properties.Resources.stop__2_;
                            }
                        } 
                        dgvErros.Rows[i].Cells[colMensagem.Index].Value = validacao.MsgRetorno;
                    }
                    if (validacao.Valido)
                        dgvErros.Rows[i].Cells[colStatus.Index].Value = Properties.Resources.v_cinza;
                    else
                        lblnDadosValidos = false;
                    mobjValidacoes[i] = validacao;
                }
            }
            if (mobjEntidade != null)
            {
                if (lblnDadosValidos)
                {
                    if (Conexao.TrataDAO.getAcesso<T>().Salvar(mobjEntidade))
                    {
                        dgvErros.Rows[dgvErros.Rows.Count - 1].Cells[colStatus.Index].Value = Properties.Resources.v_cinza;
                        tmrFechamento.Start();
                        dgvErros.Rows[dgvErros.Rows.Count - 1].Cells[colMensagem.Index].Value = "Registro salvo com sucesso.";
                    }
                    else
                    {
                        dgvErros.Rows[dgvErros.Rows.Count - 1].Cells[colStatus.Index].Value = Properties.Resources.stop__2_;
                        lblnDadosValidos = false;
                        dgvErros.Rows[dgvErros.Rows.Count - 1].Cells[colMensagem.Index].Value = "Ocorreu um erro ao salvar o registro.";
                    }
                }
                else
                {
                    Conexao.TrataDAO.getAcesso<T>().Evict(mobjEntidade);
                    dgvErros.Rows[dgvErros.Rows.Count - 1].Cells[colStatus.Index].Value = Properties.Resources.stop__2_;
                    dgvErros.Rows[dgvErros.Rows.Count - 1].Cells[colMensagem.Index].Value = "A validação não foi realizada com sucesso.";
                }
            }
            return lblnDadosValidos;
        }

        private void tmrFechamento_Tick(object sender, EventArgs e)
        {
            try
            {
                if (mshtTempo == 0)
                {
                    if (tssStatus.Text == "Esta janela fechará em " + (mshtTempo + 1) + " segundos.")
                        this.Sair(sender, e);
                    else
                        if(mobjValidacoes.Where(x=>x.Status == StatusValidacao.Erro).Count()>0)
                            mshtTempo = 10;
                        else
                            mshtTempo = 2;
                }
                BarraMensagem("Esta janela fechará em " + mshtTempo + " segundos.");
                mshtTempo--;
            }
            catch (Exception ex)
            {
                WinControls.ApresentarErro(AssistErroException.TratarErro(ex));               
            }
        }
    }
}
