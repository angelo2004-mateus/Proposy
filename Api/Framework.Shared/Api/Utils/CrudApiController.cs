using Framework.Application.Services;
using Framework.Domain.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Framework.Shared.Api.Utils;

[ApiController]
[Route("api/[controller]")]
public class CrudApiController<TEntity, TId, TAppService> 
    : ControllerBase 
    where TEntity : class, IEntity<TId> 
    where TAppService : IAppService<TEntity, TId>
{
    protected readonly TAppService _appService;

    protected CrudApiController(TAppService appService)
    {
        _appService = appService;
    }

    // ==============================
    // GET BY ID
    // ==============================
    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetByIdAsync([FromRoute] TId id)
    {
        var entity = await _appService.GetAsync(id);
        if (entity == null)
            return NotFound();

        return Ok(entity);
    }

    // ==============================
    // GET ALL
    // ==============================
    [HttpGet]
    public virtual async Task<IActionResult> GetAllAsync()
    {
        var list = await _appService.GetAllAsync();
        return Ok(list);
    }

    // ==============================
    // CREATE
    // ==============================
    [HttpPost]
    public virtual async Task<IActionResult> CreateAsync([FromBody] TEntity entity)
    {
        await _appService.CreateAsync(entity);

        var url = $"{Request.Scheme}://{Request.Host}/api/{ControllerContext.ActionDescriptor.ControllerName}/{entity.Id}";
    
        return Created(url, entity);
    }


    // ==============================
    // UPDATE
    // ==============================
    [HttpPut("{id}")]
    public virtual async Task<IActionResult> UpdateAsync([FromRoute] TId id, [FromBody] TEntity entity)
    {
        if (!id.Equals(entity.Id))
            return BadRequest("ID na URL difere do ID do corpo.");

        await _appService.UpdateAsync(entity);
        return NoContent();
    }

    // ==============================
    // DELETE
    // ==============================
    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> DeleteAsync([FromRoute] TId id)
    {
        await _appService.DeleteAsync(id);
        return NoContent();
    }
}
