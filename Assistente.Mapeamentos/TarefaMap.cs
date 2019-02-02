using FluentNHibernate.Mapping;
using Assistente.Entidades;

namespace Assistente.Mapeamentos
{
    public class TarefaMap : ClassMap<Tarefa>
    {
        public TarefaMap()
        {
            Id(x => x.Id);
            Map(x => x.Codigo).Length(9).Not.Nullable();
            Map(x => x.Descricao).Length(100).Not.Nullable();
            Map(x => x.Status).Not.Nullable();
            Map(x => x.Prioridade);
            Map(x => x.Categoria);
            Map(x => x.DataCadastro).Not.Nullable();
            Map(x => x.PrazoTermino);
            Map(x => x.DataTermino);
            Map(x => x.Solicitante);
            Map(x => x.Responsavel);
            Map(x => x.Anotacoes);//.Length(1000);
            //Map(x => x.Inativo).Not.Nullable();
            References(x => x.Cliente).ForeignKey();
            /*HasMany(x => x.Horarios)
               .Cascade.AllDeleteOrphan()
               .Inverse();*/
            HasMany(x => x.Pendencias)
                .Cascade.AllDeleteOrphan()
                .Inverse();
            HasMany(x => x.Pastas)
                .Cascade.Delete()
                .Inverse();
        }
    }
}
