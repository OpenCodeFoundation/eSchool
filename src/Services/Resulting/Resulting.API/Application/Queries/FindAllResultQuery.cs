using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Resulting.Domain.AggregateModel.ResultingAggregate;

namespace Resulting.API.Application.Queries
{
    public class FindAllResultQuery
        : IRequest<IEnumerable<Results>>
    {
    }
}
