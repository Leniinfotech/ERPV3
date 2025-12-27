using Asp.Versioning;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Inventory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.V1.Inventory;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/inventory/[controller]")]
#if DEBUG
[AllowAnonymous]
#endif
public class PatternCartonsController(IPatternCartonService svc) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<PatternCartonHeaderDto>>> GetAll(CancellationToken ct)
        => Ok(await svc.GetAllAsync(ct));

    [HttpGet("{fran}/{branch}/{warehouse}/{crtnType}/{crtn}")]
    public async Task<ActionResult<PatternCartonHeaderDto>> GetByKey(string fran, string branch, string warehouse, string crtnType, string crtn, CancellationToken ct)
    {
        var dto = await svc.GetByKeyAsync(fran, branch, warehouse, crtnType, crtn, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<PatternCartonHeaderDto>> Create([FromBody] CreatePatternCartonHeaderRequest request, CancellationToken ct)
    {
        var dto = await svc.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetByKey), new { dto.Fran, dto.Branch, dto.Warehouse, dto.CrtnType, dto.Crtn }, dto);
    }

    [HttpPut("{fran}/{branch}/{warehouse}/{crtnType}/{crtn}")]
    public async Task<ActionResult<PatternCartonHeaderDto>> Update(string fran, string branch, string warehouse, string crtnType, string crtn, [FromBody] UpdatePatternCartonHeaderRequest request, CancellationToken ct)
    {
        var dto = await svc.UpdateAsync(fran, branch, warehouse, crtnType, crtn, request, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpDelete("{fran}/{branch}/{warehouse}/{crtnType}/{crtn}")]
    public async Task<IActionResult> Delete(string fran, string branch, string warehouse, string crtnType, string crtn, CancellationToken ct)
        => await svc.DeleteAsync(fran, branch, warehouse, crtnType, crtn, ct) ? NoContent() : NotFound();
}
