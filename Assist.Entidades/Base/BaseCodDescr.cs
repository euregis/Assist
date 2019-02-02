using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assistente.Entidades.Base
{
    public class BaseCodDescr:BaseCod
    {
        public virtual string Descricao { get; set; }

        public override string ToString()
        {
            return Descricao;
        } 
    }
}
