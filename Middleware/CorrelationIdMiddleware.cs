using Microsoft.AspNetCore.Http;
using Serilog.Context;

namespace Utilities.Middleware;

public class CorrelationIdMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var correlationId = context.Request.Headers["Correlation-ID"].FirstOrDefault() ?? Guid.NewGuid().ToString();
        context.Response.Headers.Append("Correlation-ID", correlationId);
        using (LogContext.PushProperty("CorrelationID", correlationId))
        {
            await next(context);
        }
    }
}