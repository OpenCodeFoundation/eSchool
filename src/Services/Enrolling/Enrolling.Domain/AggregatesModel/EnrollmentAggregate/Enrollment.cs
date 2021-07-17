using System;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.SeedWork;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate
{
    public class Enrollment
        : Entity, IAggregateRoot
    {
        private Enrollment(
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

        public static Enrollment CreateNew(
            string name,
            string emailAddress,
            string mobileNumber)
        {
            return new(name, emailAddress, mobileNumber);
        }
    }
}
