using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Assistente.Entidades.Filtros
{
    public class FiltroDecimal : Filtro
    {
        public TipoProcura TipoProcura { get; set; }
        public Object ValorUsado2 { get; set; }
        public Object ValorLimpo2 { get; set; }
        public string Controle2 { get; set; }

        public FiltroDecimal() { }
        public FiltroDecimal(PropertyInfo propriedade, TipoProcura tipoProcura, string nomeExibicao,
             Object valorUsado1, Object valorUsado2, Object valorLimpo1, Object valorLimpo2)
        {
            this.TipoFiltro = TipoFiltro.Decimal;
            this.TipoProcura = tipoProcura;
            this.Propriedade = propriedade;
            this.NomeExibicao = nomeExibicao;
            this.ValorUsado1 = valorUsado1;
            this.ValorUsado2 = valorUsado2;
            this.ValorLimpo1 = valorLimpo1;
            this.ValorLimpo2 = valorLimpo2;

        }
    }
}
