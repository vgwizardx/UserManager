using Microsoft.AspNetCore.Http;
using Serilog.Context;

namespace Utilities.Middleware;

public class CorrelationIdMiddleware : IMiddleware
{
    private const string CorrelationIdHeader = "x-correlation-id";
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var correlationId = context.Request.Headers[CorrelationIdHeader].FirstOrDefault() ?? Guid.NewGuid().ToString();
        context.Response.Headers.Append(CorrelationIdHeader, correlationId);
        using (LogContext.PushProperty(CorrelationIdHeader, correlationId))
        {
            await next(context);
        }
    }
}