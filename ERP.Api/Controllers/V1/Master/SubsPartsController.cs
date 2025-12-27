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
public class SubsPartsController(ISubsPartService svc) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<SubsPartDto>>> GetAll(CancellationToken ct)
        => Ok(await svc.GetAllAsync(ct));

    [HttpGet("{fran}/{make}/{part}/{finalPart}/{grpNo:decimal}")]
    public async Task<ActionResult<SubsPartDto>> GetByKey(string fran, string make, string part, string finalPart, decimal grpNo, CancellationToken ct)
    {
        var dto = await svc.GetByKeyAsync(fran, make, part, finalPart, grpNo, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<SubsPartDto>> Create([FromBody] CreateSubsPartRequest request, CancellationToken ct)
    {
        var dto = await svc.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetByKey), new { dto.Fran, dto.Make, dto.Part, dto.FinalPart, dto.GrpNo }, dto);
    }

    [HttpPut("{fran}/{make}/{part}/{finalPart}/{grpNo:decimal}")]
    public async Task<ActionResult<SubsPartDto>> Update(string fran, string make, string part, string finalPart, decimal grpNo, [FromBody] UpdateSubsPartRequest request, CancellationToken ct)
    {
        var dto = await svc.UpdateAsync(fran, make, part, finalPart, grpNo, request, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpDelete("{fran}/{make}/{part}/{finalPart}/{grpNo:decimal}")]
    public async Task<IActionResult> Delete(string fran, string make, string part, string finalPart, decimal grpNo, CancellationToken ct)
        => await svc.DeleteAsync(fran, make, part, finalPart, grpNo, ct) ? NoContent() : NotFound();
}
