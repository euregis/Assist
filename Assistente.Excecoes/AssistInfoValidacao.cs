using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assistente.Excecoes
{
    public class AssistInfoValidacao
    {
        public int Codigo { get; set; }
        public string[] Parametros { set; get; }

        public void SetParametros(params string[] parametros)
        {
            Parametros = parametros;
        }
    }
}
