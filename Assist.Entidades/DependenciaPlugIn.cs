using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Assistente.Entidades
{

    public class DependenciaPlugIn : Base.BaseID
    {
        public virtual string Nome { get; set; }
        public virtual string Caminho { get; set; }
        //public virtual IList<DataBase> DataBases { get; set; }
        //public virtual IList<Atalho> Pastas { get; set; }

        public DependenciaPlugIn()
        {
            //System.Reflection.Assembly a;
            //System.Reflection.AssemblyName[] aa= a.GetReferencedAssemblies();
            //aa.GetValue(
        }

        //public virtual void AddTarefa(Tarefa tarefa)
        //{
        //    Tarefas.Add(tarefa);
        //    tarefa.Cliente = this;
        //}

    }
}
