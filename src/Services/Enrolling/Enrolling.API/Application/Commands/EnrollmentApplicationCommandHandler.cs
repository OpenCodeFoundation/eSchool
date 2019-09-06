using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;
using OpenCodeFoundation.ESchool.Services.Enrolling.Infrastructure;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Commands
{
    public class EnrollmentApplicationCommandHandler
        : IRequestHandler<EnrollmentApplicationCommand, bool>
    {
        private readonly EnrollingContext _context;

        public EnrollmentApplicationCommandHandler(EnrollingContext context)
        {
            _context = context;
        }

        public Task<bool> Handle(EnrollmentApplicationCommand request, CancellationToken cancellationToken)
        {
            var enrollment = new Enrollment(request.Name, request.Email, request.Mobile);
            return Task.FromResult(true);
        }
    }
}
