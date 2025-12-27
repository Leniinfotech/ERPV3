using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;

namespace ERP.Api.Controllers.V1.Diagnostics;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/diagnostics")]
public sealed class DiagnosticsController : ControllerBase
{
    /// <summary>
    /// Simple health check endpoint.
    /// </summary>
    [HttpGet("health")] 
    [AllowAnonymous]
    public IActionResult Health() => Ok(new { status = "ok" });

    /// <summary>
    /// Returns the current correlation identifier.
    /// </summary>
    [HttpGet("correlation")]
    [AllowAnonymous]
    public IActionResult Correlation()
    {
        var header = HttpContext.Request.Headers["X-Correlation-Id"].FirstOrDefault();
        var item = HttpContext.Items["CorrelationId"]?.ToString();
        return Ok(new { header, item });
    }
}