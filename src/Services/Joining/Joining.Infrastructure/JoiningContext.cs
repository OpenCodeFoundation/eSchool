using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OpenCodeFoundation.ESchool.Services.Joining.Domain.AggregatesModel.JoinAggregate;

namespace OpenCodeFoundation.ESchool.Services.Joining.Infrastructure
{
    public class JoiningContext
        : DbContext
    {
        public JoiningContext(DbContextOptions<JoiningContext> options)
            : base(options)
        {
        }

        public DbSet<Join> Joins { get; set; }


    }

    public class JoiningContextFactory : IDesignTimeDbContextFactory<JoiningContext>
    {
        public JoiningContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<JoiningContext>()
                .UseSqlServer("Server=.;Initial Catalog=OpenCodeFoundation.JoiningDb;Integrated Security=true");

            return new JoiningContext(optionsBuilder.Options);
        }
    }
}
