using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assistente.Negocio.Util
{
    public static class Conversor
    {
        public static bool ParaBool(string valor)
        {
            string booleano = valor.TirarAcentos().ToUpper();

            return (booleano == "SIM");
        }
        public static string ParaSimNao(bool valor)
        {
            if (valor)
                return "Sim";
            else
                return "Não";
        }

    }
}
