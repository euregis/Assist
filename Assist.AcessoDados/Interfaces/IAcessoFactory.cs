using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assistente.Entidades.Base;

namespace Assistente.AcessoDados.Interfaces
{
    public interface IAcessoFactory
    {
        IAcesso<T> getAcesso<T>() where T : Assistente.Entidades.Base.BaseID;
        IAcessoUtil getAcessoUtil();
        IConfiguracao getConfiguracao();
        ICliente getCliente();
        IPasta getPasta();
        ITarefa getTarefa();
    }
}
