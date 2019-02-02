using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assistente.Entidades
{
    public class Pendencia:Base.BaseCodDescr
    {
        public virtual Tarefa Tarefa { get; set; }
        public virtual DateTime DataCadastro { get; set; }
        public virtual DateTime? DataConclusao { get; set; }
        
        public Pendencia()
        {
        }

        public override string ToString()
        {
            return Descricao;
        }
    }
}
