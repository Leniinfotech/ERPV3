using Asp.Versioning;
using System.Threading;
using System.Threading.Tasks;
using ERP.Application.Reporting;
using ERP.Application.Reporting.Interfaces;
using ERP.Contracts.Reporting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers.V1.Reporting
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/reporting/inventory")]
    public sealed class InventoryReportsController : ControllerBase
    {
        private readonly IInventoryReportingService _svc;
        public InventoryReportsController(IInventoryReportingService svc) => _svc = svc;

        [HttpGet("summary")]
        [Authorize(Policy = "erp.reporting.read")]
        [ProducesResponseType(typeof(InventorySummaryDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<InventorySummaryDto>> GetSummary(
            [FromQuery] string? branch, [FromQuery] string? warehouse, [FromQuery] DateOnly? asOf, CancellationToken ct)
        {
            var dto = await _svc.GetInventorySummaryAsync(new InventorySummaryFilter(branch, warehouse, asOf), ct);
            return Ok(dto);
        }
    }
}