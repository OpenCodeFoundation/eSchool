using Microsoft.EntityFrameworkCore;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.Infrastructure
{
    public class EnrollingContext
        : DbContext
    {
        public EnrollingContext(DbContextOptions<EnrollingContext> options)
            : base(options)
        {
        }

        public DbSet<Enrollment> Enrollments { get; set; }
    }
}
