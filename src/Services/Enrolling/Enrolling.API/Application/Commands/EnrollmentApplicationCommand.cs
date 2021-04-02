using MediatR;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Commands
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "StyleCop.CSharp.NamingRules",
        "SA1313:Parameter names should begin with lower-case letter",
        Justification = "This is record")]
    public record EnrollmentApplicationCommand(
            string Name,
            string Email,
            string Mobile)
        : IRequest<bool>;
}
