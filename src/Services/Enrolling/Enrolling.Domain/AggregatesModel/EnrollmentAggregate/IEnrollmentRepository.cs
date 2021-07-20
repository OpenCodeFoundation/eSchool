using System.Threading;
using System.Threading.Tasks;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.SeedWork;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate
{
    public interface IEnrollmentRepository
        : IRepository<Enrollment>
    {
        Enrollment Add(Enrollment enrollment);

        Enrollment Update(Enrollment enrollment);

        Task<Enrollment?> FindByIdAsync(
            EnrollmentId id,
            CancellationToken cancellationToken = default);
    }
}
