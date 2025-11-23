using Framework.Shared.Api.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Framework.Shared.Api;

public class ApiControllerBase : ControllerBase
{
    protected IActionResult Result<T>(T obj, bool returnNotFoundIfIsNull = true)
    {
        if (returnNotFoundIfIsNull && obj == null)
        {
            return NotFound();
        }
        
        return Ok(new ResultReponse<T>(obj));
    }
}