using MediatR;

namespace CourseRegistration.API.Application.Commands
{
    public class CourseRegistrationCommand : IRequest<bool>
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
    }
}
