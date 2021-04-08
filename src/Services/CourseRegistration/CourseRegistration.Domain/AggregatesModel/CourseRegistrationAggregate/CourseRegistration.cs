using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistration.Domain.SeedWork;

namespace CourseRegistration.Domain.AggregatesModel.CourseRegistrationAggregate
{
    public class CourseRegistration
        : Entity, IAggregateRoot
    {
        public CourseRegistration(string courseCode, string courseName, string description)
        {
            CourseCode = !string.IsNullOrWhiteSpace(courseCode) ? courseCode
                : throw new ArgumentNullException(nameof(courseCode));

            CourseName = !string.IsNullOrWhiteSpace(courseName) ? courseName
                : throw new ArgumentNullException(nameof(courseName));

            Description = !string.IsNullOrEmpty(description) ? description
                : "";
        }

        public string CourseCode { get; private set; }
        public string CourseName { get; private set; }
        public string Description { get; private set; }
    }
}
