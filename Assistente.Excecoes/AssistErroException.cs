using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assistente.Excecoes
{
    public sealed class AssistErroException:AssistException
    { public AssistErroException()
            : base()
        {
        }
        public AssistErroException(int codigo)
            : base()
        {
            Informacao.Codigo = codigo;
        }
        public AssistErroException(int codigo, string[] parametros)
            : this(codigo)
        {
            Informacao.Parametros = parametros;
        }
        public static AssistException TratarErro(System.Exception e)
        {
            AssistException retorno = null;

            if (e is AssistValidacaoException)
                retorno = (AssistValidacaoException)e;
            else if (e is AssistException)
                retorno = (AssistException)e;
            else
            {
                //throw new AssistException("Ocorreu o seguinte erro: \r\n" + e.Message);
                StringBuilder msgErro = new StringBuilder();
                System.Exception ex = e;
                while (ex != null)
                {
                    if (msgErro.Length > 0) msgErro.Append("\r\n");
                    msgErro.Append(ex.Message);
                    ex = ex.InnerException;
                }

                retorno = new AssistErroException();
                retorno.Informacao.Codigo = 0;
                retorno.Informacao.SetParametros(msgErro.ToString(), e.StackTrace);
            }

            return retorno;
        }
    }
}
