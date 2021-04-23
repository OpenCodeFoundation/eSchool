namespace Attendance.UnitTests.Builders
{
    public class AttendanceDtoBuilder
    {
        private string? _name;
        private string? _email;
        private string? _mobile;

        public AttendanceDtoBuilder WithDefaults()
        {
            _name = "John Doe";
            _email = "john@example.com";
            _mobile = "01771999999";
            return this;
        }

        public AttendanceDtoBuilder WithEmptyName()
        {
            _name = string.Empty;
            return this;
        }

        public AttendanceDtoBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public AttendanceDtoBuilder WithMobile(string mobile)
        {
            _mobile = mobile;
            return this;
        }

        public AttendanceDto Build()
        {
            return new AttendanceDto
            {
                Name = _name,
                Email = _email,
                Mobile = _mobile,
            };
        }
    }
}
