using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.Infrastructure.Repositories
{
    public class EnrollmentRepository
        : IEnrollmentRepository
    {
        private readonly EnrollingContext _context;

        public EnrollmentRepository(EnrollingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Enrollment Add(Enrollment enrollment)
        {
            return _context.Enrollments
                .Add(enrollment)
                .Entity;
        }

        public async Task<Enrollment> FindByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _context.Enrollments
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public Enrollment Update(Enrollment enrollment)
        {
            return _context.Enrollments
                .Update(enrollment)
                .Entity;
        }
    }
}
