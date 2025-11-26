using Application.Contracts;
using Domain.Users;
using Framework.Shared.Api.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Proposy.Controllers;

public class UserController : CrudApiController<User, Guid, IUserAppService>
{
    public UserController(IUserAppService appService) : base(appService)
    {
    }


    [HttpGet("/leonardo/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var sla =  await _appService.GetByIdAsync(id);
        return Ok(sla);
    }
}