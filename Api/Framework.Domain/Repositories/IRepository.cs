using Framework.Domain.Entities.Interfaces;

namespace Framework.Domain.Repositories;

public interface IRepository<TEntity, TId> where TEntity : IEntity<TId>
{
    Task<TEntity> GetAsync(TId id);
    Task<IList<TEntity>> GetAllAsync();
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TId entity);
}