using Asp.Versioning;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.V1.Orders;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/orders/[controller]")]
#if DEBUG
[AllowAnonymous]
#endif
public class PoAllocationsController(IPoAllocationService svc) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<PoAllocationDto>>> GetAll(CancellationToken ct)
        => Ok(await svc.GetAllAsync(ct));

    [HttpGet("{fran}/{branch}/{warehouse}/{alocSrl:decimal}")]
    public async Task<ActionResult<PoAllocationDto>> GetByKey(string fran, string branch, string warehouse, decimal alocSrl, CancellationToken ct)
    {
        var dto = await svc.GetByKeyAsync(fran, branch, warehouse, alocSrl, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<PoAllocationDto>> Create([FromBody] CreatePoAllocationRequest request, CancellationToken ct)
    {
        var dto = await svc.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetByKey), new { dto.Fran, dto.Branch, dto.Warehouse, dto.AlocSrl }, dto);
    }

    [HttpPut("{fran}/{branch}/{warehouse}/{alocSrl:decimal}")]
    public async Task<ActionResult<PoAllocationDto>> Update(string fran, string branch, string warehouse, decimal alocSrl, [FromBody] UpdatePoAllocationRequest request, CancellationToken ct)
    {
        var dto = await svc.UpdateAsync(fran, branch, warehouse, alocSrl, request, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpDelete("{fran}/{branch}/{warehouse}/{alocSrl:decimal}")]
    public async Task<IActionResult> Delete(string fran, string branch, string warehouse, decimal alocSrl, CancellationToken ct)
        => await svc.DeleteAsync(fran, branch, warehouse, alocSrl, ct) ? NoContent() : NotFound();
}
