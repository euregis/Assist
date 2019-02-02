using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using Assistente.Entidades.Base;
using Conexao.FluentNHibernate;
using System.Linq.Expressions;
using Assistente.Entidades.Filtros;

namespace Assistente.AcessoDados.Interfaces
{
    public interface IAcesso<T>
    {
        IList<string> Erros{get;set;}
        bool Salvar(T obj);
        bool Evict(T obj);
        bool Excluir(T obj);
        T Retorna_pId(int id);
        IList<T> Retorna();
        IList<T> Retorna(Expression<Func<T, bool>> where);

        IList<T> Retorna_pFiltros(List<Filtro> filtros);
    }
}