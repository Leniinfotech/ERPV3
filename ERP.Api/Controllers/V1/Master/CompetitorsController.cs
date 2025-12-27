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
public class CompetitorsController(ICompetitorService svc) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<CompetitorDto>>> GetAll(CancellationToken ct)
        => Ok(await svc.GetAllAsync(ct));

    [HttpGet("{competitorCode}")]
    public async Task<ActionResult<CompetitorDto>> GetByCode(string competitorCode, CancellationToken ct)
    {
        var dto = await svc.GetByCodeAsync(competitorCode, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<CompetitorDto>> Create([FromBody] CreateCompetitorRequest request, CancellationToken ct)
    {
        var dto = await svc.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetByCode), new { dto.CompetitorCode }, dto);
    }

    [HttpPut("{competitorCode}")]
    public async Task<ActionResult<CompetitorDto>> Update(string competitorCode, [FromBody] UpdateCompetitorRequest request, CancellationToken ct)
    {
        var dto = await svc.UpdateAsync(competitorCode, request, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpDelete("{competitorCode}")]
    public async Task<IActionResult> Delete(string competitorCode, CancellationToken ct)
        => await svc.DeleteAsync(competitorCode, ct) ? NoContent() : NotFound();
}
