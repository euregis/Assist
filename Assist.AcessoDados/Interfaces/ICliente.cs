using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assistente.AcessoDados.Interfaces
{
    public interface ICliente : IAcesso<Entidades.Projeto>
    {
        int NovoCodigo();
        bool NomeExiste(string nome);
    }
}
