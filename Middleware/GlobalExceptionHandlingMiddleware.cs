using System;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Utilities.Middleware;

public class GlobalExceptionHandlingMiddleware(ILogger logger) : IMiddleware
{
    private readonly ILogger _logger = logger.ForContext<GlobalExceptionHandlingMiddleware>();

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            _logger.Error(e, "Failed - An exception occurred: {@ErrorMessage}", e.Message);


            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ProblemDetails problem = new()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type = "Server Error",
                Title = "Server Error",
                Detail = "An internal server error has occurred"
            };

            var json = JsonSerializer.Serialize(problem);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(json);
        }
    }
}