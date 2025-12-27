using Asp.Versioning;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.V1.Master;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/master/[controller]")]
#if DEBUG
[AllowAnonymous]
#endif
public class PriceGroupsController(IPriceGroupService svc) : ControllerBase
{
    // Masters
    [HttpGet("masters")]
    public async Task<ActionResult<IReadOnlyList<PriceGroupMasterDto>>> GetAllMasters(CancellationToken ct)
        => Ok(await svc.GetAllMastersAsync(ct));

    [HttpGet("masters/{fran}/{prcType}/{prcGrp}")]
    public async Task<ActionResult<PriceGroupMasterDto>> GetMasterByKey(string fran, string prcType, string prcGrp, CancellationToken ct)
    {
        var dto = await svc.GetMasterByKeyAsync(fran, prcType, prcGrp, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost("masters")]
    public async Task<ActionResult<PriceGroupMasterDto>> CreateMaster([FromBody] CreatePriceGroupMasterRequest request, CancellationToken ct)
    {
        var dto = await svc.CreateMasterAsync(request, ct);
        return CreatedAtAction(nameof(GetMasterByKey), new { dto.Fran, dto.PrcType, dto.PrcGrp }, dto);
    }

    [HttpPut("masters/{fran}/{prcType}/{prcGrp}")]
    public async Task<ActionResult<PriceGroupMasterDto>> UpdateMaster(string fran, string prcType, string prcGrp, [FromBody] UpdatePriceGroupMasterRequest request, CancellationToken ct)
    {
        var dto = await svc.UpdateMasterAsync(fran, prcType, prcGrp, request, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpDelete("masters/{fran}/{prcType}/{prcGrp}")]
    public async Task<IActionResult> DeleteMaster(string fran, string prcType, string prcGrp, CancellationToken ct)
        => await svc.DeleteMasterAsync(fran, prcType, prcGrp, ct) ? NoContent() : NotFound();

    // Factors
    [HttpGet("factors")]
    public async Task<ActionResult<IReadOnlyList<PriceGroupFactorDto>>> GetAllFactors(CancellationToken ct)
        => Ok(await svc.GetAllFactorsAsync(ct));

    [HttpGet("factors/{fran}/{type}/{prcGrp}/{name}/{value}")]
    public async Task<ActionResult<PriceGroupFactorDto>> GetFactorByKey(string fran, string type, string prcGrp, string name, string value, CancellationToken ct)
    {
        var dto = await svc.GetFactorByKeyAsync(fran, type, prcGrp, name, value, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost("factors")]
    public async Task<ActionResult<PriceGroupFactorDto>> CreateFactor([FromBody] CreatePriceGroupFactorRequest request, CancellationToken ct)
    {
        var dto = await svc.CreateFactorAsync(request, ct);
        return CreatedAtAction(nameof(GetFactorByKey), new { dto.Fran, dto.Type, dto.PrcGrp, dto.Name, dto.Value }, dto);
    }

    [HttpPut("factors/{fran}/{type}/{prcGrp}/{name}/{value}")]
    public async Task<ActionResult<PriceGroupFactorDto>> UpdateFactor(string fran, string type, string prcGrp, string name, string value, [FromBody] UpdatePriceGroupFactorRequest request, CancellationToken ct)
    {
        var dto = await svc.UpdateFactorAsync(fran, type, prcGrp, name, value, request, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpDelete("factors/{fran}/{type}/{prcGrp}/{name}/{value}")]
    public async Task<IActionResult> DeleteFactor(string fran, string type, string prcGrp, string name, string value, CancellationToken ct)
        => await svc.DeleteFactorAsync(fran, type, prcGrp, name, value, ct) ? NoContent() : NotFound();
}
