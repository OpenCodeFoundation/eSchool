using System;
using OpenCodeFoundation.ESchool.Services.Attending.Domain.SeedWork;

namespace OpenCodeFoundation.ESchool.Services.Attending.Domain.AggregatesModel.AttendanceAggregate
{
    public class Attendance
        : Entity, IAggregateRoot
    {
        public Attendance(
            string studentId,
            string courseId)
        {
            StudentId = !string.IsNullOrWhiteSpace(studentId) ? studentId
                : throw new ArgumentNullException(nameof(studentId));
            CourseId = !string.IsNullOrWhiteSpace(courseId) ? courseId
                : throw new ArgumentNullException(nameof(courseId));
        }

        public string StudentId { get; private set; }

        public string CourseId { get; private set; }
    }
}
