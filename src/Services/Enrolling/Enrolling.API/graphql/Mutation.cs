using System;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Commands;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;
using OpenCodeFoundation.ESchool.Services.Enrolling.Infrastructure;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Graphql
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Performance",
        "CA1822:Mark members as static",
        Justification = "GraphQL mutation used by Hot Chocolate")]
    public class Mutation
    {
        public async Task<Enrollment> AddEnrollmentAsync(
            EnrollmentApplicationCommand input,
            [Service] EnrollingContext context,
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

            var enrollment = Enrollment.CreateNew(
                input.Name,
                input.Email,
                input.Mobile);

            await context.Enrollments.AddAsync(enrollment, cancellationToken)
                .ConfigureAwait(false);
            await context.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
            return enrollment;
        }
    }
}
