using MediatR;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Commands
{
    public class EnrollmentApplicationCommand
        : IRequest<bool>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }
    }
}
