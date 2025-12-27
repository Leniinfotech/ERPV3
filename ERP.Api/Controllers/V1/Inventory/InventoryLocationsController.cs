using Asp.Versioning;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Inventory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.V1.Inventory
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/inventory/[controller]")]
    #if DEBUG
    [AllowAnonymous] // Dev-only: allow anonymous access during development
    #endif
    public sealed class InventoryLocationsController : ControllerBase
    {
        private readonly IInventoryLocationsService _svc;
        public InventoryLocationsController(IInventoryLocationsService svc) => _svc = svc;

        /// <summary>List all inventory locations.</summary>
        [HttpGet]
        [Authorize(Policy = "erp.inventory.read")]
        public async Task<ActionResult<IEnumerable<InventoryLocationDto>>> Get(CancellationToken ct)
        {
            var items = await _svc.GetAllAsync(ct);
            return Ok(items);
        }

        /// <summary>Get a location by code.</summary>
        [HttpGet("{warehouseCode}")]
        [Authorize(Policy = "erp.inventory.read")]
        public async Task<ActionResult<InventoryLocationDto>> GetByCode(string warehouseCode, CancellationToken ct)
        {
            var item = await _svc.GetByCodeAsync(warehouseCode, ct);
            if (item is null) return NotFound();
            return Ok(item);
        }

        /// <summary>Create a new location.</summary>
        [HttpPost]
        [Authorize(Policy = "erp.inventory.write")]
        public async Task<ActionResult<InventoryLocationDto>> Create([FromBody] InventoryLocationDto dto, CancellationToken ct)
        {
            var created = await _svc.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetByCode), new { warehouseCode = created.WarehouseCode, version = HttpContext.GetRequestedApiVersion()!.ToString() }, created);
        }

        /// <summary>Update an existing location.</summary>
        [HttpPut("{warehouseCode}")]
        [Authorize(Policy = "erp.inventory.write")]
        public async Task<ActionResult<InventoryLocationDto>> Update(string warehouseCode, [FromBody] InventoryLocationDto dto, CancellationToken ct)
        {
            var updated = await _svc.UpdateAsync(warehouseCode, dto, ct);
            if (updated is null) return NotFound();
            return Ok(updated);
        }

        /// <summary>Delete a location by code.</summary>
        [HttpDelete("{warehouseCode}")]
        [Authorize(Policy = "erp.inventory.write")]
        public async Task<IActionResult> Delete(string warehouseCode, CancellationToken ct)
        {
            var ok = await _svc.DeleteAsync(warehouseCode, ct);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}