using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Assistente.Entidades;

namespace Assistente.Mapeamentos
{
    public class ProjetoMap : SubclassMap<Projeto>
    {
        public ProjetoMap()
        {
            Map(x => x.Codigo).Not.Nullable().Length(6);
            Map(x => x.Inativo).Not.Nullable();
            Map(x => x.CodigoRegis).Nullable();
            //HasMany(x => x.DataBases)
            //   .Cascade.All()
            //   .Inverse();
            HasMany(x => x.Tarefas)
               .Cascade.All()
               .Inverse();
            //HasMany(x => x.Pastas)
            //    .Cascade.All()
            //    .Inverse();

        }
    }
}
