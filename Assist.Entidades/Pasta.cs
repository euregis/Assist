using System;
using System.Collections.Generic;
using Assistente.Entidades;

namespace Assistente.Entidades    
{
    public class Pasta : Assistente.Entidades.Base.BaseID
    {
        public virtual String Caminho { get; set; }
        public virtual String Descricao { get; set; }
        public virtual Ambiente Ambiente { get; set; }
        public virtual Tarefa Tarefa { get; set; }
        public virtual Projeto Cliente { get; set; } 

        public Pasta()
        {
        }

        public override string ToString()
        {
            return Caminho;
        }

        
    }
}
