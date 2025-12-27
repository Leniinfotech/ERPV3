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
public sealed class CartonsController(ICartonsService svc) : ControllerBase
{
    // Headers (CRTN)
    [HttpGet]
    [Authorize(Policy = "erp.inventory.read")]
    public async Task<ActionResult<IEnumerable<CartonDto>>> GetAll(CancellationToken ct)
        => Ok(await svc.GetAllAsync(ct));

    [HttpGet("{fran}/{crtnType}/{crtnCatg}")]
    [Authorize(Policy = "erp.inventory.read")]
    public async Task<ActionResult<CartonDto>> GetByKey(string fran, string crtnType, string crtnCatg, CancellationToken ct)
    {
        var item = await svc.GetByKeyAsync(fran, crtnType, crtnCatg, ct);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    [Authorize(Policy = "erp.inventory.write")]
    public async Task<ActionResult<CartonDto>> Create([FromBody] CreateCartonRequest req, CancellationToken ct)
    {
        var created = await svc.CreateAsync(req, ct);
        return CreatedAtAction(nameof(GetByKey), new { version = "1.0", fran = created.Fran, crtnType = created.CrtnType, crtnCatg = created.CrtnCatg }, created);
    }

    [HttpPut("{fran}/{crtnType}/{crtnCatg}")]
    [Authorize(Policy = "erp.inventory.write")]
    public async Task<IActionResult> Update(string fran, string crtnType, string crtnCatg, [FromBody] UpdateCartonRequest req, CancellationToken ct)
    {
        var ok = await svc.UpdateAsync(fran, crtnType, crtnCatg, req, ct);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{fran}/{crtnType}/{crtnCatg}")]
    [Authorize(Policy = "erp.inventory.write")]
    public async Task<IActionResult> Delete(string fran, string crtnType, string crtnCatg, CancellationToken ct)
    {
        var ok = await svc.DeleteAsync(fran, crtnType, crtnCatg, ct);
        return ok ? NoContent() : NotFound();
    }

    // Lines (CRTNDET)
    [HttpGet("lines")]
    [Authorize(Policy = "erp.inventory.read")]
    public async Task<ActionResult<IEnumerable<CartonDetailDto>>> GetLines(CancellationToken ct)
        => Ok(await svc.GetAllLinesAsync(ct));

    [HttpGet("lines/{cdf}/{cdb}/{cdw}/{cdcrtn}/{cdtype}/{cdsrl:decimal}")]
    [Authorize(Policy = "erp.inventory.read")]
    public async Task<ActionResult<CartonDetailDto>> GetLineByKey(string cdf, string cdb, string cdw, string cdcrtn, string cdtype, decimal cdsrl, CancellationToken ct)
    {
        var item = await svc.GetLineByKeyAsync(cdf, cdb, cdw, cdcrtn, cdtype, cdsrl, ct);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost("lines")]
    [Authorize(Policy = "erp.inventory.write")]
    public async Task<ActionResult<CartonDetailDto>> CreateLine([FromBody] CreateCartonDetailRequest req, CancellationToken ct)
    {
        var created = await svc.CreateLineAsync(req, ct);
        return CreatedAtAction(nameof(GetLineByKey), new { version = "1.0", cdf = created.CDFRAN, cdb = created.CDBRCH, cdw = created.CDWHSE, cdcrtn = created.CDCRTN, cdtype = created.CDCRTNTYPE, cdsrl = created.CDCRTNSRL }, created);
    }

    [HttpPut("lines/{cdf}/{cdb}/{cdw}/{cdcrtn}/{cdtype}/{cdsrl:decimal}")]
    [Authorize(Policy = "erp.inventory.write")]
    public async Task<IActionResult> UpdateLine(string cdf, string cdb, string cdw, string cdcrtn, string cdtype, decimal cdsrl, [FromBody] UpdateCartonDetailRequest req, CancellationToken ct)
    {
        var ok = await svc.UpdateLineAsync(cdf, cdb, cdw, cdcrtn, cdtype, cdsrl, req, ct);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("lines/{cdf}/{cdb}/{cdw}/{cdcrtn}/{cdtype}/{cdsrl:decimal}")]
    [Authorize(Policy = "erp.inventory.write")]
    public async Task<IActionResult> DeleteLine(string cdf, string cdb, string cdw, string cdcrtn, string cdtype, decimal cdsrl, CancellationToken ct)
    {
        var ok = await svc.DeleteLineAsync(cdf, cdb, cdw, cdcrtn, cdtype, cdsrl, ct);
        return ok ? NoContent() : NotFound();
    }
}
