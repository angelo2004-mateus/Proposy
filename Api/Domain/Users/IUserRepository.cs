using Framework.Domain.Repositories;

namespace Domain.Users;

public interface IUserRepository : IRepository<User, Guid>
{
    Task<User> GetByIdAsync(Guid id);
}