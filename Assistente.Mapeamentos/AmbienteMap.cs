using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Assistente.Entidades;

namespace Assistente.Mapeamentos
{
    public class AmbienteMap:ClassMap<Ambiente>
    {
        public AmbienteMap()
        {
            Id(x => x.Id);
            Map(x => x.Nome).Not.Nullable().Unique().Length(30);
            Map(x => x.Senha).Not.Nullable().Length(15);
            Map(x => x.CaminhoLocal).Not.Nullable().Length(150);
            Map(x => x.CaminhoPenDrive).Length(150);
            Map(x => x.PosicaoTela).Not.Nullable().Length(10).Default("T0000L0000");
            //HasMany(x => x.Atalhos)
            //    .Cascade.AllDeleteOrphan()
            //    .Inverse();;
        }
    }
}
