using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;
using OpenCodeFoundation.ESchool.Services.Enrolling.Infrastructure;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Graphql
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Performance",
        "CA1822:Mark members as static",
        Justification = "GraphQL Query used by Hot Chocolate")]
    [ExtendObjectType(Name = "Query")]
    public class EnrollingQuery
    {
        public async Task<List<Enrollment>> GetEnrollmentsAsync(
            [Service] EnrollingContext context,
            [Service] ILogger<EnrollingQuery> logger,
            CancellationToken cancellationToken)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var enrollments = await context.Enrollments
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            logger.LogInformation(
                "Returning enrollments {EnrollmentCount} with payload {@Enrollment}",
                enrollments.Count,
                enrollments);

            return enrollments;
        }
    }
}
