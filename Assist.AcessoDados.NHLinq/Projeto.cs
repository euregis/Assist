using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assistente.AcessoDados.Interfaces;

namespace Assistente.AcessoDados.NHLinq
{
    public class Projeto : BaseDAO<Entidades.Projeto>, ICliente
    {
        public int NovoCodigo()
        {
            try
            {
                IList<Entidades.Projeto> clies = Retorna();
                if (clies.Count == 0)
                    return 1;
                else
                {
                    int codigo = clies.Max(x => x.Codigo);
                    return codigo + 1;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool NomeExiste(string nome)
        {
            IList<Entidades.Projeto> clies = Retorna(x => x.Nome == nome);
            if (clies.Count > 0)
                return true;
            else
                return false;
        }
    }
}
