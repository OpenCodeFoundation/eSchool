using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Resulting.Domain.AggregateModel.ResultingAggregate;
using Resulting.Infrastructure;

namespace Resulting.API.Application.Queries
{
    public class FindAllResultHandler : IRequestHandler<FindAllResultQuery, IEnumerable<Results>>
    {
        private readonly ResultingContext _context;

        public FindAllResultHandler(ResultingContext context)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Results>> Handle(
            FindAllResultQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Resulting.ToListAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
