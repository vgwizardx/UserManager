using Microsoft.Net.Http;
using Microsoft.Extensions.Logging;

namespace Utilities.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpClient context)
        {
            
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
