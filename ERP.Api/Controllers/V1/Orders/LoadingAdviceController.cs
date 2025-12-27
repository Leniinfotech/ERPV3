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
public class LoadingAdviceController(ILoadingAdviceService svc) : ControllerBase
{
    // Headers
    [HttpGet("headers")]
    public async Task<ActionResult<IReadOnlyList<LoadingAdviceHeaderDto>>> GetAllHeaders(CancellationToken ct)
        => Ok(await svc.GetAllHeadersAsync(ct));

    [HttpGet("headers/{fran}/{branch}/{warehouse}/{laType}/{laNo}")]
    public async Task<ActionResult<LoadingAdviceHeaderDto>> GetHeaderByKey(string fran, string branch, string warehouse, string laType, string laNo, CancellationToken ct)
    {
        var dto = await svc.GetHeaderByKeyAsync(fran, branch, warehouse, laType, laNo, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost("headers")]
    public async Task<ActionResult<LoadingAdviceHeaderDto>> CreateHeader([FromBody] CreateLoadingAdviceHeaderRequest request, CancellationToken ct)
    {
        var dto = await svc.CreateHeaderAsync(request, ct);
        return CreatedAtAction(nameof(GetHeaderByKey), new { dto.Fran, dto.Branch, dto.Warehouse, dto.LaType, dto.LaNo }, dto);
    }

    [HttpPut("headers/{fran}/{branch}/{warehouse}/{laType}/{laNo}")]
    public async Task<ActionResult<LoadingAdviceHeaderDto>> UpdateHeader(string fran, string branch, string warehouse, string laType, string laNo, [FromBody] UpdateLoadingAdviceHeaderRequest request, CancellationToken ct)
    {
        var dto = await svc.UpdateHeaderAsync(fran, branch, warehouse, laType, laNo, request, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpDelete("headers/{fran}/{branch}/{warehouse}/{laType}/{laNo}")]
    public async Task<IActionResult> DeleteHeader(string fran, string branch, string warehouse, string laType, string laNo, CancellationToken ct)
        => await svc.DeleteHeaderAsync(fran, branch, warehouse, laType, laNo, ct) ? NoContent() : NotFound();

    // Details
    [HttpGet("details")]
    public async Task<ActionResult<IReadOnlyList<LoadingAdviceDetailDto>>> GetAllDetails(CancellationToken ct)
        => Ok(await svc.GetAllDetailsAsync(ct));

    [HttpGet("details/{fran}/{branch}/{warehouse}/{laType}/{laNo}/{crtnType}/{crtn}")]
    public async Task<ActionResult<LoadingAdviceDetailDto>> GetDetailByKey(string fran, string branch, string warehouse, string laType, string laNo, string crtnType, string crtn, CancellationToken ct)
    {
        var dto = await svc.GetDetailByKeyAsync(fran, branch, warehouse, laType, laNo, crtnType, crtn, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost("details")]
    public async Task<ActionResult<LoadingAdviceDetailDto>> CreateDetail([FromBody] CreateLoadingAdviceDetailRequest request, CancellationToken ct)
    {
        var dto = await svc.CreateDetailAsync(request, ct);
        return CreatedAtAction(nameof(GetDetailByKey), new { dto.Fran, dto.Branch, dto.Warehouse, dto.LaType, dto.LaNo, dto.CrtnType, dto.Crtn }, dto);
    }

    [HttpPut("details/{fran}/{branch}/{warehouse}/{laType}/{laNo}/{crtnType}/{crtn}")]
    public async Task<ActionResult<LoadingAdviceDetailDto>> UpdateDetail(string fran, string branch, string warehouse, string laType, string laNo, string crtnType, string crtn, [FromBody] UpdateLoadingAdviceDetailRequest request, CancellationToken ct)
    {
        var dto = await svc.UpdateDetailAsync(fran, branch, warehouse, laType, laNo, crtnType, crtn, request, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpDelete("details/{fran}/{branch}/{warehouse}/{laType}/{laNo}/{crtnType}/{crtn}")]
    public async Task<IActionResult> DeleteDetail(string fran, string branch, string warehouse, string laType, string laNo, string crtnType, string crtn, CancellationToken ct)
        => await svc.DeleteDetailAsync(fran, branch, warehouse, laType, laNo, crtnType, crtn, ct) ? NoContent() : NotFound();

    // Details2
    [HttpGet("details2")]
    public async Task<ActionResult<IReadOnlyList<LoadingAdviceDetail2Dto>>> GetAllDetails2(CancellationToken ct)
        => Ok(await svc.GetAllDetails2Async(ct));

    [HttpGet("details2/{fran}/{branch}/{warehouse}/{invType}/{invNo}/{invSrl:decimal}")]
    public async Task<ActionResult<LoadingAdviceDetail2Dto>> GetDetail2ByKey(string fran, string branch, string warehouse, string invType, string invNo, decimal invSrl, CancellationToken ct)
    {
        var dto = await svc.GetDetail2ByKeyAsync(fran, branch, warehouse, invType, invNo, invSrl, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost("details2")]
    public async Task<ActionResult<LoadingAdviceDetail2Dto>> CreateDetail2([FromBody] CreateLoadingAdviceDetail2Request request, CancellationToken ct)
    {
        var dto = await svc.CreateDetail2Async(request, ct);
        return CreatedAtAction(nameof(GetDetail2ByKey), new { dto.Fran, dto.Branch, dto.Warehouse, dto.InvType, dto.InvNo, dto.InvSrl }, dto);
    }

    [HttpPut("details2/{fran}/{branch}/{warehouse}/{invType}/{invNo}/{invSrl:decimal}")]
    public async Task<ActionResult<LoadingAdviceDetail2Dto>> UpdateDetail2(string fran, string branch, string warehouse, string invType, string invNo, decimal invSrl, [FromBody] UpdateLoadingAdviceDetail2Request request, CancellationToken ct)
    {
        var dto = await svc.UpdateDetail2Async(fran, branch, warehouse, invType, invNo, invSrl, request, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpDelete("details2/{fran}/{branch}/{warehouse}/{invType}/{invNo}/{invSrl:decimal}")]
    public async Task<IActionResult> DeleteDetail2(string fran, string branch, string warehouse, string invType, string invNo, decimal invSrl, CancellationToken ct)
        => await svc.DeleteDetail2Async(fran, branch, warehouse, invType, invNo, invSrl, ct) ? NoContent() : NotFound();
}
