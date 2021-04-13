using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseRegistration.API.Application.Commands;
using CourseRegistration.Infrastructure;
using HotChocolate;

namespace CourseRegistration.API.GraphQL
{
    public class Mutation
    {
      public async Task<CourseRegistration.Domain.AggregatesModel.CourseRegistrationAggregate.CourseRegistration> AddCourseRegistationAsync(
      CourseRegistrationCommand input,
      [Service] CourseRegistrationContext context)
        {
            var courseRegistration = new CourseRegistration.Domain.AggregatesModel.CourseRegistrationAggregate.CourseRegistration(
                input.CourseCode,
                input.CourseName,
                input.Description);

            await context.CourseRegistrations.AddAsync(courseRegistration);
            await context.SaveChangesAsync();
            return courseRegistration;
        }
    }
}
