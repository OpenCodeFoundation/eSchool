using MediatR;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Queries
{
    public class GetEnrollmentByIdQuery
        : IRequest<Enrollment?>
    {
        public GetEnrollmentByIdQuery(EnrollmentId id)
        {
            Id = id;
        }

        public EnrollmentId Id { get;  }
    }
}
