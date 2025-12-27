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
public sealed class SalesController : ControllerBase
{
    private readonly ISalesService _svc;

    public SalesController(ISalesService svc)
    {
        _svc = svc;
    }

    [HttpGet("receivable")]
    public async Task<ActionResult<IEnumerable<SaleReceivablePayableDto>>>
        GetReceivable(
            [FromQuery] string fran,
            CancellationToken ct)
    {
        var result = await _svc.GetSaleReceivablePayableAsync(fran, "Receivable", ct);
        return Ok(result);
    }

    [HttpGet("payable")]
    public async Task<ActionResult<IEnumerable<SaleReceivablePayableDto>>>
        GetPayable(
            [FromQuery] string fran,
            CancellationToken ct)
    {
        var result = await _svc.GetSaleReceivablePayableAsync(fran, "Payable", ct);
        return Ok(result);
    }
    // Commented by: Vaishnavi
    // Commented on: 15-12-2025


    // Headers
    //[HttpGet("headers")]
    //[Authorize(Policy = "erp.orders.read")]
    //public async Task<ActionResult<IEnumerable<SaleHeaderDto>>> GetHeaders(CancellationToken ct)
    //    => Ok(await svc.GetAllHeadersAsync(ct));

    //[HttpGet("headers/{fran}/{brch}/{whse}/{saleType}/{saleNo}")]
    //[Authorize(Policy = "erp.orders.read")]
    //public async Task<ActionResult<SaleHeaderDto>> GetHeaderByKey(string fran, string brch, string whse, string saleType, string saleNo, CancellationToken ct)
    //{
    //    var item = await svc.GetHeaderByKeyAsync(fran, brch, whse, saleType, saleNo, ct);
    //    return item is null ? NotFound() : Ok(item);
    //}

    //[HttpPost("headers")]
    //[Authorize(Policy = "erp.orders.write")]
    //public async Task<ActionResult<SaleHeaderDto>> CreateHeader([FromBody] CreateSaleHeaderRequest req, CancellationToken ct)
    //{
    //    var created = await svc.CreateHeaderAsync(req, ct);
    //    return CreatedAtAction(nameof(GetHeaderByKey), new { version = "1.0", fran = created.Fran, brch = created.Branch, whse = created.Warehouse, saleType = created.SaleType, saleNo = created.SaleNo }, created);
    //}

    //[HttpPut("headers/{fran}/{brch}/{whse}/{saleType}/{saleNo}")]
    //[Authorize(Policy = "erp.orders.write")]
    //public async Task<IActionResult> UpdateHeader(string fran, string brch, string whse, string saleType, string saleNo, [FromBody] UpdateSaleHeaderRequest req, CancellationToken ct)
    //{
    //    var ok = await svc.UpdateHeaderAsync(fran, brch, whse, saleType, saleNo, req, ct);
    //    return ok ? NoContent() : NotFound();
    //}

    //[HttpDelete("headers/{fran}/{brch}/{whse}/{saleType}/{saleNo}")]
    //[Authorize(Policy = "erp.orders.write")]
    //public async Task<IActionResult> DeleteHeader(string fran, string brch, string whse, string saleType, string saleNo, CancellationToken ct)
    //{
    //    var ok = await svc.DeleteHeaderAsync(fran, brch, whse, saleType, saleNo, ct);
    //    return ok ? NoContent() : NotFound();
    //}

    //// Lines
    //[HttpGet("lines")]
    //[Authorize(Policy = "erp.orders.read")]
    //public async Task<ActionResult<IEnumerable<SaleDetailDto>>> GetLines(CancellationToken ct)
    //    => Ok(await svc.GetAllLinesAsync(ct));

    //[HttpGet("lines/{fran}/{brch}/{whse}/{saleType}/{saleNo}/{salesRl}")]
    //[Authorize(Policy = "erp.orders.read")]
    //public async Task<ActionResult<SaleDetailDto>> GetLineByKey(string fran, string brch, string whse, string saleType, string saleNo, string salesRl, CancellationToken ct)
    //{
    //    var item = await svc.GetLineByKeyAsync(fran, brch, whse, saleType, saleNo, salesRl, ct);
    //    return item is null ? NotFound() : Ok(item);
    //}

    //[HttpPost("lines")]
    //[Authorize(Policy = "erp.orders.write")]
    //public async Task<ActionResult<SaleDetailDto>> CreateLine([FromBody] CreateSaleDetailRequest req, CancellationToken ct)
    //{
    //    var created = await svc.CreateLineAsync(req, ct);
    //    return CreatedAtAction(nameof(GetLineByKey), new { version = "1.0", fran = created.Fran, brch = created.Branch, whse = created.Warehouse, saleType = created.SaleType, saleNo = created.SaleNo, salesRl = created.SalesRl }, created);
    //}

    //[HttpPut("lines/{fran}/{brch}/{whse}/{saleType}/{saleNo}/{salesRl}")]
    //[Authorize(Policy = "erp.orders.write")]
    //public async Task<IActionResult> UpdateLine(string fran, string brch, string whse, string saleType, string saleNo, string salesRl, [FromBody] UpdateSaleDetailRequest req, CancellationToken ct)
    //{
    //    var ok = await svc.UpdateLineAsync(fran, brch, whse, saleType, saleNo, salesRl, req, ct);
    //    return ok ? NoContent() : NotFound();
    //}

    //[HttpDelete("lines/{fran}/{brch}/{whse}/{saleType}/{saleNo}/{salesRl}")]
    //[Authorize(Policy = "erp.orders.write")]
    //public async Task<IActionResult> DeleteLine(string fran, string brch, string whse, string saleType, string saleNo, string salesRl, CancellationToken ct)
    //{
    //    var ok = await svc.DeleteLineAsync(fran, brch, whse, saleType, saleNo, salesRl, ct);
    //    return ok ? NoContent() : NotFound();
    //}


}


