    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Assistente.Entidades.Filtros
{
    public enum TipoFiltro { Data, Texto, Checkbox,Combo, Decimal, NumInteiro }
    public enum TipoProcura { Apartir, Ate, Exato, Entre }
    public enum PosicaoProcura { Inicio, Fim, Exato, Qualquer }

    public class Filtro
    {
        public TipoFiltro TipoFiltro { get; set; }
        public PropertyInfo Propriedade { get; set; }
        public string NomeExibicao { get; set; }
        public Object ValorUsado1 { get; set; }
        public Object ValorLimpo1 { get; set; }
        public string Controle1 { get; set; }   
        public bool Utilizado { get; set; }

    }
}
