using Asp.Versioning;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.V1.Master;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/master/[controller]")]
public sealed class FranchisesController(IFranchisesService svc) : ControllerBase
{
    private readonly IFranchisesService _svc = svc;

#if DEBUG
    [AllowAnonymous]
#endif
    [HttpGet]
    [Authorize(Policy = "erp.api.read")]
    public async Task<ActionResult<IEnumerable<FranchiseDto>>> Get(CancellationToken ct)
        => Ok(await _svc.GetAllAsync(ct));

#if DEBUG
    [AllowAnonymous]
#endif
    [HttpGet("{fran}")]
    [Authorize(Policy = "erp.api.read")]
    public async Task<ActionResult<FranchiseDto>> GetByKey(string fran, CancellationToken ct)
    {
        var item = await _svc.GetByKeyAsync(fran, ct);
        return item is null ? NotFound() : Ok(item);
    }

#if DEBUG
    [AllowAnonymous]
#endif
    [HttpPost]
    [Authorize(Policy = "erp.api.write")]
    public async Task<ActionResult<FranchiseDto>> Create([FromBody] CreateFranchiseRequest request, CancellationToken ct)
    {
        var created = await _svc.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetByKey), new { fran = created.Fran, version = HttpContext.GetRequestedApiVersion()!.ToString() }, created);
    }

#if DEBUG
    [AllowAnonymous]
#endif
    [HttpPut("{fran}")]
    [Authorize(Policy = "erp.api.write")]
    public async Task<ActionResult<FranchiseDto>> Update(string fran, [FromBody] UpdateFranchiseRequest request, CancellationToken ct)
    {
        var updated = await _svc.UpdateAsync(fran, request, ct);
        return updated is null ? NotFound() : Ok(updated);
    }

#if DEBUG
    [AllowAnonymous]
#endif
    [HttpDelete("{fran}")]
    [Authorize(Policy = "erp.api.write")]
    public async Task<IActionResult> Delete(string fran, CancellationToken ct)
    {
        var ok = await _svc.DeleteAsync(fran, ct);
        return ok ? NoContent() : NotFound();
    }
}
