using Asp.Versioning;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.V1.Master;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/master/[controller]")]
#if DEBUG
[AllowAnonymous]
#endif
public sealed class UsersController(IUsersService svc) : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "erp.api.read")]
    public async Task<ActionResult<IEnumerable<UserDto>>> Get(CancellationToken ct)
        => Ok(await svc.GetAllAsync(ct));

    [HttpGet("{fran}/{userId}")]
    [Authorize(Policy = "erp.api.read")]
    public async Task<ActionResult<UserDto>> GetByKey(string fran, string userId, CancellationToken ct)
    {
        var item = await svc.GetByKeyAsync(fran, userId, ct);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    [Authorize(Policy = "erp.api.write")]
    public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserRequest req, CancellationToken ct)
    {
        var created = await svc.CreateAsync(req, ct);
        return CreatedAtAction(nameof(GetByKey), new { version = "1.0", fran = created.Fran, userId = created.UserId }, created);
    }

    [HttpPut("{fran}/{userId}")]
    [Authorize(Policy = "erp.api.write")]
    public async Task<IActionResult> Update(string fran, string userId, [FromBody] UpdateUserRequest req, CancellationToken ct)
    {
        var ok = await svc.UpdateAsync(fran, userId, req, ct);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{fran}/{userId}")]
    [Authorize(Policy = "erp.api.write")]
    public async Task<IActionResult> Delete(string fran, string userId, CancellationToken ct)
    {
        var ok = await svc.DeleteAsync(fran, userId, ct);
        return ok ? NoContent() : NotFound();
    }
}
