using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using Assistente.Entidades.Base;
using Conexao.FluentNHibernate;
using Assistente.Entidades.Filtros;

namespace Assistente.AcessoDados.Interfaces
{
    public interface IAcessoUtil
    {
        DateTime GetDate();
        int NovoCodigo<T>(string coluna) where T : Entidades.Base.BaseCod;
        int NovoCodigo<T>() where T : Entidades.Base.BaseCod;
        bool DescricaoExiste<T>(string descricao) where T : Entidades.Base.BaseCodDescr;
    }
}