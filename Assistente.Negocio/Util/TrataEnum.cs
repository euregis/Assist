using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Collections;

namespace Assistente.Negocio.Util
{
    public sealed class TrataEnum
    {
        /// <summary>Obtém a descrição de um determinado Enumerador.</summary>
        /// <param name="valor">Enumerador que terá a descrição obtida.</param>
        /// <returns>String com a descrição do Enumerador.</returns>
        public static string ObterDescricao(Enum valor)
        {
            FieldInfo fieldInfo = valor.GetType().GetField(valor.ToString());
            DescriptionAttribute[] atributos = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return atributos.Length > 0 ? atributos[0].Description ?? "Nulo" : valor.ToString();
        }
        /// <summary>Retorna uma lista com os valores de um determinado enumerador.</summary>
        /// <param name="tipo">Enumerador que terá os valores listados.</param>
        /// <returns>Lista com os valores do Enumerador.</returns>
        public static IList Listar(Type tipo, bool todos)
        {
            ArrayList lista = new ArrayList();
            if (tipo != null)
            {
                Array enumValores = Enum.GetValues(tipo);
                foreach (Enum valor in enumValores)
                    if ((todos && ObterDescricao(valor).Equals("Todos"))
                        || !ObterDescricao(valor).Equals("Todos"))
                        lista.Add(new KeyValuePair<Enum, string>(valor, ObterDescricao(valor)));
            }
            return lista;
        }




    }
}
