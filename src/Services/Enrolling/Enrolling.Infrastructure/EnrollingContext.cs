using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;
using OpenCodeFoundation.ESchool.Services.Enrolling.Infrastructure.Configuration.ValueConverters;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.Infrastructure
{
    public class EnrollingContext
        : DbContext
    {
        public EnrollingContext(DbContextOptions<EnrollingContext> options)
            : base(options)
        {
        }

        public DbSet<Enrollment> Enrollments { get; set; } = default!;

        protected override void ConfigureConventions(
            ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.AddStronglyTypedIds();
        }
    }

    /// <summary>
    ///     Helper class for creating migration. To create new migration, run the
    ///     command from `Enrolling.Infrastructure` folder.
    ///
    ///     $ dotnet ef migrations add name_of_migration --startup-project ../Enrolling.API.
    /// </summary>
    public class EnrollingContextFactory : IDesignTimeDbContextFactory<EnrollingContext>
    {
        public EnrollingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EnrollingContext>()
                .UseSqlServer("Server=.;Initial Catalog=OpenCodeFoundation.EnrollingDb;Integrated Security=true");

            return new EnrollingContext(optionsBuilder.Options);
        }
    }
}
