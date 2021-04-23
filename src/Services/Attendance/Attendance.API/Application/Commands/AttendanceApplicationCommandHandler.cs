using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using OpenCodeFoundation.ESchool.Services.Attending.Infrastructure;

namespace OpenCodeFoundation.ESchool.Services.Attending.API.Application.Commands
{
    public sealed class AttendanceApplicationCommandHandler
        : IRequestHandler<AttendanceApplicationCommand, bool>
    {
        private readonly ILogger<AttendanceApplicationCommandHandler> _logger;
        private readonly AttendanceContext _context;

        public AttendanceApplicationCommandHandler(
            AttendanceContext context,
            ILogger<AttendanceApplicationCommandHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(
            AttendanceApplicationCommand command,
            CancellationToken cancellationToken)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var attendance = new Domain.AggregatesModel.AttendanceAggregate.Attendance(command.StudentId, command.CourseId);
            await _context.Attendances.AddAsync(attendance, cancellationToken)
                .ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
            return true;
        }
    }
}
