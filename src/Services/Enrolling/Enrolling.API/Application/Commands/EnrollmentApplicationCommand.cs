using MediatR;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Commands
{
    public class EnrollmentApplicationCommand
        : IRequest<bool>
    {
        public EnrollmentApplicationCommand(string name, string email, string mobile)
        {
            Name = name;
            Email = email;
            Mobile = mobile;
        }

        public string Name { get; }

        public string Email { get; }

        public string Mobile { get; }
    }
}
