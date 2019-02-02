using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assistente.Entidades;
using System.Reflection;
using System.IO;

namespace Assistente.Negocio.Util
{
    public sealed class Validador
    {
        public static bool SenhaAmbiente(string senhaDigitada)
        {
            return SenhaAmbiente(senhaDigitada, (Ambiente)null);
        }
        public static bool SenhaAmbiente(string senhaDigitada, Ambiente ambiente)
        {
            if (ambiente != null)
                return ambiente.Senha == senhaDigitada;
            else
                return Geral.AmbienteLocal.Senha == senhaDigitada;
        }

        public static bool IsType(string caminho, Type tipo)
        {
            List<Type> tipos = new List<Type>();
            IList<string> arquivos = new List<string>();


            DirectoryInfo DInfo = new DirectoryInfo(Path.GetDirectoryName(caminho));
            foreach (var item in DInfo.GetFiles())
            {
                if (!Arquivos.ArquivoExiste(AppDomain.CurrentDomain.BaseDirectory + item.Name))
                {
                    Arquivos.CopiarArquivo(item.FullName, AppDomain.CurrentDomain.BaseDirectory, false);
                    arquivos.Add(AppDomain.CurrentDomain.BaseDirectory + item.Name);
                }
            }

            tipos.AddRange(Assembly.LoadFile(caminho).GetTypes());

            foreach (var item in arquivos) 
                Arquivos.ExcluirArquivo(item); 

            List<Type> operacoes = tipos.FindAll(delegate(Type t)
        {
            List<Type> interfaces = new List<Type>(t.GetInterfaces());
            return interfaces.Contains(tipo);
        });
            return (operacoes.Count > 0);
        }
        public static bool IsType(Type verificado, Type tipo)
        {
            return verificado.GetInterfaces().Contains(tipo);
        }
        public static bool FormatoValido(TipoValidacao valid, params object[] valores)
        {
            return true;
        }
        public static bool FormatoValido(string metodo, params object[] valores)
        {
            return true;
        }
        
        public static bool ValidarObjeto(TipoValidacao vobjTipo, ref Validacao robjValidacao)
        {
            bool retorno = true;
            robjValidacao.MsgRetorno += (String.IsNullOrEmpty(robjValidacao.MsgRetorno) ? "" : "\r\n");
            switch (vobjTipo)
            {
                case TipoValidacao.Todos:
                    break;
                case TipoValidacao.Nenhuma:
                    break;
                case TipoValidacao.SimNao:
                    retorno = SimNao((string)robjValidacao.Valores[0]);
                    if (!retorno)
                    {
                        if (robjValidacao.Valido) robjValidacao.MsgRetorno = "";
                        robjValidacao.MsgRetorno += "Formato não reconhecido. Informe Sim ou Não.";
                    }
                    else if (robjValidacao.Valido)
                        robjValidacao.MsgRetorno += "Formato reconhecido.";
                    break;
                case TipoValidacao.Numerico:
                    break;
                case TipoValidacao.Alfanumérico:
                    break;
                case TipoValidacao.Preenchido:
                    retorno = Preenchido(robjValidacao.Valores[0].ToString());
                    if (!retorno)
                    {
                        if (robjValidacao.Valido) robjValidacao.MsgRetorno = "";
                        robjValidacao.MsgRetorno += "O campo não foi preenchido.";
                    }
                    else if (robjValidacao.Valido)
                        robjValidacao.MsgRetorno += "O campo foi preenchido.";
                    break;
                case TipoValidacao.CaminhoExiste:
                    retorno = Arquivos.CaminhoExiste((string)robjValidacao.Valores[0]) ;
                    if (!retorno)
                    {
                        if (robjValidacao.Valido) robjValidacao.MsgRetorno = "";
                        robjValidacao.MsgRetorno += "O caminho informado não foi encontrado.";
                    }
                    else if (robjValidacao.Valido)
                        robjValidacao.MsgRetorno += "O caminho informado existe.";
                    break;
                case TipoValidacao.ModoExibicaoAssistente:
                    retorno = ModoExibicaoAssistente((string)robjValidacao.Valores[0]);
                    if (!retorno)
                    {
                        if (robjValidacao.Valido) robjValidacao.MsgRetorno = "";
                        robjValidacao.MsgRetorno += "O valor informado não corresponde a um Modo de Exibição.";
                    }
                    else if (robjValidacao.Valido)
                        robjValidacao.MsgRetorno += "O valor informado corresponde a um Modo de Exibição.";
                    break;
                case TipoValidacao.NomeClienteDuplicado:
                    retorno = !NomeClienteDuplicado((string)robjValidacao.Valores[0]);
                    if (!retorno)
                    {
                        if (robjValidacao.Valido) robjValidacao.MsgRetorno = "";
                        robjValidacao.MsgRetorno += "O Nome informado já existe para outro Cliente.";
                    }
                    else if (robjValidacao.Valido)
                        robjValidacao.MsgRetorno += "Não existe outro cliente com o nome informado.";
                    break;
                case TipoValidacao.ArquivoCaminhoExiste:
                    retorno = Arquivos.CaminhoExiste((string)robjValidacao.Valores[0])
                        || Arquivos.ArquivoExiste((string)robjValidacao.Valores[0]);
                    if (!retorno)
                    {
                        if (robjValidacao.Valido) robjValidacao.MsgRetorno = "";
                        robjValidacao.MsgRetorno += "O caminho informado não foi encontrado.";
                    }
                    else if (robjValidacao.Valido)
                        robjValidacao.MsgRetorno += "O caminho informado existe.";
                    break;
                case TipoValidacao.ArquivoExiste:
                    retorno = Arquivos.ArquivoExiste((string)robjValidacao.Valores[0]);
                    if (!retorno)
                    {
                        if (robjValidacao.Valido) robjValidacao.MsgRetorno = "";
                        robjValidacao.MsgRetorno += "O arquivo informado não foi encontrado.";
                    }
                    else if (robjValidacao.Valido)
                        robjValidacao.MsgRetorno += "O arquivo informado existe.";
                    break;
                case TipoValidacao.ReferenciasPlugIn:
                    retorno = ReferenciasPlugIn(ref robjValidacao);
                    break;
                default:
                    break;
            }
            if (robjValidacao.MsgRetorno.Length > 2
                && robjValidacao.MsgRetorno.LastIndexOf("\r\n") == robjValidacao.MsgRetorno.Length - 2)
                robjValidacao.MsgRetorno = robjValidacao.MsgRetorno.Substring(0, robjValidacao.MsgRetorno.Length - 2);
            return retorno;
        }

        private static bool ReferenciasPlugIn(ref Validacao robjValidacao)
        {
            string falta = "";
            if (!Arquivos.ArquivoExiste((string)robjValidacao.Valores[0]))
            {
                if (robjValidacao.Valido) robjValidacao.MsgRetorno = "";
                robjValidacao.MsgRetorno += "O arquivo informado não foi encontrado.";
                return false;
            }
            Assembly assembly = Assembly.LoadFile((string)robjValidacao.Valores[0]);
            string[] padrao = { };
            List<string> utilizados = new List<string>();
            IList<Entidades.PlugIn> plugIns = BancoDados.DAO.getAcesso<Entidades.PlugIn>().Retorna();

            foreach (var item in AppDomain.CurrentDomain.GetAssemblies())
            {
                //bool existe = false;
                //foreach (var item2 in plugIns)
                //{
                //    if (item2.Nome == item.GetName().Name)
                //        existe = true;

                //}
                //if (!existe)
                utilizados.Add(item.GetName().Name);
            }
            foreach (var item in assembly.GetReferencedAssemblies())
            {
                if (padrao.Contains(item.Name) || utilizados.Contains(item.Name))
                    continue;

                falta = item.Name + ", ";
            }
            if (falta.Trim().Length > 0)
            {
                if (robjValidacao.Valido) robjValidacao.MsgRetorno = "";
                robjValidacao.MsgRetorno += "O arquivo informado não foi encontrado.";
                return false;
            }

            //if (!ArquivoExiste((string)robjValidacao.Valores[0]))
            //{
            //    if (robjValidacao.Valido) robjValidacao.MsgRetorno = "";
            //    robjValidacao.MsgRetorno += "O arquivo informado não foi encontrado.";
            //    return false;
            //}
            robjValidacao.MsgRetorno += "As referencias do PlugIn foram validados.";
            return true;
        }
        public static bool SimNao(string texto)
        {
            string aux = texto.TirarAcentos().ToUpper();
            return aux == "SIM" || aux == "NAO";
        }
        public static bool Preenchido(string texto)
        {
            if (texto != null) texto = texto.Trim();
            return !String.IsNullOrEmpty(texto);
        }

        public static bool NomeClienteDuplicado(string nome)
        {
            return BancoDados.DAO.getCliente().NomeExiste(nome);
        }

        public static bool ModoExibicaoAssistente(string modo) {
            
            foreach (var item in Enum.GetValues(typeof(ModoExibicaoAssistente)))
            {
                
                if (TrataEnum.ObterDescricao((ModoExibicaoAssistente)item).Equals(modo)) return true;
            }
            return false;
            //return TrataEnum.Listar(typeof(ModoExibicaoAssistente), false).Contains(modo);
        }

        //public static bool FormatoValido(Entidades.Validacao valid, params object[] valores)
        //{
        //    try
        //    {
        //        MethodInfo method = Type.GetType(valid.Classe).GetMethod(valid.Metodo);
        //        object[] arguments = { valores };
        //        //method = method.MakeGenericMethod(item.PropertyType.GetProperties()[0].PropertyType);
        //        bool ret = (bool)method.Invoke(null, arguments);
        //        return ret;
        //    }
        //    catch (Exception) { return false; }
        //}

        //public static bool FormatoValido(string caminho, FormatoValidacao fmtValid)
        //{
        //    int ini = 0, fim = 0;
        //    ini = fmtValid.Formato.IndexOf("[", ini);
        //    //fim = fmtValid.Formato.IndexOf("]", ini);
        //    if (ini > 0)
        //    {
        //        for (int i = ini; i < fmtValid.Formato.Length; i++)
        //            if (caminho[i] != fmtValid.Formato[i]) return false;

        //        if(fmtValid.Formato.Substring(fim+1,)

        //    }




        //    fim = fmtValid.Formato.IndexOf("]", ini);


        //    while (ini >= 0)
        //    {
        //        ini = fmtValid.Formato.IndexOf("[", ini);
        //        fim = fmtValid.Formato.IndexOf("]", ini);

        //        if (ini >= 0 && fim >= 0)
        //        {
        //            string aux = fmtValid.Formato.Substring(++ini, fim - ini);
        //            if (aux.Contains('|') || aux.Contains('[') || aux.Contains(']') || aux.Contains('-') || aux.Contains(','))
        //            { 

        //            }
        //            else
        //            {
        //                if (caminho == aux) return true;
        //            }
        //        }
        //    }
        //    return true;
        //}
   }
}
