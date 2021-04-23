using System;
using Enrolling.UnitTests.Builders;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;
using Xunit;

namespace Enrolling.UnitTests.Domain
{
    public class EnrollmentAggregateTests
    {
        [Fact]
        public void NewApplicationShouldSuccessWithValidInput()
        {
            var dto = new AttendanceDtoBuilder()
                .WithDefaults()
                .Build();

            var enrollment = new Enrollment(dto.Name!, dto.Email!, dto.Mobile!);

            Assert.NotNull(enrollment);
            Assert.Equal(dto.Name, enrollment.Name);
            Assert.Equal(dto.Email, enrollment.EmailAddress);
            Assert.Equal(dto.Mobile, enrollment.MobileNumber);
        }

        [Fact]
        public void ShouldThrowExceptionIfNameIsEmpty()
        {
            var dto = new AttendanceDtoBuilder()
                .WithDefaults()
                .WithEmptyName()
                .Build();

            Assert.Throws<ArgumentNullException>(() => new Enrollment(dto.Name!, dto.Email!, dto.Mobile!));
        }

        [Fact]
        public void ShouldThrowExceptionEmtpyEmail()
        {
            var dto = new AttendanceDtoBuilder()
                .WithDefaults()
                .WithEmail(string.Empty)
                .Build();

            Assert.Throws<ArgumentNullException>(() => new Enrollment(dto.Name!, dto.Email!, dto.Mobile!));
        }

        [Fact]
        public void ShouldThrowExceptionEmptyMobile()
        {
            var dto = new AttendanceDtoBuilder()
                .WithDefaults()
                .WithMobile(string.Empty)
                .Build();

            Assert.Throws<ArgumentNullException>(() => new Enrollment(dto.Name!, dto.Email!, dto.Mobile!));
        }
    }
}
