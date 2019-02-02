using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assistente.Entidades;

namespace Assistente.AcessoDados.Interfaces
{
    public interface ITarefa:IAcesso<Tarefa>
    {
        IList<Tarefa> RetornaMenu();
    }
}
