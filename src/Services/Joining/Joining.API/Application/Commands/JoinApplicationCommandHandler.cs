using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using OpenCodeFoundation.ESchool.Services.Joining.Domain.AggregatesModel.JoinAggregate;
using OpenCodeFoundation.ESchool.Services.Joining.Infrastructure;

namespace OpenCodeFoundation.ESchool.Services.Joining.API.Application.Commands
{
    public class JoinApplicationCommandHandler
        :IRequestHandler<JoinApplicationCommand, bool>
    {
        private readonly ILogger<JoinApplicationCommandHandler> _logger;
        private readonly JoiningContext _context;

        public JoinApplicationCommandHandler(
            JoiningContext context,
            ILogger<JoinApplicationCommandHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(JoinApplicationCommand command, CancellationToken cancellationToken)
        {
            var join = new Join(command.Name, command.Email, command.Mobile);
            _context.Joins.Add(join);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
