using Asp.Versioning;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Finance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.V1.Finance;

/// <summary>
/// Read-only controller for Params (system configuration).
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/finance/[controller]")]
#if DEBUG
[AllowAnonymous]
#endif
public class ParamsController(IParamsService svc) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ParamsDto>>> GetAll(CancellationToken ct)
        => Ok(await svc.GetAllAsync(ct));

    [HttpGet("{fran}/{paramType}/{paramValue}")]
    public async Task<ActionResult<ParamsDto>> GetByKey(string fran, string paramType, string paramValue, CancellationToken ct)
    {
        var dto = await svc.GetByKeyAsync(fran, paramType, paramValue, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    // Added: Added method to loadparam
    // Added by: Vaishnavi
    // Added on: 12-12-2025

    [HttpGet("load/{fran}/{paramType}")]
    public async Task<ActionResult<IReadOnlyList<LoadParam>>> LoadParam(string fran, string paramType, CancellationToken ct)
        => Ok(await svc.LoadByParamAsync(fran, paramType, ct));
}
