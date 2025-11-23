using Framework.Domain.Entities.Interfaces;
using Framework.Domain.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace Framework.Infrastructure.Core;

public class Repository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>
{
    protected readonly ISession _session;

    public Repository(ISession session)
    {
        _session = session;
    }

    public async Task<TEntity> GetAsync(TId id)
        => await _session.GetAsync<TEntity>(id);

    public async Task<IList<TEntity>> GetAllAsync()
        => await _session.Query<TEntity>().ToListAsync();

    public async Task CreateAsync(TEntity entity)
    {
        using var tx = _session.BeginTransaction();
        await _session.SaveAsync(entity);
        await tx.CommitAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        using var tx = _session.BeginTransaction();
        await _session.UpdateAsync(entity);
        await tx.CommitAsync();
    }

    public async Task DeleteAsync(TId id)
    {
        var entity = await GetAsync(id);
        if (entity == null) return;

        using var tx = _session.BeginTransaction();
        await _session.DeleteAsync(entity);
        await tx.CommitAsync();
    }
}