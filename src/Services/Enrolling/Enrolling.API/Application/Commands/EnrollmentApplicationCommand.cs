using MediatR;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Commands
{
    public record EnrollmentApplicationCommand(
            string Name,
            string Email,
            string Mobile)
        : IRequest<Enrollment>;
}
