using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assistente.AcessoDados.Interfaces;
using Assistente.Entidades;
using NHibernate.Criterion;

namespace Assistente.AcessoDados.NHLinq
{
    public class Pasta : BaseDAO<Entidades.Pasta>, IPasta
    {
        #region IPasta Members

        public IList<Entidades.Pasta> Retorna_pAmbiente(Ambiente amb)
        {
            return Retorna(x=>x.Ambiente== amb);
        }

        #endregion
    }
}
