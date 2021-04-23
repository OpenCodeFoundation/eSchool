using MediatR;

namespace OpenCodeFoundation.ESchool.Services.Attendance.API.Application.Commands
{
    public record AttendanceApplicationCommand(
            string Name,
            string Email,
            string Mobile)
        : IRequest<bool>;
}
