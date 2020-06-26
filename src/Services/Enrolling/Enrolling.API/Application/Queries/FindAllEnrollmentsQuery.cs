using System.Collections.Generic;
using MediatR;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Queries
{
    public class FindAllEnrollmentsQuery
        : IRequest<IEnumerable<Enrollment>>
    {
    }
}
