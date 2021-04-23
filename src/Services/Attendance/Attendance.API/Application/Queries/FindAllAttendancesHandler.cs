using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;
using OpenCodeFoundation.ESchool.Services.Enrolling.Infrastructure;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Queries
{
    public class FindAllAttendancesHandler
        : IRequestHandler<FindAllAttendancesQuery, IEnumerable<Attendance>>
    {
        private readonly AttendanceContext _context;

        public FindAllAttendancesHandler(AttendanceContext context)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Attendance>> Handle(
            FindAllAttendancesQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Enrollments.ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
