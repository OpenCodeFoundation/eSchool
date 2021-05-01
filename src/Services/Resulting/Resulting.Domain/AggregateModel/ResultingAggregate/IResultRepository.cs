using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Resulting.Domain.SeedWork;

namespace Resulting.Domain.AggregateModel.ResultingAggregate
{
    public interface IResultRepository : IRepository<Results>
    {
        Results Add(Results enrollment);

        Results Update(Results enrollment);

        Task<Results> FindByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);
    }
}
