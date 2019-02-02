using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assistente.AcessoDados.Interfaces;
using NHibernate;
using Assistente.Entidades.Base;

namespace Assistente.AcessoDados.NHLinq
{
    public class NHLinqFactory:IAcessoFactory
    {
        public NHLinqFactory(ref Conexao.FluentNHibernate.Conexao cn)
        {
            Config.Conexao = cn;
        }
        public IAcesso<T> getAcesso<T>() where T : Assistente.Entidades.Base.BaseID
        {
            return new BaseDAO<T>();
        }
        public IAcessoUtil getAcessoUtil() 
        {
            return new BaseDAO<Assistente.Entidades.Base.BaseID>();
        }

        public IConfiguracao getConfiguracao()
        {
            return new Configuracao();
        }
        public ICliente getCliente()
        {
            return new Projeto();
        }
        public IPasta getPasta()
        {
            return new Pasta();
        }
        public ITarefa getTarefa()
        {
            return new Tarefa();
        }
    }
}
