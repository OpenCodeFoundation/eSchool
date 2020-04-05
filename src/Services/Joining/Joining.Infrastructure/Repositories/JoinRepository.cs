using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenCodeFoundation.ESchool.Services.Joining.Domain.AggregatesModel.JoinAggregate;

namespace OpenCodeFoundation.ESchool.Services.Joining.Infrastructure.Repositories
{
    public class JoinRepository
      : IJoinRepository
    {
        private readonly JoiningContext _context;

        public JoinRepository(JoiningContext context)
        {
            _context = context;
        }

        public Join Add(Join join)
        {
            return _context.Joins
                .Add(join)
                .Entity;
        }

        public async Task<Join> FindByIdAsync(Guid id)
        {
            return await _context.Joins
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync();
        }

        public Join Update(Join join)
        {
            return _context.Joins
                .Update(join)
                .Entity;
        }
    }
}
