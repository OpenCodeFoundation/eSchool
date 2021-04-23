using Attending.UnitTests.Builders;
using OpenCodeFoundation.ESchool.Services.Attending.Domain.AggregatesModel.AttendanceAggregate;
using Xunit;

namespace Attending.UnitTests.Domain
{
    public class AttendanceAggregateTests
    {
        [Fact]
        public void NewApplicationShouldSuccessWithValidInput()
        {
            var dto = new AttendanceDtoBuilder()
                .WithDefaults()
                .Build();

            var attendance = new Attendance(dto.StudentId!, dto.CourseId!);

            Assert.NotNull(attendance);
            Assert.Equal(dto.StudentId, attendance.StudentId);
            Assert.Equal(dto.CourseId, attendance.CourseId);
        }

    }
}
