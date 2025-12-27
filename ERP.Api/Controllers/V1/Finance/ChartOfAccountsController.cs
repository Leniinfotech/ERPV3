using Asp.Versioning;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Finance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.V1.Finance;

/// <summary>
/// Read-only controller for Chart of Accounts (CHARTOFACCOUNTS).
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/finance/[controller]")]
#if DEBUG
[AllowAnonymous]
#endif
public class ChartOfAccountsController(IChartOfAccountsService svc) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ChartOfAccountsDto>>> GetAll(CancellationToken ct)
        => Ok(await svc.GetAllAsync(ct));

    [HttpGet("{fran}/{accountType}/{accountCode}")]
    public async Task<ActionResult<ChartOfAccountsDto>> GetByKey(string fran, string accountType, string accountCode, CancellationToken ct)
    {
        var dto = await svc.GetByKeyAsync(fran, accountType, accountCode, ct);
        return dto is null ? NotFound() : Ok(dto);
    }
}
