using MediatR;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Commands
{
    public class EnrollmentApplicationCommand
        : IRequest<bool>
    {
        public string Name { get; init; }

        public string Email { get; init; }

        public string Mobile { get; init; }
    }
}
