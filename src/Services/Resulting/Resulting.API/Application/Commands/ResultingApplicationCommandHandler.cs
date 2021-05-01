using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Resulting.Infrastructure;
using Resulting.Domain.AggregateModel.ResultingAggregate;

namespace Resulting.API.Application.Commands
{
    public class ResultingApplicationCommandHandler : IRequestHandler<ResultingApplicationCommand, bool>
    {
        private readonly ILogger<ResultingApplicationCommandHandler> _logger;
        private readonly ResultingContext _context;

        public ResultingApplicationCommandHandler(
            ResultingContext context,
            ILogger<ResultingApplicationCommandHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(
            ResultingApplicationCommand command,
            CancellationToken cancellationToken)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var resulting = new Results(command.Result, command.GradeScale, command.Grade);
            await _context.Resulting.AddAsync(resulting, cancellationToken)
                .ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
            return true;
        }
    }
}
