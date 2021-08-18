using System;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using OpenCodeFoundation.ESchool.ApiGateways.ESchool.GraphQL.Enrolling;

namespace OpenCodeFoundation.ESchool.ApiGateways.ESchool.GraphQL.Enrollings
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class EnrollmentMutations
    {
        public async Task<Enrollment> CreateEnrollmentAsync(
            EnrollmentApplicationCommand enrollment,
            [Service] IEnrollingServiceClient client,
            CancellationToken cancellationToken = default)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            return await client.CreateAsync(enrollment, cancellationToken).ConfigureAwait(false);
        }
    }
}
