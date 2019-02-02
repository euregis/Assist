using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assistente.AcessoDados.Interfaces;
using Assistente.Entidades;
using NHibernate.Criterion;

namespace Assistente.AcessoDados
{
    public interface IPasta : IAcesso<Entidades.Pasta>
    {
        IList<Entidades.Pasta> Retorna_pAmbiente(Ambiente amb);
        
    }
}
