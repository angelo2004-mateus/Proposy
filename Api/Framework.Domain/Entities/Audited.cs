using Framework.Domain.Entities.Interfaces;

namespace Framework.Domain.Entities;

public abstract class Audited<TId> : Entity<TId>, IAudited
{
    public virtual DateTime CreationTime { get; set; }
    public virtual DateTime? LastModificationTime { get; set; }
}