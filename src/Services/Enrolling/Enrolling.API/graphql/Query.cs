using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;
using OpenCodeFoundation.ESchool.Services.Enrolling.Infrastructure;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Graphql
{
    public class Query
    {
        public async Task<List<Enrollment>> GetEnrollmentsAsync(
            [Service] EnrollingContext context,
            [Service] ILogger<Query> logger)
        {
            var enrollments = await context.Enrollments
                .ToListAsync();

            logger.LogInformation(
                "Returning enrollments {EnrollmentCount} with payload {@Enrollment}",
                enrollments.Count,
                enrollments);

            return enrollments;
        }
    }
}
