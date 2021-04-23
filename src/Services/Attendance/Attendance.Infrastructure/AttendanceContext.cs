using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OpenCodeFoundation.ESchool.Services.Attendance.Infrastructure
{
    public class AttendanceContext
        : DbContext
    {
        public AttendanceContext(DbContextOptions<AttendanceContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.AggregatesModel.AttendanceAggregate.Attendance> Attendances { get; set; } = default!;
    }

    /// <summary>
    ///     Helper class for creating migration. To create new migration, run the
    ///     command from `Enrolling.Intrastructure` folder.
    ///
    ///     $ dotnet ef migrations add name_of_migration --startup-project ../Enrolling.API.
    /// </summary>
    public class AttendanceContextFactory : IDesignTimeDbContextFactory<AttendanceContext>
    {
        public AttendanceContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AttendanceContext>()
                .UseSqlServer("Server=.;Initial Catalog=OpenCodeFoundation.AttendanceDb;Integrated Security=true");

            return new AttendanceContext(optionsBuilder.Options);
        }
    }
}
