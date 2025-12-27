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
public sealed class ShipmentLinesController(IShipmentDetailsService svc) : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "erp.orders.read")]
    public async Task<ActionResult<IEnumerable<ShipmentDetailDto>>> GetAll(CancellationToken ct)
        => Ok(await svc.GetAllAsync(ct));

    [HttpGet("{fran}/{brch}/{whse}/{type}/{no}/{srl:decimal}")]
    [Authorize(Policy = "erp.orders.read")]
    public async Task<ActionResult<ShipmentDetailDto>> GetByKey(string fran, string brch, string whse, string type, string no, decimal srl, CancellationToken ct)
    {
        var item = await svc.GetByKeyAsync(fran, brch, whse, type, no, srl, ct);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    [Authorize(Policy = "erp.orders.write")]
    public async Task<ActionResult<ShipmentDetailDto>> Create([FromBody] CreateShipmentDetailRequest req, CancellationToken ct)
    {
        var created = await svc.CreateAsync(req, ct);
        return CreatedAtAction(nameof(GetByKey), new { version = "1.0", fran = created.Fran, brch = created.Branch, whse = created.WarehouseCode, type = created.ShipmentType, no = created.ShipmentNumber, srl = created.ShipmentSerial }, created);
    }

    [HttpPut("{fran}/{brch}/{whse}/{type}/{no}/{srl:decimal}")]
    [Authorize(Policy = "erp.orders.write")]
    public async Task<IActionResult> Update(string fran, string brch, string whse, string type, string no, decimal srl, [FromBody] UpdateShipmentDetailRequest req, CancellationToken ct)
    {
        var ok = await svc.UpdateAsync(fran, brch, whse, type, no, srl, req, ct);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{fran}/{brch}/{whse}/{type}/{no}/{srl:decimal}")]
    [Authorize(Policy = "erp.orders.write")]
    public async Task<IActionResult> Delete(string fran, string brch, string whse, string type, string no, decimal srl, CancellationToken ct)
    {
        var ok = await svc.DeleteAsync(fran, brch, whse, type, no, srl, ct);
        return ok ? NoContent() : NotFound();
    }
}
