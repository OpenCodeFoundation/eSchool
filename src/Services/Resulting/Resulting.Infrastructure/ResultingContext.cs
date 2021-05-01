using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Resulting.Domain.AggregateModel.ResultingAggregate;

namespace Resulting.Infrastructure
{
    public class ResultingContext : DbContext
    {
        public ResultingContext(DbContextOptions<ResultingContext> options)
            : base(options)
        {
        }

        public DbSet<Results> Resulting { get; set; } = default!;
    }

    /// <summary>
    ///     Helper class for creating migration. To create new migration, run the
    ///     command from `Enrolling.Intrastructure` folder.
    ///
    ///     $ dotnet ef migrations add name_of_migration --startup-project ../Enrolling.API.
    /// </summary>
    public class ResultingContextFactory : IDesignTimeDbContextFactory<ResultingContext>
    {
        public ResultingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ResultingContext>()
                .UseSqlServer("Server=.;Initial Catalog=OpenCodeFoundation.ResultingDB;Integrated Security=true");

            return new ResultingContext(optionsBuilder.Options);
        }
    }
}
