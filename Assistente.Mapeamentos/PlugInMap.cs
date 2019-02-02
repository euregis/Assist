using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Assistente.Entidades;

namespace Assistente.Mapeamentos
{
    public class PlugInMap : ClassMap<PlugIn>
    {
        public PlugInMap()
        {
            Id(x => x.Id);
            Map(x => x.Nome).Not.Nullable().Length(30);
            Map(x => x.Versao).Not.Nullable().Length(15);
            Map(x => x.Caminho).Not.Nullable().Length(100);
            Map(x => x.Inativo).Not.Nullable();
            References(x => x.Ambiente).ForeignKey();
            //HasMany(x => x.Pastas)
            //    .Cascade.All()
            //    .Inverse();

        }
    }
}
