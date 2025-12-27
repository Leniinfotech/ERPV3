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
public sealed class PackingController(IPackingService svc) : ControllerBase
{
    // Headers
    [HttpGet("headers")]
    [Authorize(Policy = "erp.inventory.read")]
    public async Task<ActionResult<IEnumerable<PackingHeaderDto>>> GetHeaders(CancellationToken ct)
        => Ok(await svc.GetAllHeadersAsync(ct));

    [HttpGet("headers/{fran}/{brch}/{whse}/{packType}/{packNo}")]
    [Authorize(Policy = "erp.inventory.read")]
    public async Task<ActionResult<PackingHeaderDto>> GetHeaderByKey(string fran, string brch, string whse, string packType, string packNo, CancellationToken ct)
    {
        var item = await svc.GetHeaderByKeyAsync(fran, brch, whse, packType, packNo, ct);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost("headers")]
    [Authorize(Policy = "erp.inventory.write")]
    public async Task<ActionResult<PackingHeaderDto>> CreateHeader([FromBody] CreatePackingHeaderRequest req, CancellationToken ct)
    {
        var created = await svc.CreateHeaderAsync(req, ct);
        return CreatedAtAction(nameof(GetHeaderByKey), new { version = "1.0", fran = created.Fran, brch = created.Branch, whse = created.Warehouse, packType = created.PackType, packNo = created.PackNo }, created);
    }

    [HttpPut("headers/{fran}/{brch}/{whse}/{packType}/{packNo}")]
    [Authorize(Policy = "erp.inventory.write")]
    public async Task<IActionResult> UpdateHeader(string fran, string brch, string whse, string packType, string packNo, [FromBody] UpdatePackingHeaderRequest req, CancellationToken ct)
    {
        var ok = await svc.UpdateHeaderAsync(fran, brch, whse, packType, packNo, req, ct);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("headers/{fran}/{brch}/{whse}/{packType}/{packNo}")]
    [Authorize(Policy = "erp.inventory.write")]
    public async Task<IActionResult> DeleteHeader(string fran, string brch, string whse, string packType, string packNo, CancellationToken ct)
    {
        var ok = await svc.DeleteHeaderAsync(fran, brch, whse, packType, packNo, ct);
        return ok ? NoContent() : NotFound();
    }

    // Lines
    [HttpGet("lines")]
    [Authorize(Policy = "erp.inventory.read")]
    public async Task<ActionResult<IEnumerable<PackingDetailDto>>> GetLines(CancellationToken ct)
        => Ok(await svc.GetAllLinesAsync(ct));

    [HttpGet("lines/{fran}/{brch}/{whse}/{packType}/{packNo}/{packSrl:decimal}")]
    [Authorize(Policy = "erp.inventory.read")]
    public async Task<ActionResult<PackingDetailDto>> GetLineByKey(string fran, string brch, string whse, string packType, string packNo, decimal packSrl, CancellationToken ct)
    {
        var item = await svc.GetLineByKeyAsync(fran, brch, whse, packType, packNo, packSrl, ct);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost("lines")]
    [Authorize(Policy = "erp.inventory.write")]
    public async Task<ActionResult<PackingDetailDto>> CreateLine([FromBody] CreatePackingDetailRequest req, CancellationToken ct)
    {
        var created = await svc.CreateLineAsync(req, ct);
        return CreatedAtAction(nameof(GetLineByKey), new { version = "1.0", fran = created.Fran, brch = created.Branch, whse = created.Warehouse, packType = created.PackType, packNo = created.PackNo, packSrl = created.PackSrl }, created);
    }

    [HttpPut("lines/{fran}/{brch}/{whse}/{packType}/{packNo}/{packSrl:decimal}")]
    [Authorize(Policy = "erp.inventory.write")]
    public async Task<IActionResult> UpdateLine(string fran, string brch, string whse, string packType, string packNo, decimal packSrl, [FromBody] UpdatePackingDetailRequest req, CancellationToken ct)
    {
        var ok = await svc.UpdateLineAsync(fran, brch, whse, packType, packNo, packSrl, req, ct);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("lines/{fran}/{brch}/{whse}/{packType}/{packNo}/{packSrl:decimal}")]
    [Authorize(Policy = "erp.inventory.write")]
    public async Task<IActionResult> DeleteLine(string fran, string brch, string whse, string packType, string packNo, decimal packSrl, CancellationToken ct)
    {
        var ok = await svc.DeleteLineAsync(fran, brch, whse, packType, packNo, packSrl, ct);
        return ok ? NoContent() : NotFound();
    }
}
