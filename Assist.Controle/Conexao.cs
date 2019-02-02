using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using Assistente.Negocio.Util;
using Assistente.AcessoDados.Interfaces;
namespace Assistente.Controle
{

    public sealed class Conexao
    {
        public static IAcessoFactory TrataDAO{get{return Negocio.BancoDados.DAO;}}
        
    }
}

