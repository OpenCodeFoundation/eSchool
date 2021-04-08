using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CourseRegistration.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistration.API.Application.Queries
{
    public class FindAllCourseRegistrationHandler
        : IRequestHandler<FindAllCourseRegistrationQuery, IEnumerable<CourseRegistration.Domain.AggregatesModel.CourseRegistrationAggregate.CourseRegistration>>
    {
        private readonly CourseRegistrationContext _context;


        public FindAllCourseRegistrationHandler(CourseRegistrationContext context)
        {
            _context = context ?? throw new System.ArgumentNullException(nameof(context));
        }


        public async Task<IEnumerable<Domain.AggregatesModel.CourseRegistrationAggregate.CourseRegistration>> Handle(FindAllCourseRegistrationQuery request, CancellationToken cancellationToken)
        {
            return await _context.CourseRegistrations.ToListAsync();
        }
    }
}
