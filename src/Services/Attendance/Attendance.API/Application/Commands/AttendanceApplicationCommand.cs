using MediatR;

namespace OpenCodeFoundation.ESchool.Services.Attending.API.Application.Commands
{
    public record AttendanceApplicationCommand(
            string StudentId,
            string CourseId)
        : IRequest<bool>;
}
