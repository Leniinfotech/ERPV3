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
public class PoB2BController(IPoB2BService svc) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<PoB2BDto>>> GetAll(CancellationToken ct)
        => Ok(await svc.GetAllAsync(ct));

    [HttpGet("{fran}/{branch}/{warehouse}/{b2bType}/{b2bNo}/{b2bSrl:decimal}")]
    public async Task<ActionResult<PoB2BDto>> GetByKey(string fran, string branch, string warehouse, string b2bType, string b2bNo, decimal b2bSrl, CancellationToken ct)
    {
        var dto = await svc.GetByKeyAsync(fran, branch, warehouse, b2bType, b2bNo, b2bSrl, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<PoB2BDto>> Create([FromBody] CreatePoB2BRequest request, CancellationToken ct)
    {
        var dto = await svc.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetByKey), new { dto.Fran, dto.Branch, dto.Warehouse, dto.B2BType, dto.B2BNo, dto.B2BSrl }, dto);
    }

    [HttpPut("{fran}/{branch}/{warehouse}/{b2bType}/{b2bNo}/{b2bSrl:decimal}")]
    public async Task<ActionResult<PoB2BDto>> Update(string fran, string branch, string warehouse, string b2bType, string b2bNo, decimal b2bSrl, [FromBody] UpdatePoB2BRequest request, CancellationToken ct)
    {
        var dto = await svc.UpdateAsync(fran, branch, warehouse, b2bType, b2bNo, b2bSrl, request, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpDelete("{fran}/{branch}/{warehouse}/{b2bType}/{b2bNo}/{b2bSrl:decimal}")]
    public async Task<IActionResult> Delete(string fran, string branch, string warehouse, string b2bType, string b2bNo, decimal b2bSrl, CancellationToken ct)
        => await svc.DeleteAsync(fran, branch, warehouse, b2bType, b2bNo, b2bSrl, ct) ? NoContent() : NotFound();
}
