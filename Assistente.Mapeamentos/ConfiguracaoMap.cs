using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Assistente.Entidades;

namespace Assistente.Mapeamentos
{
    public class ConfiguracaoMap:ClassMap<Configuracao>
    {
        public ConfiguracaoMap()
        {
            Id(x => x.Id);
            Map(x => x.Codigo).Not.Nullable().Unique().Length(6);
            Map(x => x.Descricao).Not.Nullable().Unique().Length(60);
            Map(x => x.Valor).Not.Nullable().Length(2000);
            Map(x => x.Validacao).Not.Nullable();
        }
    }
}
