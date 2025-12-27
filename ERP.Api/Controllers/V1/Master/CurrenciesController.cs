using Asp.Versioning;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.V1.Master;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/master/[controller]")]
public sealed class CurrenciesController(ICurrenciesService svc) : ControllerBase
{
    private readonly ICurrenciesService _svc = svc;

#if DEBUG
    [AllowAnonymous]
#endif
    [HttpGet]
    [Authorize(Policy = "erp.api.read")]
    public async Task<ActionResult<IEnumerable<CurrencyDto>>> Get(CancellationToken ct)
        => Ok(await _svc.GetAllAsync(ct));

#if DEBUG
    [AllowAnonymous]
#endif
    [HttpGet("{currencyCode}")]
    [Authorize(Policy = "erp.api.read")]
    public async Task<ActionResult<CurrencyDto>> GetByKey(string currencyCode, CancellationToken ct)
    {
        var item = await _svc.GetByKeyAsync(currencyCode, ct);
        return item is null ? NotFound() : Ok(item);
    }

#if DEBUG
    [AllowAnonymous]
#endif
    [HttpPost]
    [Authorize(Policy = "erp.api.write")]
    public async Task<ActionResult<CurrencyDto>> Create([FromBody] CreateCurrencyRequest request, CancellationToken ct)
    {
        var created = await _svc.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetByKey), new { currencyCode = created.CurrencyCode, version = HttpContext.GetRequestedApiVersion()!.ToString() }, created);
    }

#if DEBUG
    [AllowAnonymous]
#endif
    [HttpPut("{currencyCode}")]
    [Authorize(Policy = "erp.api.write")]
    public async Task<ActionResult<CurrencyDto>> Update(string currencyCode, [FromBody] UpdateCurrencyRequest request, CancellationToken ct)
    {
        var updated = await _svc.UpdateAsync(currencyCode, request, ct);
        return updated is null ? NotFound() : Ok(updated);
    }

#if DEBUG
    [AllowAnonymous]
#endif
    [HttpDelete("{currencyCode}")]
    [Authorize(Policy = "erp.api.write")]
    public async Task<IActionResult> Delete(string currencyCode, CancellationToken ct)
    {
        var ok = await _svc.DeleteAsync(currencyCode, ct);
        return ok ? NoContent() : NotFound();
    }
}
