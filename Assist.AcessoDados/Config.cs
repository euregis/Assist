using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assistente.AcessoDados
{
    public sealed class Config
    {
        public static Conexao.FluentNHibernate.Conexao Conexao { get; set; }
        public static bool ValidaSessao()
        {
            if (Conexao == null)
                throw new Exception("A conexão é inválida ou não definida.");

            if(Conexao.Sessao == null)
                throw new Exception("A sessão é inválida ou não definida.");
            return true;
        }

        
    }
}
