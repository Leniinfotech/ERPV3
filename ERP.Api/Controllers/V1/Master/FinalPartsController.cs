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
public class FinalPartsController(IFinalPartService svc) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<FinalPartDto>>> GetAll(CancellationToken ct)
        => Ok(await svc.GetAllAsync(ct));

    [HttpGet("{fran}/{make}/{part}")]
    public async Task<ActionResult<FinalPartDto>> GetByKey(string fran, string make, string part, CancellationToken ct)
    {
        var dto = await svc.GetByKeyAsync(fran, make, part, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<FinalPartDto>> Create([FromBody] CreateFinalPartRequest request, CancellationToken ct)
    {
        var dto = await svc.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetByKey), new { dto.Fran, dto.Make, dto.Part }, dto);
    }

    [HttpPut("{fran}/{make}/{part}")]
    public async Task<ActionResult<FinalPartDto>> Update(string fran, string make, string part, [FromBody] UpdateFinalPartRequest request, CancellationToken ct)
    {
        var dto = await svc.UpdateAsync(fran, make, part, request, ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpDelete("{fran}/{make}/{part}")]
    public async Task<IActionResult> Delete(string fran, string make, string part, CancellationToken ct)
        => await svc.DeleteAsync(fran, make, part, ct) ? NoContent() : NotFound();
}
