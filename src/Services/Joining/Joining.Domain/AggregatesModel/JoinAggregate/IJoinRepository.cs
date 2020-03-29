using System;
using System.Threading.Tasks;
using OpenCodeFoundation.ESchool.Services.Joining.Domain.SeedWork;

namespace OpenCodeFoundation.ESchool.Services.Joining.Domain.AggregatesModel.JoinAggregate
{
    public interface IJoinRepository
        : IRepository<Join>
    {
        Join Add(Join join);

        Join Update(Join join);

        Task<Join> FindByIdAsync(Guid id);
    }
}
