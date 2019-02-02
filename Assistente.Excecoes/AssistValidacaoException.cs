using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assistente.Excecoes
{
    public class AssistValidacaoException : AssistException
    {
        public IList<AssistInfoValidacao> Informacoes { private set; get; }

        public AssistValidacaoException()
        {
            Informacoes = new List<AssistInfoValidacao>();
        }


    }
}
