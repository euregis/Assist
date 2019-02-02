using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Assistente.Entidades;

namespace Assistente.Mapeamentos
{
    public class PastaMap:ClassMap<Pasta>
    {
        public PastaMap()
        {
            Id(x => x.Id);
            Map(x => x.Descricao).Not.Nullable().Length(25);
            Map(x => x.Caminho).Not.Nullable().Length(150);
            References(x => x.Ambiente).ForeignKey();
            References(x => x.Tarefa).ForeignKey();
            References(x => x.Cliente).ForeignKey();
        }
    }
}
