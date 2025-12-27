using Asp.Versioning;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.V1.Master;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/master/[controller]")]
public sealed class BranchesController(IBranchesService svc) : ControllerBase
{
    private readonly IBranchesService _svc = svc;

    /// <summary>List all branches.</summary>
#if DEBUG
    [AllowAnonymous]
#endif
    [HttpGet]
    [Authorize(Policy = "erp.api.read")]
    public async Task<ActionResult<IEnumerable<BranchDto>>> Get(CancellationToken ct)
    {
        var items = await _svc.GetAllAsync(ct);
        return Ok(items);
    }

    /// <summary>Get a branch by BranchCode.</summary>
#if DEBUG
    [AllowAnonymous]
#endif
    [HttpGet("{branchCode:decimal}")]
    [Authorize(Policy = "erp.api.read")]
    public async Task<ActionResult<BranchDto>> GetByKey(decimal branchCode, CancellationToken ct)
    {
        var item = await _svc.GetByKeyAsync(branchCode, ct);
        return item is null ? NotFound() : Ok(item);
    }

    /// <summary>Create a new branch.</summary>
#if DEBUG
    [AllowAnonymous]
#endif
    [HttpPost]
    [Authorize(Policy = "erp.api.write")]
    public async Task<ActionResult<BranchDto>> Create([FromBody] CreateBranchRequest request, CancellationToken ct)
    {
        var created = await _svc.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetByKey), new { branchCode = created.BranchCode, version = HttpContext.GetRequestedApiVersion()!.ToString() }, created);
    }

    /// <summary>Update a branch.</summary>
#if DEBUG
    [AllowAnonymous]
#endif
    [HttpPut("{branchCode:decimal}")]
    [Authorize(Policy = "erp.api.write")]
    public async Task<ActionResult<BranchDto>> Update(decimal branchCode, [FromBody] UpdateBranchRequest request, CancellationToken ct)
    {
        var updated = await _svc.UpdateAsync(branchCode, request, ct);
        return updated is null ? NotFound() : Ok(updated);
    }

    /// <summary>Delete a branch.</summary>
#if DEBUG
    [AllowAnonymous]
#endif
    [HttpDelete("{branchCode:decimal}")]
    [Authorize(Policy = "erp.api.write")]
    public async Task<IActionResult> Delete(decimal branchCode, CancellationToken ct)
    {
        var ok = await _svc.DeleteAsync(branchCode, ct);
        return ok ? NoContent() : NotFound();
    }
}
