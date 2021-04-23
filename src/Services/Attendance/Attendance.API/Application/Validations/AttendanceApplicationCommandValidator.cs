using FluentValidation;
using OpenCodeFoundation.ESchool.Services.Attending.API.Application.Commands;

namespace OpenCodeFoundation.ESchool.Services.Attending.API.Application.Validations
{
    public class AttendanceApplicationCommandValidator
        : AbstractValidator<AttendanceApplicationCommand>
    {
        public AttendanceApplicationCommandValidator()
        {
            RuleFor(application => application.Name).NotEmpty();
            RuleFor(application => application.Email).NotEmpty().EmailAddress();
            RuleFor(application => application.Mobile).NotEmpty();
        }
    }
}
