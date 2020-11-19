using System.Threading.Tasks;
using HotChocolate;
using OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Commands;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;
using OpenCodeFoundation.ESchool.Services.Enrolling.Infrastructure;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.graphql
{
    public class Mutation
    {
        public async Task<Enrollment> AddEnrollmentAsync(
            EnrollmentApplicationCommand input,
            [Service] EnrollingContext context)
        {
            var enrollment = new Enrollment(
                input.Name,
                input.Email,
                input.Mobile);

            context.Enrollments.Add(enrollment);
            await context.SaveChangesAsync();
            return enrollment;
        }
    }
}
