using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CourseRegistration.Infrastructure
{
    public class CourseRegistrationContext : DbContext
    {
        public CourseRegistrationContext(DbContextOptions<CourseRegistrationContext> options)
            : base(options)
        {

        }

        public DbSet<CourseRegistration.Domain.AggregatesModel.CourseRegistrationAggregate.CourseRegistration> CourseRegistrations { get; set; } = default!;
    }

    /// <summary>
    ///     Helper class for creating migration. To create new migration, run the
    ///     command from `CourseRegistration.Intrastructure` folder.
    ///
    ///     $ dotnet ef migrations add name_of_migration --startup-project ../CourseRegistration.API
    /// </summary>
    public class CourseRegistrationContextFactory : IDesignTimeDbContextFactory<CourseRegistrationContext>
    {
        public CourseRegistrationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CourseRegistrationContext>()
                .UseSqlServer("Server=.;Initial Catalog=OpenCodeFoundation.CourseRegistrationDb;Integrated Security=true");

            return new CourseRegistrationContext(optionsBuilder.Options);
        }
    }
}
