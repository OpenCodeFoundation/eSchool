using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace CourseRegistration.API.Application.Queries
{
    public class FindAllCourseRegistrationQuery
        :IRequest<IEnumerable<CourseRegistration.Domain.AggregatesModel.CourseRegistrationAggregate.CourseRegistration>>
    {
    }
}
