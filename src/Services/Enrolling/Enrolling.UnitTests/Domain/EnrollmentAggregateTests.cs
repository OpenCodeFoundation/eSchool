using System;
using System.Threading.Tasks;
using Enrolling.UnitTests.Builders;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;
using VerifyXunit;
using Xunit;

namespace Enrolling.UnitTests.Domain
{
    [UsesVerify]
    public class EnrollmentAggregateTests
    {
        [Fact]
        public Task NewApplicationShouldSuccessWithValidInput()
        {
            var dto = new EnrollmentDtoBuilder()
                .WithDefaults()
                .Build();

            var enrollment = Enrollment.CreateNew(dto.Name!, dto.Email!, dto.Mobile!);
            return Verifier.Verify(enrollment);
        }

        [Fact]
        public void ShouldThrowExceptionIfNameIsEmpty()
        {
            var dto = new EnrollmentDtoBuilder()
                .WithDefaults()
                .WithEmptyName()
                .Build();

            Assert.Throws<ArgumentNullException>(() => Enrollment.CreateNew(dto.Name!, dto.Email!, dto.Mobile!));
        }

        [Fact]
        public void ShouldThrowExceptionEmptyEmail()
        {
            var dto = new EnrollmentDtoBuilder()
                .WithDefaults()
                .WithEmail(string.Empty)
                .Build();

            Assert.Throws<ArgumentNullException>(() => Enrollment.CreateNew(dto.Name!, dto.Email!, dto.Mobile!));
        }

        [Fact]
        public void ShouldThrowExceptionEmptyMobile()
        {
            var dto = new EnrollmentDtoBuilder()
                .WithDefaults()
                .WithMobile(string.Empty)
                .Build();

            Assert.Throws<ArgumentNullException>(() => Enrollment.CreateNew(dto.Name!, dto.Email!, dto.Mobile!));
        }
    }
}
