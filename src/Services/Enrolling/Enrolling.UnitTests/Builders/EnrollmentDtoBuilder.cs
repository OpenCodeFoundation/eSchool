namespace Enrolling.UnitTests.Builders
{
    public class EnrollmentDtoBuilder
    {
        private string? _name;
        private string? _email;
        private string? _mobile;

        public EnrollmentDtoBuilder WithDefaults()
        {
            _name = "John Doe";
            _email = "john@example.com";
            _mobile = "01771999999";
            return this;
        }

        public EnrollmentDtoBuilder WithEmptyName()
        {
            _name = string.Empty;
            return this;
        }

        public EnrollmentDtoBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public EnrollmentDtoBuilder WithMobile(string mobile)
        {
            _mobile = mobile;
            return this;
        }

        public EnrollmentDto Build()
        {
            return new EnrollmentDto
            {
                Name = _name,
                Email = _email,
                Mobile = _mobile,
            };
        }
    }
}
