using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

namespace Assistente.Entidades.Filtros
{
    public class FiltroCheckbox : Filtro
    {
        public bool IsEnum { get; set; }
        public bool OpcaoTodos { get; set; }
        public ArrayList Lista { get; set; }
        public Type Tipo { get; set; }

        public FiltroCheckbox() { }

        public FiltroCheckbox(PropertyInfo propriedade, string nomeExibicao, byte valorUsado1,
            byte valorLimpo1)
        {
            this.TipoFiltro = TipoFiltro.Checkbox;
            this.Propriedade = propriedade;
            this.NomeExibicao = nomeExibicao;
            this.ValorUsado1 = valorUsado1;
            this.ValorLimpo1 = valorLimpo1;
        }
    }
}
