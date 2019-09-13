using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;
using OpenCodeFoundation.ESchool.Services.Enrolling.Infrastructure;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Commands
{
    public class EnrollmentApplicationCommandHandler
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

        public async Task<bool> Handle(EnrollmentApplicationCommand command, CancellationToken cancellationToken)
        {
            var enrollment = new Enrollment(command.Name, command.Email, command.Mobile);
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
