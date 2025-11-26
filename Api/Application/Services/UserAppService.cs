using Application.Contracts;
using Domain.Users;
using Framework.Application.Services;

namespace Application.Services;

public class UserAppService : AppService<User, Guid, IUserRepository>, IUserAppService
{
    public UserAppService(IUserRepository repository) : base(repository)
    {
    }

    public Task<User> GetByIdAsync(Guid id)
    {
        return mapper.To<UserDto>(_repository.GetByIdAsync(id));
    }
}