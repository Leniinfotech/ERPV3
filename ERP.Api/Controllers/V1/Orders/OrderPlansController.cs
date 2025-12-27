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
public class OrderPlansController(IOrderPlanService svc) : ControllerBase
{
    // Headers
    [HttpGet("headers")]
    public async Task<ActionResult<IReadOnlyList<OrderPlanHeaderDto>>> GetAllHeaders(CancellationToken ct)
        => Ok(await svc.GetAllHeadersAsync(ct));

    [HttpGet("headers/{fran}/{branch}/{warehouse}/{planType}/{planNo}")]
    public async Task<ActionResult<OrderPlanHeaderDto>> GetHeaderByKey(string fran, string branch, string warehouse, string planType, string planNo, CancellationToken ct)
    {
        var dto = await svc.GetHeaderByKeyAsync(fran, branch, warehouse, planType, planNo, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost("headers")]
    public async Task<ActionResult<OrderPlanHeaderDto>> CreateHeader([FromBody] CreateOrderPlanHeaderRequest request, CancellationToken ct)
    {
        var dto = await svc.CreateHeaderAsync(request, ct);
        return CreatedAtAction(nameof(GetHeaderByKey), new { dto.Fran, dto.Branch, dto.Warehouse, dto.PlanType, dto.PlanNo }, dto);
    }

    [HttpPut("headers/{fran}/{branch}/{warehouse}/{planType}/{planNo}")]
    public async Task<ActionResult<OrderPlanHeaderDto>> UpdateHeader(string fran, string branch, string warehouse, string planType, string planNo, [FromBody] UpdateOrderPlanHeaderRequest request, CancellationToken ct)
    {
        var dto = await svc.UpdateHeaderAsync(fran, branch, warehouse, planType, planNo, request, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpDelete("headers/{fran}/{branch}/{warehouse}/{planType}/{planNo}")]
    public async Task<IActionResult> DeleteHeader(string fran, string branch, string warehouse, string planType, string planNo, CancellationToken ct)
        => await svc.DeleteHeaderAsync(fran, branch, warehouse, planType, planNo, ct) ? NoContent() : NotFound();

    // Details
    [HttpGet("details")]
    public async Task<ActionResult<IReadOnlyList<OrderPlanDetailDto>>> GetAllDetails(CancellationToken ct)
        => Ok(await svc.GetAllDetailsAsync(ct));

    [HttpGet("details/{fran}/{branch}/{warehouse}/{planType}/{planNo:decimal}/{planSrl:decimal}")]
    public async Task<ActionResult<OrderPlanDetailDto>> GetDetailByKey(string fran, string branch, string warehouse, string planType, decimal planNo, decimal planSrl, CancellationToken ct)
    {
        var dto = await svc.GetDetailByKeyAsync(fran, branch, warehouse, planType, planNo, planSrl, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost("details")]
    public async Task<ActionResult<OrderPlanDetailDto>> CreateDetail([FromBody] CreateOrderPlanDetailRequest request, CancellationToken ct)
    {
        var dto = await svc.CreateDetailAsync(request, ct);
        return CreatedAtAction(nameof(GetDetailByKey), new { dto.Fran, dto.Branch, dto.Warehouse, dto.PlanType, dto.PlanNo, dto.PlanSrl }, dto);
    }

    [HttpPut("details/{fran}/{branch}/{warehouse}/{planType}/{planNo:decimal}/{planSrl:decimal}")]
    public async Task<ActionResult<OrderPlanDetailDto>> UpdateDetail(string fran, string branch, string warehouse, string planType, decimal planNo, decimal planSrl, [FromBody] UpdateOrderPlanDetailRequest request, CancellationToken ct)
    {
        var dto = await svc.UpdateDetailAsync(fran, branch, warehouse, planType, planNo, planSrl, request, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpDelete("details/{fran}/{branch}/{warehouse}/{planType}/{planNo:decimal}/{planSrl:decimal}")]
    public async Task<IActionResult> DeleteDetail(string fran, string branch, string warehouse, string planType, decimal planNo, decimal planSrl, CancellationToken ct)
        => await svc.DeleteDetailAsync(fran, branch, warehouse, planType, planNo, planSrl, ct) ? NoContent() : NotFound();

    // Masters
    [HttpGet("masters")]
    public async Task<ActionResult<IReadOnlyList<OrderPlanMasterDto>>> GetAllMasters(CancellationToken ct)
        => Ok(await svc.GetAllMastersAsync(ct));

    [HttpGet("masters/{fran}/{type}/{name}")]
    public async Task<ActionResult<OrderPlanMasterDto>> GetMasterByKey(string fran, string type, string name, CancellationToken ct)
    {
        var dto = await svc.GetMasterByKeyAsync(fran, type, name, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost("masters")]
    public async Task<ActionResult<OrderPlanMasterDto>> CreateMaster([FromBody] CreateOrderPlanMasterRequest request, CancellationToken ct)
    {
        var dto = await svc.CreateMasterAsync(request, ct);
        return CreatedAtAction(nameof(GetMasterByKey), new { dto.Fran, dto.Type, dto.Name }, dto);
    }

    [HttpPut("masters/{fran}/{type}/{name}")]
    public async Task<ActionResult<OrderPlanMasterDto>> UpdateMaster(string fran, string type, string name, [FromBody] UpdateOrderPlanMasterRequest request, CancellationToken ct)
    {
        var dto = await svc.UpdateMasterAsync(fran, type, name, request, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpDelete("masters/{fran}/{type}/{name}")]
    public async Task<IActionResult> DeleteMaster(string fran, string type, string name, CancellationToken ct)
        => await svc.DeleteMasterAsync(fran, type, name, ct) ? NoContent() : NotFound();
}
