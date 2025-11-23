using Framework.Domain.Entities.Interfaces;
using Framework.Domain.Repositories;

namespace Framework.Application.Services;

public class AppService<TEntity, TId, TRepository> 
    : IAppService<TEntity, TId, TRepository>
    where TEntity : class, IEntity<TId>
    where TRepository : IRepository<TEntity, TId>
{
    protected readonly TRepository _repository;

    public AppService(TRepository repository)
    {
        _repository = repository;
    }

    public async Task<TEntity> GetAsync(TId id)
        => await _repository.GetAsync(id);

    public async Task<IList<TEntity>> GetAllAsync()
        => await _repository.GetAllAsync();

    public async Task CreateAsync(TEntity entity)
        => await _repository.CreateAsync(entity);

    public async Task UpdateAsync(TEntity entity)
        => await _repository.UpdateAsync(entity);

    public async Task DeleteAsync(TId id)
        => await _repository.DeleteAsync(id);
}