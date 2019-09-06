using Microsoft.EntityFrameworkCore;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.Infrastructure
{
    public class EnrollingContext
        : DbContext
    {
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}
