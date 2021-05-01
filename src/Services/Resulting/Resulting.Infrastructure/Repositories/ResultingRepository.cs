using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resulting.Domain.AggregateModel.ResultingAggregate;

namespace Resulting.Infrastructure.Repositories
{
    public class ResultingRepository : IResultRepository
    {
        private readonly ResultingContext _context;

        public ResultingRepository(ResultingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Results Add(Results results)
        {
            return _context.Resulting
                .Add(results)
                .Entity;
        }

        public async Task<Results> FindByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _context.Resulting
                .Where(e => e.Id == id)
                .SingleOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public Results Update(Results results)
        {
            return _context.Resulting
                .Update(results)
                .Entity;
        }
    }
}
