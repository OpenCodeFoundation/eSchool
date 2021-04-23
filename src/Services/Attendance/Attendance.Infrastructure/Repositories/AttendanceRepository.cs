using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenCodeFoundation.ESchool.Services.Attendance.Domain.AggregatesModel.AttendanceAggregate;

namespace OpenCodeFoundation.ESchool.Services.Attendance.Infrastructure.Repositories
{
    public class AttendanceRepository
        : IAttendanceRepository
    {
        private readonly AttendanceContext _context;

        public AttendanceRepository(AttendanceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Attendance Add(Attendance attendance)
        {
            return _context.Attendances
                .Add(attendance)
                .Entity;
        }

        public async Task<Attendance> FindByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _context.Attendances
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public Attendance Update(Attendance attendance)
        {
            return _context.Attendances
                .Update(attendance)
                .Entity;
        }
    }
}
