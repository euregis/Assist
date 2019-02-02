using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Assistente.AcessoDados.Interfaces;

namespace Assistente.AcessoDados
{
    public enum TipoFactory { NHCriteria, NHLinq }
    public sealed class Factory
    {
        //public static IAcessoFactory CriarAcesso(TipoFactory tpFactory, ref Conexao.FluentNHibernate.Conexao cn)
        //{
        //    IAcessoFactory factory = null;
        //     switch (tpFactory)
        //    {
        //        case TipoFactory.NHCriteria:
        //            factory = new NHCriteria.NHCritFactory(ref cn);
        //            break;
        //        case TipoFactory.NHLinq:
        //            factory = new NHLinq.NHLinqFactory(ref cn);
        //            break;
        //        default:
        //            break;
        //    }
        //    return factory;
        //}
    }
}
