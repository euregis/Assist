using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assistente.Excecoes
{
    public class AssistException:System.Exception
    {
        public AssistInfoValidacao Informacao { set; get; }

        public AssistException()
            : base()
        {
            Informacao = new AssistInfoValidacao();
        }

        [Obsolete("A propriedade não pode ser acessada diretamente, utilize GetMessage().")]
        public new string Message
        {
            get { throw new System.Exception("Erro inesperado. Uso inválido de função. Por favor, contate o suporte técnico."); }
        }

        public AssistException(string mensagem):base(mensagem) {}

        public string GetMessage()
        {
            if (Informacao.Parametros.Count() > 1)
                return Informacao.Parametros[0] + "\r\n\r\nOrigem do Erro => " + Informacao.Parametros[1];
            else
                throw new System.NotImplementedException();
        }
    }
}
