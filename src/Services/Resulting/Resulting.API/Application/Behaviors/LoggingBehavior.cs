using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Resulting.API.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
       : IPipelineBehavior<TRequest, TResponse>
           where TRequest : notnull
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(
            ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            if (next is null)
            {
                throw new System.ArgumentNullException(nameof(next));
            }

            _logger.LogInformation(
                "Handling request {RequestName} ({@Request})",
                request.GetType().Name,
                request);

            var response = await next().ConfigureAwait(false);

            _logger.LogInformation(
                "Request {RequestName} handled. Response: {@Response}",
                request.GetType().Name,
                response);

            return response;
        }
    }
}
