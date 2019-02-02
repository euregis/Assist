using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assistente.AcessoDados.Interfaces
{
    public interface IConfiguracao : IAcesso<Entidades.Configuracao>
    {
        Assistente.Entidades.Configuracao Retorna_pCodigo(int codigo);
    }
}
