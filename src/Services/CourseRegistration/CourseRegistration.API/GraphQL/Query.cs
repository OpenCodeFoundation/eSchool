using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseRegistration.Infrastructure;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CourseRegistration.API.GraphQL
{
    public class Query
    {
        public async Task<List<CourseRegistration.Domain.AggregatesModel.CourseRegistrationAggregate.CourseRegistration>> GetCourseRegistrationAsync(
        [Service] CourseRegistrationContext context,
        [Service] ILogger<Query> logger)
        {
            var courseRegistration = await context.CourseRegistrations
                .ToListAsync();

            logger.LogInformation(
                "Returning course registration {CourseRegistrationCount} with payload {@CourseRegistration}",
                courseRegistration.Count,
                courseRegistration);

            return courseRegistration;
        }
    }
}
