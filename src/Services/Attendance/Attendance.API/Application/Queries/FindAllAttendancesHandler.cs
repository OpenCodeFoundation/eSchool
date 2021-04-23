using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OpenCodeFoundation.ESchool.Services.Attending.Infrastructure;

namespace OpenCodeFoundation.ESchool.Services.Attending.API.Application.Queries
{
    public class FindAllAttendancesHandler
        : IRequestHandler<FindAllAttendancesQuery, IEnumerable<Domain.AggregatesModel.AttendanceAggregate.Attendance>>
    {
        private readonly AttendanceContext _context;

        public FindAllAttendancesHandler(AttendanceContext context)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Domain.AggregatesModel.AttendanceAggregate.Attendance>> Handle(
            FindAllAttendancesQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Attendances.ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
