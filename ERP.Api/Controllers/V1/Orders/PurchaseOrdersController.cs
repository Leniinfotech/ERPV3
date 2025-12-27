using Asp.Versioning;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.V1.Orders
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/orders/[controller]")]
    #if DEBUG
    [AllowAnonymous]
    #endif
    public sealed class PurchaseOrdersController : ControllerBase
    {
        private readonly IPurchaseOrdersService _svc;
        public PurchaseOrdersController(IPurchaseOrdersService svc) => _svc = svc;

        /// <summary>List all purchase order headers.</summary>
        [HttpGet]
        [Authorize(Policy = "erp.orders.read")]
        public async Task<ActionResult<IEnumerable<PurchaseOrderDto>>> Get(CancellationToken ct)
        {
            var items = await _svc.GetAllAsync(ct);
            return Ok(items);
        }

        /// <summary>Get a purchase order (with lines) by composite key.</summary>
        [HttpGet("{fran}/{branch}/{warehouseCode}/{poType}/{poNumber}")]
        [Authorize(Policy = "erp.orders.read")]
        public async Task<ActionResult<PurchaseOrderDto>> GetByKey(string fran, string branch, string warehouseCode, string poType, string poNumber, CancellationToken ct)
        {
            var item = await _svc.GetByKeyAsync(fran, branch, warehouseCode, poType, poNumber, ct);
            if (item is null) return NotFound();
            return Ok(item);
        }

        /// <summary>Create a new purchase order (header + lines).</summary>
        [HttpPost]
        [Authorize(Policy = "erp.orders.write")]
        public async Task<ActionResult<PurchaseOrderDto>> Create([FromBody] PurchaseOrderDto dto, CancellationToken ct)
        {
            var created = await _svc.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetByKey), new { fran = created.Fran, branch = created.Branch, warehouseCode = created.WarehouseCode, poType = created.PoType, poNumber = created.PoNumber, version = HttpContext.GetRequestedApiVersion()!.ToString() }, created);
        }

        /// <summary>Update an existing purchase order (header + lines).</summary>
        [HttpPut("{fran}/{branch}/{warehouseCode}/{poType}/{poNumber}")]
        [Authorize(Policy = "erp.orders.write")]
        public async Task<ActionResult<PurchaseOrderDto>> Update(string fran, string branch, string warehouseCode, string poType, string poNumber, [FromBody] PurchaseOrderDto dto, CancellationToken ct)
        {
            var updated = await _svc.UpdateAsync(fran, branch, warehouseCode, poType, poNumber, dto, ct);
            if (updated is null) return NotFound();
            return Ok(updated);
        }

        /// <summary>Delete a purchase order by composite key.</summary>
        [HttpDelete("{fran}/{branch}/{warehouseCode}/{poType}/{poNumber}")]
        [Authorize(Policy = "erp.orders.write")]
        public async Task<IActionResult> Delete(string fran, string branch, string warehouseCode, string poType, string poNumber, CancellationToken ct)
        {
            var ok = await _svc.DeleteAsync(fran, branch, warehouseCode, poType, poNumber, ct);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}