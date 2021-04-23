using System.Collections.Generic;
using MediatR;
using OpenCodeFoundation.ESchool.Services.Attendance.Domain.AggregatesModel.EnrollmentAggregate;

namespace OpenCodeFoundation.ESchool.Services.Attendance.API.Application.Queries
{
    public class FindAllAttendancesQuery
        : IRequest<IEnumerable<Attendance>>
    {
    }
}
