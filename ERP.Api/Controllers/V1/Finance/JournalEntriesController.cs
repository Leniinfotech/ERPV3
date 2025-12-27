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
public sealed class JournalEntriesController(IJournalEntriesService querySvc,IJournalEntriesService commandSvc) : ControllerBase
{
    // Added: Added controller to insert journal 
    // Added by: Vaishnavi
    // Added on: 15-12-2025

    [HttpPost("InsertJournal")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> InsertJournal(
        [FromBody] InsertJournalEntryRequestDto dto,
        CancellationToken ct)
    {
        await commandSvc.InsertAsync(dto, ct);
        return Ok(new { message = "Payment successfully" });
    }

    // Commented by: Vaishnavi
    // Commented on: 15-12-2025

    //[HttpGet]
    //[Authorize(Policy = "erp.reporting.read")]
    //public async Task<ActionResult<IEnumerable<JournalEntryHeaderDto>>> Get(CancellationToken ct)
    //    => Ok(await svc.GetAllAsync(ct));

    //[HttpGet("{fran}/{journalType}/{journalEntryId}")]
    //[Authorize(Policy = "erp.reporting.read")]
    //public async Task<ActionResult<JournalEntryHeaderDto>> GetByKey(string fran, string journalType, decimal journalEntryId, CancellationToken ct)
    //{
    //    var item = await svc.GetByKeyAsync(fran, journalType, journalEntryId, ct);
    //    return item is null ? NotFound() : Ok(item);
    //}
}
