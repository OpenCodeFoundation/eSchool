using System.Collections.Generic;
using MediatR;

namespace OpenCodeFoundation.ESchool.Services.Attending.API.Application.Queries
{
    public class FindAllAttendancesQuery
        : IRequest<IEnumerable<Domain.AggregatesModel.AttendanceAggregate.Attendance>>
    {
    }
}
