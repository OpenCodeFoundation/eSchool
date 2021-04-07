using MediatR;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Commands
{
    public record EnrollmentApplicationCommand(
            string Name,
            string Email,
            string Mobile)
        : IRequest<bool>;
}
