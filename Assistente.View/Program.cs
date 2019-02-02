using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Assistente.View.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using Assistente.Negocio.Util;
using Assistente.Negocio;
using Assistente.Entidades.Configuracoes;

namespace Assistente.View
{
    static class Program
    {
        ///// <summary>
        ///// The main entry point for the application.
        ///// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new frmAssistente());

        //}
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //Serializacao.SerializaXml(new Config() {  CaminhoBase="dasdcascac"}, "D:\\config.xml");
                Geral.Config = Serializacao.DeserializaXml<Config>(AppDomain.CurrentDomain.BaseDirectory + "Config.xml");

                
                bool baseOK = false;

                //new Assistente.DAO.BaseDAO().Salvar(baseOK);
                Application.EnableVisualStyles();
                try
                {
                    Application.SetCompatibleTextRenderingDefault(false);
                }
                catch (Exception) { }

                baseOK = BancoDados.ValidaCaminhoBase();//AppDomain.CurrentDomain.BaseDirectory + "config.xml");

                if (!baseOK)
                {
                    System.Windows.Forms.FolderBrowserDialog fbdBackup;
                    fbdBackup = new System.Windows.Forms.FolderBrowserDialog();
                    fbdBackup.Description = "Informe o local onde está ou será armazenado o arquivo do banco de dados.";
                    if (fbdBackup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        baseOK = BancoDados.CriarBase(fbdBackup.SelectedPath.ToString() + "\\");//, AppDomain.CurrentDomain.BaseDirectory);
                }
                if (baseOK)
                {    //Application.Run(new Assistente.View.Forms.frmAssitente());
                    BancoDados.Config(TipoConexao.SQLite, new string[] { BancoDados.CaminhoBase + "AssistenteDB.db3" });

                    BancoDados.AbrirSessao();
                    //Geral.VerificarConfiguracoes();

                    //if (new Assistente.View.Forms.frmLogin().Carregar())
                    //{
                        //if (Geral.AmbienteLocal.CaminhoPenDrive.Trim().Length >0 
                        //    && File.Exists(Geral.AmbienteLocal.CaminhoPenDrive + "AssistenteDB.db3") &&
                        //MessageBox.Show("Deseja copiar o arquivo a base do Pen Drive?", "Base", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        //{
                        //    BancoDados.FecharSessao();
                        //    //if (File.Exists(Geral.AmbienteLocal.CaminhoLocal + "AssistenteDB.db3"))
                        //    File.Delete(Geral.AmbienteLocal.CaminhoLocal + "AssistenteDB.db3");
                        //    FileSystem.CopyFile(Geral.AmbienteLocal.CaminhoPenDrive + "AssistenteDB.db3",
                        //        Geral.AmbienteLocal.CaminhoLocal + "AssistenteDB.db3", UIOption.AllDialogs);
                        //    BancoDados.AbrirSessao();
                        //}
                        AtualizaVersao.AtualizarScripts();

                        //Application.Run(new Assistente.View.Forms.frmAssistente());
                        Application.Run(new Assistente.View.Forms.frmTarefas());

                        Serializacao.SerializaXml(Geral.Config, AppDomain.CurrentDomain.BaseDirectory + "Config.xml");

                        
                    //}
                }
            }
            catch (Exception ex)
            {
                Assistente.Controle.WinControls.ApresentarErro(Assistente.Excecoes.AssistErroException.TratarErro(ex));
            }
        }

        
    }
}
