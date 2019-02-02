using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assistente.AcessoDados.Interfaces;
using NHibernate.Criterion;
using Assistente.Entidades;

namespace Assistente.AcessoDados.NHLinq
{
    public class Tarefa : BaseDAO<Entidades.Tarefa>, ITarefa
    {

        #region ITarefa Members

        public IList<Assistente.Entidades.Tarefa> RetornaMenu()
        {
            IList<Entidades.Tarefa> tarSClie = this.Retorna(x => x.Status == (short)enuStatusTarefa.Projeto
                && x.Cliente == null).OrderBy(x => x.Descricao).ToList<Entidades.Tarefa>();
            IList<Entidades.Tarefa> tarCClie = this.Retorna(x => x.Status == (short)enuStatusTarefa.Projeto
                && x.Cliente != null).OrderBy(x => x.Cliente.Nome).ThenBy(y => y.Descricao).ToList<Entidades.Tarefa>();

            IList<Entidades.Tarefa> ret = new List<Entidades.Tarefa>();
            foreach (var item in tarSClie)
                ret.Add(item);
            foreach (var item in tarCClie)
                ret.Add(item);
            return ret;
            //return .OrderBy(x => x.Cliente).ThenBy(y => y.Descricao).ToList<Entidades.Tarefa>();//
        }

        #endregion
    }
}
