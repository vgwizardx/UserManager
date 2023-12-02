using MediatR;
using Utilities.Behaviors.Status;
using Microsoft.Extensions.Logging;

namespace Utilities.Behaviors;

public class LoggingPipeLineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    private readonly ILogger<LoggingPipeLineBehavior<TRequest, TResponse>> _logger;

    public LoggingPipeLineBehavior(ILogger<LoggingPipeLineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Started - {@RrequestName} Request at {@DateTimeUtc}",
            typeof(TRequest).Name, DateTime.UtcNow);

        var result = await next();
        if (result.IsFailure)
        {
            _logger.LogError("Failed - {@RrequestName} Request's error message {@Error} at {@DateTimeUtc}",
                typeof(TRequest).Name, result.Error, DateTime.UtcNow);
        }

        _logger.LogInformation(
            "Ended - {@RrequestName} Request at {@DateTimeUtc}", 
            typeof(TRequest).Name, DateTime.UtcNow);
        return result;
    }
}