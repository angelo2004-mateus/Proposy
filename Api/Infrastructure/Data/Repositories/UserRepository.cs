using Domain.Users;
using Framework.Infrastructure.Core;
using NHibernate;

namespace Infrastructure.Data.Repositories;

public class UserRepository : Repository<User, Guid>, IUserRepository
{
    public UserRepository(ISession session) : base(session)
    {
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        return await _session.GetAsync<User>(id);
    }
}