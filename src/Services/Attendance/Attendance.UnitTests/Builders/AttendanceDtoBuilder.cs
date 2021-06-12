namespace Attending.UnitTests.Builders
{
    public class AttendanceDtoBuilder
    {
        private string? _studentId;
        private string? _courseId;

        public AttendanceDtoBuilder WithDefaults()
        {
            _studentId = "2d16af83-15b7-4e28-be1d-25ed1630a365";
            _courseId = "8a5e3a17-115f-4df6-b6e4-000441a6b672";
            return this;
        }

        public AttendanceDto Build()
        {
            return new AttendanceDto
            {
                StudentId = _studentId,
                CourseId = _courseId
            };
        }
    }
}
