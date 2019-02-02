using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Assistente.Entidades
{
    public class Projeto : Pessoa, Base.IValidaDelete
    {
        public virtual Int32 Codigo { get; set; }
        public virtual bool Inativo { get; set; }
        public virtual IList<Tarefa> Tarefas { get; set; }
        public virtual string CodigoRegis{ get; set; }
        
        //public virtual IList<DataBase> DataBases { get; set; }
        //public virtual IList<Atalho> Pastas { get; set; }

        public Projeto()
        {
            //DataBases = new List<DataBase>();
            Tarefas = new List<Tarefa>();
            //Pastas = new List<Atalho>();
        }
        public override string ToString()
        {
            return string.IsNullOrEmpty(Nome)? "":Nome;
        }
        //public virtual void AddDataBase(DataBase dbase)
        //{
        //    DataBases.Add(dbase);
        //    dbase.Cliente= this;
        //}
        public virtual void AddTarefa(Tarefa tarefa)
        {
            Tarefas.Add(tarefa);
            tarefa.Cliente = this;
        }
        //public virtual void AddPasta(Atalho pasta)
        //{
        //    if (pasta.Id > 0)
        //    {
        //        for (int i = 0; i < Pastas.Count; i++)
        //            if (Pastas[i].Id == pasta.Id)
        //                Pastas[i] = pasta;
        //    }
        //    else
        //    {
        //        pasta.Cliente = this;
        //        Pastas.Add(pasta);
        //    }
        //}

        #region IValidaDelete Members

        public virtual bool PodeExcluir()
        {
            if (Tarefas.Count > 0)
                throw new Exception("Este Cliente não pode ser excluído, pois há Tarefas vinculadas");
            return Tarefas.Count == 0;
        }

        #endregion
    }
}
