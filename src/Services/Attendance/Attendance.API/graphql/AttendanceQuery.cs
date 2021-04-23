using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OpenCodeFoundation.ESchool.Services.Attending.Infrastructure;

namespace OpenCodeFoundation.ESchool.Services.Attending.API.Graphql
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Performance",
        "CA1822:Mark members as static",
        Justification = "GraphQL Query used by Hot Chocolate")]
    [ExtendObjectType(Name = "Query")]
    public class AttendanceQuery
    {
        public async Task<List<Domain.AggregatesModel.AttendanceAggregate.Attendance>> GetEnrollmentsAsync(
            [Service] AttendanceContext context,
            [Service] ILogger<AttendanceQuery> logger,
            CancellationToken cancellationToken)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var attendances = await context.Attendances
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            logger.LogInformation(
                "Returning attendances {AttendanceCount} with payload {@Attendance}",
                attendances.Count,
                attendances);

            return attendances;
        }
    }
}
