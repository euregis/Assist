using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Assistente.Entidades.Filtros
{
    public class FiltroTexto : Filtro
    {
        public PosicaoProcura PosicaoProcura { get; set; }

        public FiltroTexto() { }
        public FiltroTexto(PropertyInfo propriedade, PosicaoProcura posicaoProcura, string nomeExibicao,
             Object valorUsado1, Object valorLimpo1)
        {
            this.TipoFiltro = TipoFiltro.Texto;
            this.PosicaoProcura = posicaoProcura;
            this.Propriedade = propriedade;
            this.NomeExibicao = nomeExibicao;
            this.ValorUsado1 = valorUsado1;
            this.ValorLimpo1 = valorLimpo1;
            if (!String.IsNullOrEmpty((string)valorUsado1))
                Utilizado = true;
        }
    }
}
