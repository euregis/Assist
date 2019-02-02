using System;
using System.IO;
using System.ComponentModel;
using Assistente.Negocio.Util;
using System.Windows.Forms;

namespace Assistente.Controle
{
    public enum TipoItem { 
        [Description("Caminho")]
        Caminho
    }
    public enum ColunasGrade { Id, PlugIn, Registro, Tipo, Descricao, Adicionais}

    public static class Comandos
    {
        public static bool ItemSelecionado(DataGridView dgv, TextBox txtBox)
        {
            bool retorno = false;
            string[] lstrTmp = { "", "" };
            if (dgv.SelectedRows.Count > 0)
            {
                switch (dgv.SelectedRows[0].Cells[(int)ColunasGrade.Tipo].Value.ToString())
                {
                    case "Caminho":
                        {
                            lstrTmp[0] = txtBox.Text.Trim().Substring(0, txtBox.Text.LastIndexOf('\\') + 1);
                            lstrTmp[1] = dgv.SelectedRows[0].Cells[(int)ColunasGrade.Descricao].Value.ToString();

                        Caminho:
                            if (Negocio.Util.Arquivos.CaminhoExiste(lstrTmp[0] + lstrTmp[1]))
                            {
                                txtBox.Text = lstrTmp[0] + lstrTmp[1] + "\\";
                            }
                            else if (Negocio.Util.Arquivos.ArquivoExiste(lstrTmp[0] + lstrTmp[1]))
                            {
                                txtBox.Text = lstrTmp[0] + lstrTmp[1];
                                System.Diagnostics.Process.Start(txtBox.Text);
                            }
                            else if (lstrTmp[0].Substring(0, lstrTmp.Length - 2) != @"\\")
                            {
                                lstrTmp[0] = txtBox.Text.Trim() + "\\";
                                goto Caminho;
                            }
                            txtBox.Focus();
                            txtBox.SelectionStart = txtBox.Text.Length;
                            retorno = true;
                            break;
                        }
                    //case "Configuracao":
                    //    {
                    //        lstrTmp[0] = txtBox.Text.Trim().Substring(0, txtBox.Text.LastIndexOf('\\') + 1);
                    //        lstrTmp[1] = dgv.SelectedRows[0].Cells[(int)ColunasGrade.Descricao].Value.ToString();

                    //        if (Negocio.Util.Validacao.CaminhoExiste(lstrTmp[0] + lstrTmp[1]))
                    //        {
                    //            txtBox.Text = lstrTmp[0] + lstrTmp[1] + "\\";
                    //        }
                    //        else if (Negocio.Util.Validacao.ArquivoExiste(lstrTmp[0] + lstrTmp[1]))
                    //        {
                    //            txtBox.Text = lstrTmp[0] + lstrTmp[1];
                    //            System.Diagnostics.Process.Start(txtBox.Text);
                    //        }
                    //        else if (lstrTmp[0].Substring(0, lstrTmp.Length - 2) != @"\\")
                    //        {
                    //            lstrTmp[0] = txtBox.Text.Trim() + "\\";
                    //            goto Caminho;
                    //        }
                    //        txtBox.Focus();
                    //        txtBox.SelectionStart = txtBox.Text.Length;
                    //        break;
                    //    }

                    //case "Atalho":
                    //    {
                    //        Entidades.Atalho atalho = Conexao.TrataDAO.getAtalho().Retorna_pId(
                    //            int.Parse( dgv.SelectedRows[0].Cells[(int)ColunasGrade.Id].Value.ToString()));

                    //        if (Negocio.Util.Validacao.ArquivoExiste(atalho.Caminho)) 
                    //        {
                    //            txtBox.Text = "";
                    //            System.Diagnostics.Process.Start(atalho.Caminho);
                    //        }
                    //        else if (Negocio.Util.Validacao.CaminhoExiste(atalho.Caminho))
                    //        {
                    //            txtBox.Text = atalho.Caminho;
                    //        }
                    //        txtBox.Focus();
                    //        txtBox.SelectionStart = txtBox.Text.Length;
                    //        break;
                    //    }
                    default:
                        //IPlugIn plugIn = (IPlugIn)dgv.SelectedRows[0].Cells[(int)ColunasGrade.PlugIn].Value;
                        //Registro registro = (Registro)dgv.SelectedRows[0].Cells[(int)ColunasGrade.Registro].Value;
                        //if (plugIn != null && registro != null)
                        //{
                        //    Component dgv1 = (Component)dgv;
                        //    Component txt1 = (Component)txtBox;
                        //    plugIn.TratarRegistro(registro, ref dgv1, ref txt1);
                        //    retorno = true;
                        //}

                        break;
                }
            }
            return retorno;
        }
        public static void CaminhosArquivos(DataGridView dgv, string comando)
        {
            comando = comando.Trim();
            DirectoryInfo caminho;
            if (comando.Length > 2 && Negocio.Util.Arquivos.CaminhoExiste(comando))
            {
                caminho = new DirectoryInfo(comando);
                foreach (var item in caminho.GetDirectories())
                {
                    try
                    {
                        object[] itens = { "0", null, null, TrataEnum.ObterDescricao(TipoItem.Caminho), item.Name, item.GetDirectories().Length.ToString() + " Subpastas" };
                        dgv.Rows.Add(itens);
                    }
                    catch (Exception) { }
                }
                foreach (var item in caminho.GetFiles())
                {
                    try
                    {
                        object[] itens = { "0", null, null, TrataEnum.ObterDescricao(TipoItem.Caminho), item.Name, "Extensão \"" + item.Extension + "\"" };
                        dgv.Rows.Add(itens);
                    }
                    catch (Exception) { }
                }
            }
            else if ((comando.LastIndexOf("\\") > 1 && comando.LastIndexOf("\\") < comando.Length - 1 && comando.Substring(0, 2) != "\\\\")
                || comando.Split('\\').Length > 4)
            {
                caminho = new DirectoryInfo(comando.Substring(0, comando.LastIndexOf("\\") + 1));

                if (caminho.Exists)
                {
                    foreach (var item in caminho.GetDirectories(comando.Substring(comando.LastIndexOf("\\") + 1) + "*"))
                    //.Where(
                    //x=> x.Name.ToUpper().IndexOf(txtComandos.Text.Trim().Substring(txtComandos.Text.Trim().LastIndexOf("\\")+1).ToUpper())==0))
                    {
                        try
                        {
                            object[] itens = { "0", null , null, Enum.GetName(typeof(TipoItem),TipoItem.Caminho), 
                                                     item.Name, item.GetDirectories().Length.ToString() + " Subpastas" };
                            dgv.Rows.Add(itens);
                        }
                        catch (Exception) { }
                    }
                    foreach (var item in caminho.GetFiles(comando.Substring(comando.LastIndexOf("\\") + 1) + "*"))
                    //.Where(
                    //x=> x.Name.ToUpper().IndexOf(txtComandos.Text.Trim().Substring(txtComandos.Text.Trim().LastIndexOf("\\")+1).ToUpper())==0))
                    {
                        try
                        {
                            object[] itens = { "0", null, null, Enum.GetName(typeof(TipoItem),TipoItem.Caminho), 
                                                      item.Name, "Extensão \""+item.Extension+"\""};
                            dgv.Rows.Add(itens);
                        }
                        catch (Exception) { }
                    }

                }

            }
        }
    }
    

}
