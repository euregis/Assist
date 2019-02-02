using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Assistente.AcessoDados.Interfaces;

namespace Assistente.AcessoDados
{
    public enum TipoDAO { NHibernate, SQLServer }
    public interface IDAOFactory
    {
        //IAcessoFactory getFactory(TipoDAO tpDAO);
        //IAcessoFactory getFactory(TipoDAO tpDAO, Conexao.FluentNHibernate.Conexao conexao);       
        
    }
}
