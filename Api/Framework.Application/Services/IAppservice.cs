using Framework.Domain.Entities.Interfaces;
using Framework.Domain.Repositories;

namespace Framework.Application.Services;


public interface IAppService<TEntity, TId>
    where TEntity : class, IEntity<TId>
{
    Task<TEntity> GetAsync(TId id);
    Task<IList<TEntity>> GetAllAsync();
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TId id);
}

public interface IAppService<TEntity, TId, TRepository>
    : IAppService<TEntity, TId>
    where TEntity : class, IEntity<TId>
    where TRepository : IRepository<TEntity, TId>
{
}
