using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assistente.Entidades.Atributos;

namespace Assistente.Entidades
{
    public class Ambiente : Entidades.Base.BaseID
    {
        [Map("Nome", 30,Obrigatorio=true)]
        public virtual string Nome { get; set; }

        [Map("Senha", 15, Obrigatorio = true)]
        public virtual string Senha { get; set; }
        
        [Map("Caminho Local", 150, Obrigatorio = true)]
        public virtual string CaminhoLocal { get; set; }
        
        [Map("Caminho PenDrive", 150)]
        public virtual string CaminhoPenDrive { get; set; }
        //public virtual IList<Atalho> Atalhos { get; set; }


        public virtual string PosicaoTela { get; set; }

        public Ambiente() { //Atalhos = new List<Atalho>(); 
        }
        public override string ToString()
        {
            return Nome;
        }
    }
}
