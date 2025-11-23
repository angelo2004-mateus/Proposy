using Framework.Domain.Entities.Interfaces;
using Framework.Infrastructure.NHibernate.Mappings.Extensions;

namespace Framework.Infrastructure.NHibernate.Mappings;

public class AuditedEntityClassMap<T> : EntityClassMap<T> where T : IAudited
{
    public AuditedEntityClassMap()
    {
        PerformAuditMapping();
    }

    protected virtual void PerformAuditMapping()
    {
        Map((T c) => ((IHasCreationTime)c).CreationTime).Indexable();
        Map((T c) => ((IHasModificationTime)c).LastModificationTime).Indexable();
    }
}