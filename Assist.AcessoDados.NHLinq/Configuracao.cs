using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assistente.AcessoDados.Interfaces;
using Assistente.Entidades;
using NHibernate.Criterion;

namespace Assistente.AcessoDados.NHLinq
{
    public class Configuracao : BaseDAO<Entidades.Configuracao>,IConfiguracao
    {
        #region IConfiguracao Members

        public Assistente.Entidades.Configuracao Retorna_pCodigo(int codigo)
        {
            return this.RetornaUnico(x => x.Codigo== codigo);
        }
        #endregion
    }
}
