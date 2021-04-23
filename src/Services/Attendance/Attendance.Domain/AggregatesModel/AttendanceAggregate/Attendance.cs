using System;
using OpenCodeFoundation.ESchool.Services.Attendance.Domain.SeedWork;

namespace OpenCodeFoundation.ESchool.Services.Attendance.Domain.AggregatesModel.AttendanceAggregate
{
    public class Attendance
        : Entity, IAggregateRoot
    {
        public Attendance(
            string name,
            string emailAddress,
            string mobileNumber)
        {
            Name = !string.IsNullOrWhiteSpace(name) ? name
                : throw new ArgumentNullException(nameof(name));
            EmailAddress = !string.IsNullOrWhiteSpace(emailAddress) ? emailAddress
                : throw new ArgumentNullException(nameof(emailAddress));
            MobileNumber = !string.IsNullOrWhiteSpace(mobileNumber) ? mobileNumber
                : throw new ArgumentNullException(nameof(mobileNumber));
        }

        public string Name { get; private set; }

        public string EmailAddress { get; private set; }

        public string MobileNumber { get; private set; }
    }
}
