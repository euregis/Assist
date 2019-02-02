using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Assistente.Entidades
{
    
    public class PlugIn : Base.BaseID
    {
        public virtual string Nome { get; set; }
        public virtual string Versao { get; set; }
        public virtual string Caminho { get; set; }
        public virtual bool Inativo { get; set; }
        public virtual Ambiente Ambiente { get; set; }
        //public virtual IList<DependenciaPlugIn> Dependencias { get; set; }
        //public virtual IList<DataBase> DataBases { get; set; }
        //public virtual IList<Atalho> Pastas { get; set; }

        public PlugIn()
        {
            //System.Reflection.Assembly a;
            //System.Reflection.AssemblyName[] aa= a.GetReferencedAssemblies();
            //aa.GetValue(
        }
        public override string ToString()
        {
            return Nome;
        }
        
    }
}
