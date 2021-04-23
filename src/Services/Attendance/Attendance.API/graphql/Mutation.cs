using System;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using OpenCodeFoundation.ESchool.Services.Attendance.API.Application.Commands;
using OpenCodeFoundation.ESchool.Services.Attendance.Domain.AggregatesModel.EnrollmentAggregate;
using OpenCodeFoundation.ESchool.Services.Attendance.Infrastructure;

namespace OpenCodeFoundation.ESchool.Services.Attendance.API.Graphql
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Performance",
        "CA1822:Mark members as static",
        Justification = "GraphQL mutation used by Hot Chocolate")]
    public class Mutation
    {
        public async Task<Attendance> AddAttendanceAsync(
            AttendanceApplicationCommand input,
            [Service] AttendanceContext context,
            CancellationToken cancellationToken)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var attendance = new Attendance(
                input.Name,
                input.Email,
                input.Mobile);

            await context.Attendances.AddAsync(attendance, cancellationToken)
                .ConfigureAwait(false);
            await context.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
            return attendance;
        }
    }
}
