using Application.Contracts;
using Domain.Users;
using Framework.Shared.Api.Utils;

namespace Proposy.Controllers;

public class UserController : CrudApiController<User, Guid, IUserAppService>
{
    public UserController(IUserAppService appService) : base(appService)
    {
    }
}