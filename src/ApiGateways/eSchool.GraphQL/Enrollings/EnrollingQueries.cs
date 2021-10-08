using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using OpenCodeFoundation.ESchool.ApiGateways.ESchool.GraphQL.Enrolling;

namespace OpenCodeFoundation.ESchool.ApiGateways.ESchool.GraphQL.Enrollings
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class EnrollingQueries
    {
        public async Task<ICollection<Enrollment>> GetEnrollmentsAsync(
            [Service] IEnrollingServiceClient client,
            CancellationToken cancellationToken = default)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            return await client.GetAllAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<Enrollment> GetEnrollmentAsync(
            Guid enrollmentId,
            [Service] IEnrollingServiceClient client,
            CancellationToken cancellationToken = default)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            return await client.GetByIdAsync(enrollmentId, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
