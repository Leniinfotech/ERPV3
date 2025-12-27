using Asp.Versioning;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ERP.Application.Interfaces.Services;
using ERP.Contracts.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.V1.Master
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/master/[controller]")]
    #if DEBUG
    [AllowAnonymous] // Dev-only: allow anonymous access to Suppliers endpoints during development
    #endif
    public sealed class SuppliersController : ControllerBase
    {
        private readonly ISuppliersService _svc;
        public SuppliersController(ISuppliersService svc) => _svc = svc;

        /// <summary>List all suppliers.</summary>
        [HttpGet]
        [Authorize(Policy = "erp.suppliers.read")]
        public async Task<ActionResult<IEnumerable<SupplierDto>>> Get(CancellationToken ct)
        {
            var items = await _svc.GetAllAsync(ct);
            return Ok(items);
        }

        /// <summary>Get a supplier by code.</summary>
        [HttpGet("{supplierCode}")]
        [Authorize(Policy = "erp.suppliers.read")]
        public async Task<ActionResult<SupplierDto>> GetByCode(string supplierCode, CancellationToken ct)
        {
            var item = await _svc.GetByCodeAsync(supplierCode, ct);
            if (item is null) return NotFound();
            return Ok(item);
        }

        /// <summary>Create a new supplier.</summary>
        [HttpPost]
        [Authorize(Policy = "erp.suppliers.write")]
        public async Task<ActionResult<SupplierDto>> Create([FromBody] SupplierDto dto, CancellationToken ct)
        {
            var created = await _svc.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetByCode), new { supplierCode = created.SupplierCode, version = HttpContext.GetRequestedApiVersion()!.ToString() }, created);
        }

        /// <summary>Update an existing supplier.</summary>
        [HttpPut("{supplierCode}")]
        [Authorize(Policy = "erp.suppliers.write")]
        public async Task<ActionResult<SupplierDto>> Update(string supplierCode, [FromBody] SupplierDto dto, CancellationToken ct)
        {
            var updated = await _svc.UpdateAsync(supplierCode, dto, ct);
            if (updated is null) return NotFound();
            return Ok(updated);
        }

        /// <summary>Delete a supplier by code.</summary>
        [HttpDelete("{supplierCode}")]
        [Authorize(Policy = "erp.suppliers.write")]
        public async Task<IActionResult> Delete(string supplierCode, CancellationToken ct)
        {
            var ok = await _svc.DeleteAsync(supplierCode, ct);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}