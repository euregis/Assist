//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using FluentNHibernate.Mapping;
//using Assistente.Entidades;

//namespace Assistente.Mapeamentos
//{
//    public class FormatoValidacaoMap : ClassMap<FormatoValidacao>
//    {
//        public FormatoValidacaoMap()
//        {
//            Id(x => x.Id);
//            Map(x => x.Codigo).Not.Nullable().Unique().Length(6);
//            Map(x => x.Formato).Not.Nullable().Length(255);
//            Map(x => x.Descricao).Not.Nullable().Unique().Length(60);
//            HasMany(x => x.Configuracoes)
//                .Cascade.All()
//                .Inverse();
//        }
//    }
//}
