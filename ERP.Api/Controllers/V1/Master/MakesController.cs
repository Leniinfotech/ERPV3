using Asp.Versioning;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.V1.Master;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/master/[controller]")]
public sealed class MakesController(IMakesService svc) : ControllerBase
{
    private readonly IMakesService _svc = svc;

#if DEBUG
    [AllowAnonymous]
#endif
    [HttpGet]
    [Authorize(Policy = "erp.api.read")]
    public async Task<ActionResult<IEnumerable<MakeDto>>> Get(CancellationToken ct)
        => Ok(await _svc.GetAllAsync(ct));

#if DEBUG
    [AllowAnonymous]
#endif
    [HttpGet("{fran}/{makeCode}")]
    [Authorize(Policy = "erp.api.read")]
    public async Task<ActionResult<MakeDto>> GetByKey(string fran, string makeCode, CancellationToken ct)
    {
        var item = await _svc.GetByKeyAsync(fran, makeCode, ct);
        return item is null ? NotFound() : Ok(item);
    }

#if DEBUG
    [AllowAnonymous]
#endif
    [HttpPost]
    [Authorize(Policy = "erp.api.write")]
    public async Task<ActionResult<MakeDto>> Create([FromBody] CreateMakeRequest request, CancellationToken ct)
    {
        var created = await _svc.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetByKey), new { fran = created.Fran, makeCode = created.MakeCode, version = HttpContext.GetRequestedApiVersion()!.ToString() }, created);
    }

#if DEBUG
    [AllowAnonymous]
#endif
    [HttpPut("{fran}/{makeCode}")]
    [Authorize(Policy = "erp.api.write")]
    public async Task<ActionResult<MakeDto>> Update(string fran, string makeCode, [FromBody] UpdateMakeRequest request, CancellationToken ct)
    {
        var updated = await _svc.UpdateAsync(fran, makeCode, request, ct);
        return updated is null ? NotFound() : Ok(updated);
    }

#if DEBUG
    [AllowAnonymous]
#endif
    [HttpDelete("{fran}/{makeCode}")]
    [Authorize(Policy = "erp.api.write")]
    public async Task<IActionResult> Delete(string fran, string makeCode, CancellationToken ct)
    {
        var ok = await _svc.DeleteAsync(fran, makeCode, ct);
        return ok ? NoContent() : NotFound();
    }


    [HttpGet("GetMake")]
    public async Task<ActionResult<IEnumerable<MakeDto>>> GetFromSP(CancellationToken ct)
        => Ok(await _svc.GetMake(ct));
}
