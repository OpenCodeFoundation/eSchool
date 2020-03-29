using Microsoft.EntityFrameworkCore;
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
}
