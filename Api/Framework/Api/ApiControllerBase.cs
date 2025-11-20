using Framework.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace Framework.Api;

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