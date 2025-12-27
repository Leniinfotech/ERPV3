using Asp.Versioning;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Inventory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.V1.Inventory;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/inventory/[controller]")]
public sealed class StoresController(IStoresService svc) : ControllerBase
{
    private readonly IStoresService _svc = svc;

#if DEBUG
    [AllowAnonymous]
#endif
    [HttpGet]
    [Authorize(Policy = "erp.api.read")]
    public async Task<ActionResult<IEnumerable<StoreDto>>> Get(CancellationToken ct)
        => Ok(await _svc.GetAllAsync(ct));

#if DEBUG
    [AllowAnonymous]
#endif
    [HttpGet("{fran}/{branch}/{warehouseCode}/{storeCode}")]
    [Authorize(Policy = "erp.api.read")]
    public async Task<ActionResult<StoreDto>> GetByKey(string fran, string branch, string warehouseCode, string storeCode, CancellationToken ct)
    {
        var item = await _svc.GetByKeyAsync(fran, branch, warehouseCode, storeCode, ct);
        return item is null ? NotFound() : Ok(item);
    }

#if DEBUG
    [AllowAnonymous]
#endif
    [HttpPost]
    [Authorize(Policy = "erp.api.write")]
    public async Task<ActionResult<StoreDto>> Create([FromBody] CreateStoreRequest request, CancellationToken ct)
    {
        var created = await _svc.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetByKey), new { fran = created.Fran, branch = created.Branch, warehouseCode = created.WarehouseCode, storeCode = created.StoreCode, version = HttpContext.GetRequestedApiVersion()!.ToString() }, created);
    }

#if DEBUG
    [AllowAnonymous]
#endif
    [HttpPut("{fran}/{branch}/{warehouseCode}/{storeCode}")]
    [Authorize(Policy = "erp.api.write")]
    public async Task<ActionResult<StoreDto>> Update(string fran, string branch, string warehouseCode, string storeCode, [FromBody] UpdateStoreRequest request, CancellationToken ct)
    {
        var updated = await _svc.UpdateAsync(fran, branch, warehouseCode, storeCode, request, ct);
        return updated is null ? NotFound() : Ok(updated);
    }

#if DEBUG
    [AllowAnonymous]
#endif
    [HttpDelete("{fran}/{branch}/{warehouseCode}/{storeCode}")]
    [Authorize(Policy = "erp.api.write")]
    public async Task<IActionResult> Delete(string fran, string branch, string warehouseCode, string storeCode, CancellationToken ct)
    {
        var ok = await _svc.DeleteAsync(fran, branch, warehouseCode, storeCode, ct);
        return ok ? NoContent() : NotFound();
    }
}
