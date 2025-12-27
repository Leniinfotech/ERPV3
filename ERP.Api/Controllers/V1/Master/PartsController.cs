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
    [AllowAnonymous] // TODO: Dev-only: allow anonymous access to Parts endpoints during development
    #endif
    public sealed class PartsController : ControllerBase
    {
        private readonly IPartsService _svc;
        public PartsController(IPartsService svc) => _svc = svc;

        /// <summary>List all parts.</summary>
        [HttpGet]
        [Authorize(Policy = "erp.inventory.read")]
        public async Task<ActionResult<IEnumerable<PartDto>>> Get(CancellationToken ct)
        {
            var items = await _svc.GetAllAsync(ct);
            return Ok(items);
        }

        /// <summary>Get a part by code.</summary>
        [HttpGet("{partCode}")]
        [Authorize(Policy = "erp.inventory.read")]
        public async Task<ActionResult<PartDto>> GetByCode(string partCode, CancellationToken ct)
        {
            var item = await _svc.GetByCodeAsync(partCode, ct);
            if (item is null) return NotFound();
            return Ok(item);
        }


        // Added: Added endpoint to insert Parts using storedprocedure
        // Added by: Vaishnavi
        // Added on: 10-12-2025
        // <summary>Insert a part</summary>
        [HttpPost("add-part")]
        public async Task<IActionResult> AddPart([FromBody] PartRequests request, CancellationToken ct)
        {
            int result = await _svc.CreatePartAsync(request, ct);

            return result switch
            {
                -1 => BadRequest(new { message = "Part already exists" }),
                1 => Ok(new { message = "Part inserted successfully" }),
                _ => StatusCode(500, new { message = "Unknown error occurred" })
            };
        }

        // Added: Added to get parts
        // Added by: Vaishnavi
        // Added on: 10-12-2025

        [HttpGet("Getparts")]
        public async Task<ActionResult<IEnumerable<PartDto>>> GetAllPartsByStoredProc(CancellationToken ct)
        {
            var items = await _svc.GetAllPartsByStoredProcAsync(ct);
            return Ok(items);
        }


        // Commented by: Vaishnavi
        // Commented on: 10-12-2025



        ///// <summary>Create a new part.</summary>
        //[HttpPost]
        //[Authorize(Policy = "erp.inventory.write")]
        //public async Task<ActionResult<PartDto>> Create([FromBody] CreatePartRequest req, CancellationToken ct)
        //{
        //    var created = await _svc.CreateAsync(req, ct);
        //    return CreatedAtAction(nameof(GetByCode), new { partCode = created.PartCode, version = HttpContext.GetRequestedApiVersion()!.ToString() }, created);
        //}

        ///// <summary>Update an existing part.</summary>
        //[HttpPut("{partCode}")]
        //[Authorize(Policy = "erp.inventory.write")]
        //public async Task<ActionResult<PartDto>> Update(string partCode, [FromBody] CreatePartRequest req, CancellationToken ct)
        //{
        //    var updated = await _svc.UpdateAsync(partCode, req, ct);
        //    if (updated is null) return NotFound();
        //    return Ok(updated);
        //}

        ///// <summary>Delete a part by code.</summary>
        //[HttpDelete("{partCode}")]
        //[Authorize(Policy = "erp.inventory.write")]
        //public async Task<IActionResult> Delete(string partCode, CancellationToken ct)
        //{
        //    var ok = await _svc.DeleteAsync(partCode, ct);
        //    if (!ok) return NotFound();
        //    return NoContent();
        //}

    }
}