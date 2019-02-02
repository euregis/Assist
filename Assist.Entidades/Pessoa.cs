using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assistente.Entidades
{
    public class Pessoa : Entidades.Base.BaseID
    {
        public virtual String Nome { get; set; }
        
        public override string ToString()
        {
            return Nome;
        }
    }
}
