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
public class CustomerOrdersController(ICustomerOrdersService svc) : ControllerBase
{
    // Headers
    [HttpGet("headers")]
    public async Task<ActionResult<IReadOnlyList<CustomerOrderHeaderDto>>> GetAllHeaders(CancellationToken ct)
        => Ok(await svc.GetAllHeadersAsync(ct));

    [HttpGet("headers/{fran}/{branch}/{warehouse}/{cordType}/{cordNo}")]
    public async Task<ActionResult<CustomerOrderHeaderDto>> GetHeaderByKey(string fran, string branch, string warehouse, string cordType, string cordNo, CancellationToken ct)
    {
        var dto = await svc.GetHeaderByKeyAsync(fran, branch, warehouse, cordType, cordNo, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost("headers")]
    public async Task<ActionResult<CustomerOrderHeaderDto>> CreateHeader([FromBody] CreateCustomerOrderHeaderRequest request, CancellationToken ct)
    {
        var dto = await svc.CreateHeaderAsync(request, ct);
        return CreatedAtAction(nameof(GetHeaderByKey), new { dto.Fran, dto.Branch, dto.Warehouse, dto.CordType, dto.CordNo }, dto);
    }

    [HttpPut("headers/{fran}/{branch}/{warehouse}/{cordType}/{cordNo}")]
    public async Task<ActionResult<CustomerOrderHeaderDto>> UpdateHeader(string fran, string branch, string warehouse, string cordType, string cordNo, [FromBody] UpdateCustomerOrderHeaderRequest request, CancellationToken ct)
    {
        var dto = await svc.UpdateHeaderAsync(fran, branch, warehouse, cordType, cordNo, request, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpDelete("headers/{fran}/{branch}/{warehouse}/{cordType}/{cordNo}")]
    public async Task<IActionResult> DeleteHeader(string fran, string branch, string warehouse, string cordType, string cordNo, CancellationToken ct)
        => await svc.DeleteHeaderAsync(fran, branch, warehouse, cordType, cordNo, ct) ? NoContent() : NotFound();

    // Details
    [HttpGet("lines")]
    public async Task<ActionResult<IReadOnlyList<CustomerOrderDetailDto>>> GetAllDetails(CancellationToken ct)
        => Ok(await svc.GetAllDetailsAsync(ct));

    [HttpGet("lines/{fran}/{branch}/{warehouse}/{cordType}/{cordNo}/{cordSrl}")]
    public async Task<ActionResult<CustomerOrderDetailDto>> GetDetailByKey(string fran, string branch, string warehouse, string cordType, string cordNo, string cordSrl, CancellationToken ct)
    {
        var dto = await svc.GetDetailByKeyAsync(fran, branch, warehouse, cordType, cordNo, cordSrl, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost("lines")]
    public async Task<ActionResult<CustomerOrderDetailDto>> CreateDetail([FromBody] CreateCustomerOrderDetailRequest request, CancellationToken ct)
    {
        var dto = await svc.CreateDetailAsync(request, ct);
        return CreatedAtAction(nameof(GetDetailByKey), new { dto.Fran, dto.Branch, dto.Warehouse, dto.CordType, dto.CordNo, dto.CordSrl }, dto);
    }

    [HttpPut("lines/{fran}/{branch}/{warehouse}/{cordType}/{cordNo}/{cordSrl}")]
    public async Task<ActionResult<CustomerOrderDetailDto>> UpdateDetail(string fran, string branch, string warehouse, string cordType, string cordNo, string cordSrl, [FromBody] UpdateCustomerOrderDetailRequest request, CancellationToken ct)
    {
        var dto = await svc.UpdateDetailAsync(fran, branch, warehouse, cordType, cordNo, cordSrl, request, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpDelete("lines/{fran}/{branch}/{warehouse}/{cordType}/{cordNo}/{cordSrl}")]
    public async Task<IActionResult> DeleteDetail(string fran, string branch, string warehouse, string cordType, string cordNo, string cordSrl, CancellationToken ct)
        => await svc.DeleteDetailAsync(fran, branch, warehouse, cordType, cordNo, cordSrl, ct) ? NoContent() : NotFound();
}
