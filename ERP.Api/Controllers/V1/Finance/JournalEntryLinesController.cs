using Asp.Versioning;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Finance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.V1.Finance;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/finance/[controller]")]
#if DEBUG
[AllowAnonymous]
#endif
public sealed class JournalEntryLinesController(IJournalEntryLinesService svc) : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "erp.reporting.read")]
    public async Task<ActionResult<IEnumerable<JournalEntryLineDto>>> Get(CancellationToken ct)
        => Ok(await svc.GetAllAsync(ct));

    [HttpGet("{fran}/{journalEntryId}/{journalEntryLineId}")]
    [Authorize(Policy = "erp.reporting.read")]
    public async Task<ActionResult<JournalEntryLineDto>> GetByKey(string fran, decimal journalEntryId, decimal journalEntryLineId, CancellationToken ct)
    {
        var item = await svc.GetByKeyAsync(fran, journalEntryId, journalEntryLineId, ct);
        return item is null ? NotFound() : Ok(item);
    }
}
