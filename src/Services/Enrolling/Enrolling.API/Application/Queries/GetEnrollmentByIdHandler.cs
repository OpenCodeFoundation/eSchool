using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Queries
{
    public class GetEnrollmentByIdHandler
        : IRequestHandler<GetEnrollmentByIdQuery, Enrollment>
    {
        public Task<Enrollment> Handle(
            GetEnrollmentByIdQuery query,
            CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
