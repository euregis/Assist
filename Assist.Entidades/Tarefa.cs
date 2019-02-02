using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Assistente.Entidades
{
    public enum enuStatusTarefa
    {
        [Description("Todos")]
        Todos = 0,
        [Description("Aguardando")]
        Aguardando = 1,
        /*[Description("Iniciado")]
        Iniciado,*/
        [Description("Concluído")]
        Concluido=2,
        [Description("Projeto")]
        Projeto=3,
        /*[Description("Encaminhar")]
        Encaminhar,
        [Description("Parado")]
        Parado,*/
        [Description("Cancelado")]
        Cancelado=6,
        /*[Description("Disponibilizar")]
        Disponibilizar,*/
        [Description("Atrasado")]
        Atrasado = 8,
        [Description("ASAP")]
        ASAP= 9
    }
    public enum enuPrioridadeTarefa
    {
        [Description("Todos")]
        Todos = 0,
        [Description("Baixa")]
        Baixa = 1,
        [Description("Normal")]
        Normal,
        [Description("Alta")]
        Alta
    }
    public enum enuCategoriaTarefa
    {
        [Description("Todos")]
        Todos = 0,
        [Description("Indefinida")]
        Indefinida = 1,
        [Description("Melhoria")]
        Melhoria,
        [Description("Manutenção")]
        Manutencao
    }
    public class Tarefa : Entidades.Base.BaseCodDescr, Base.IValidaDelete
    {
        public virtual Projeto Cliente { get; set; }
        public virtual short Status { get; set; }
        public virtual short Prioridade { get; set; }
        public virtual short Categoria { get; set; }
        public virtual DateTime DataCadastro{ get; set; }
        public virtual DateTime? PrazoTermino { get; set; }
        public virtual DateTime? DataTermino { get; set; }
        public virtual String Anotacoes { get; set; }
        //public virtual bool Inativo { get; set; }
        public virtual string Solicitante { get; set; }
        public virtual string Responsavel { get; set; }
        public virtual IList<Pendencia> Pendencias { get; set; }
        public virtual IList<Pasta> Pastas { get; set; }

        
        public Tarefa()
        {
            Pastas = new List<Pasta>();
            Pendencias = new List<Pendencia>();
        }

        public override string ToString()
        {
            return Descricao;
        }

        public virtual void AddPasta(Pasta pasta)
        {
            if (pasta.Id > 0)
            {
                for (int i = 0; i < Pastas.Count; i++)
                    if (Pastas[i].Id == pasta.Id)
                        Pastas[i] = pasta;
            }
            else
            {
                pasta.Tarefa = this;
                Pastas.Add(pasta);
            }
        }

        public virtual void AddPendencia(Pendencia pendencia)
        {
            if (pendencia.Id > 0)
            {
                for (int i = 0; i < Pendencias.Count; i++)
                    if (Pendencias[i].Id == pendencia.Id)
                        Pendencias[i] = pendencia;
            }
            else
            {
                pendencia.Tarefa = this;
                Pendencias.Add(pendencia);
            }
        }

        #region IValidaDelete Members

        public virtual bool PodeExcluir()
        {
            /*if(Horarios.Count > 0)
                throw new Exception("Esta Tarefa não pode ser excluída, pois há Horários");
            */
            return true;
        }

        #endregion
    }
}
