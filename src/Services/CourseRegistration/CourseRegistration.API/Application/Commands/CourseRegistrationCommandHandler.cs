using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CourseRegistration.Infrastructure;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CourseRegistration.API.Application.Commands
{
    public class CourseRegistrationCommandHandler : IRequestHandler<CourseRegistrationCommand, bool>
    {
        private readonly ILogger<CourseRegistrationCommandHandler> _logger;
        private readonly CourseRegistrationContext _context;

        public CourseRegistrationCommandHandler(CourseRegistrationContext context,
            ILogger<CourseRegistrationCommandHandler> logger)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(CourseRegistrationCommand command, CancellationToken cancellationToken)
        {
            var courseRegistration = new CourseRegistration.Domain.AggregatesModel.CourseRegistrationAggregate.CourseRegistration(command.CourseCode, command.CourseName, command.Description);
            _context.CourseRegistrations.Add(courseRegistration);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
