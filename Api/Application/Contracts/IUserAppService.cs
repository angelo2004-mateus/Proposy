using Domain.Users;
using Framework.Application.Services;

namespace Application.Contracts;

public interface IUserAppService : IAppService<User, Guid>
{
    
}