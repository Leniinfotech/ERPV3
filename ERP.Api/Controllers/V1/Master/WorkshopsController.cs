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
public sealed class WorkshopsController(IWorkshopsService svc) : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "erp.api.read")]
    public async Task<ActionResult<IEnumerable<WorkshopDto>>> Get(CancellationToken ct)
        => Ok(await svc.GetAllAsync(ct));

    [HttpGet("{fran}/{workshopId}")]
    [Authorize(Policy = "erp.api.read")]
    public async Task<ActionResult<WorkshopDto>> GetByKey(string fran, decimal workshopId, CancellationToken ct)
    {
        var item = await svc.GetByKeyAsync(fran, workshopId, ct);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    [Authorize(Policy = "erp.api.write")]
    public async Task<ActionResult<WorkshopDto>> Create([FromBody] CreateWorkshopRequest req, CancellationToken ct)
    {
        var created = await svc.CreateAsync(req, ct);
        return CreatedAtAction(nameof(GetByKey), new { version = "1.0", fran = created.Fran, workshopId = created.WorkshopId }, created);
    }

    [HttpPut("{fran}/{workshopId}")]
    [Authorize(Policy = "erp.api.write")]
    public async Task<IActionResult> Update(string fran, decimal workshopId, [FromBody] UpdateWorkshopRequest req, CancellationToken ct)
    {
        var ok = await svc.UpdateAsync(fran, workshopId, req, ct);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{fran}/{workshopId}")]
    [Authorize(Policy = "erp.api.write")]
    public async Task<IActionResult> Delete(string fran, decimal workshopId, CancellationToken ct)
    {
        var ok = await svc.DeleteAsync(fran, workshopId, ct);
        return ok ? NoContent() : NotFound();
    }
}
