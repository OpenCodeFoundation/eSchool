using System;
using System.Threading;
using System.Threading.Tasks;
using OpenCodeFoundation.ESchool.Services.Attendance.Domain.SeedWork;

namespace OpenCodeFoundation.ESchool.Services.Attendance.Domain.AggregatesModel.AttendanceAggregate
{
    public interface IAttendanceRepository
        : IRepository<Attendance>
    {
        Attendance Add(Attendance attendance);

        Attendance Update(Attendance attendance);

        Task<Attendance> FindByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);
    }
}
