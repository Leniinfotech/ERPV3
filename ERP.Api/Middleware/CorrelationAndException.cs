namespace ERP.Api.Middleware;

using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

public sealed class CorrelationSettings
{
    public string HeaderName { get; set; } = "X-Correlation-Id";
}

public sealed class CorrelationIdMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _header;

    public CorrelationIdMiddleware(RequestDelegate next, IOptions<CorrelationSettings> opts)
    {
        _next = next;
        _header = string.IsNullOrWhiteSpace(opts.Value.HeaderName) ? "X-Correlation-Id" : opts.Value.HeaderName;
    }

    public async Task Invoke(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue(_header, out var correlationId) || string.IsNullOrWhiteSpace(correlationId))
        {
            correlationId = Activity.Current?.Id ?? context.TraceIdentifier;
        }

        context.Items["CorrelationId"] = correlationId.ToString();
        context.Response.OnStarting(() =>
        {
            context.Response.Headers[_header] = correlationId.ToString();
            return Task.CompletedTask;
        });

        await _next(context);
    }
}

public sealed class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var status = StatusCodes.Status500InternalServerError;
            _logger.LogError(ex, "Unhandled exception processing {method} {path}", context.Request.Method, context.Request.Path);
            context.Response.StatusCode = status;
            if (_env.IsDevelopment())
            {
                await context.Response.WriteAsJsonAsync(new { error = ex.Message, stack = ex.StackTrace, inner = ex.InnerException?.Message });
            }
            else
            {
                await context.Response.WriteAsJsonAsync(new { error = "An unexpected error occurred." });
            }
        }
    }
}