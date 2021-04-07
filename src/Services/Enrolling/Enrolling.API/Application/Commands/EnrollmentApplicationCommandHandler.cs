using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;
using OpenCodeFoundation.ESchool.Services.Enrolling.Infrastructure;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Commands
{
    public sealed class EnrollmentApplicationCommandHandler
        : IRequestHandler<EnrollmentApplicationCommand, bool>
    {
        private readonly ILogger<EnrollmentApplicationCommandHandler> _logger;
        private readonly EnrollingContext _context;

        public EnrollmentApplicationCommandHandler(
            EnrollingContext context,
            ILogger<EnrollmentApplicationCommandHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(
            EnrollmentApplicationCommand command,
            CancellationToken cancellationToken)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var enrollment = new Enrollment(command.Name, command.Email, command.Mobile);
            await _context.Enrollments.AddAsync(enrollment, cancellationToken)
                .ConfigureAwait(false);
            await _context.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
            return true;
        }
    }
}
