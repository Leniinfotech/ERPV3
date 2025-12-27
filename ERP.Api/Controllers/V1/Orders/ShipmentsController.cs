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
    public sealed class ShipmentsController : ControllerBase
    {
        private readonly IShipmentsService _svc;
        public ShipmentsController(IShipmentsService svc) => _svc = svc;

        /// <summary>List all shipments.</summary>
        [HttpGet]
        [Authorize(Policy = "erp.orders.read")]
        public async Task<ActionResult<IEnumerable<ShipmentDto>>> Get(CancellationToken ct)
        {
            var items = await _svc.GetAllAsync(ct);
            return Ok(items);
        }

        /// <summary>Get a shipment by composite key.</summary>
        [HttpGet("{fran}/{branch}/{warehouseCode}/{shipmentType}/{shipmentNumber}")]
        [Authorize(Policy = "erp.orders.read")]
        public async Task<ActionResult<ShipmentDto>> GetByKey(string fran, string branch, string warehouseCode, string shipmentType, string shipmentNumber, CancellationToken ct)
        {
            var item = await _svc.GetByKeyAsync(fran, branch, warehouseCode, shipmentType, shipmentNumber, ct);
            if (item is null) return NotFound();
            return Ok(item);
        }

        /// <summary>Create a new shipment.</summary>
        [HttpPost]
        [Authorize(Policy = "erp.orders.write")]
        public async Task<ActionResult<ShipmentDto>> Create([FromBody] ShipmentDto dto, CancellationToken ct)
        {
            var created = await _svc.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetByKey), new { fran = created.Fran, branch = created.Branch, warehouseCode = created.WarehouseCode, shipmentType = created.ShipmentType, shipmentNumber = created.ShipmentNumber, version = HttpContext.GetRequestedApiVersion()!.ToString() }, created);
        }

        /// <summary>Update an existing shipment.</summary>
        [HttpPut("{fran}/{branch}/{warehouseCode}/{shipmentType}/{shipmentNumber}")]
        [Authorize(Policy = "erp.orders.write")]
        public async Task<ActionResult<ShipmentDto>> Update(string fran, string branch, string warehouseCode, string shipmentType, string shipmentNumber, [FromBody] ShipmentDto dto, CancellationToken ct)
        {
            var updated = await _svc.UpdateAsync(fran, branch, warehouseCode, shipmentType, shipmentNumber, dto, ct);
            if (updated is null) return NotFound();
            return Ok(updated);
        }

        /// <summary>Delete a shipment by composite key.</summary>
        [HttpDelete("{fran}/{branch}/{warehouseCode}/{shipmentType}/{shipmentNumber}")]
        [Authorize(Policy = "erp.orders.write")]
        public async Task<IActionResult> Delete(string fran, string branch, string warehouseCode, string shipmentType, string shipmentNumber, CancellationToken ct)
        {
            var ok = await _svc.DeleteAsync(fran, branch, warehouseCode, shipmentType, shipmentNumber, ct);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}