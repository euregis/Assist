using FluentNHibernate.Mapping;
using Assistente.Entidades;

namespace Assistente.Mapeamentos
{
    public class PendenciaMap : ClassMap<Pendencia>
    {
        public PendenciaMap()
        {
            Id(x => x.Id);
            Map(x => x.Codigo).Not.Nullable();
            Map(x => x.Descricao).Not.Nullable().Length(255);
            Map(x => x.DataCadastro).Not.Nullable();
            Map(x => x.DataConclusao).Nullable();
            References(x => x.Tarefa).ForeignKey();
        }
    }
}
