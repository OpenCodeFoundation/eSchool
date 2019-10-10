using FluentValidation;
using OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Commands;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Validations
{
    public class EnrollmentApplicationCommandValidator
        : AbstractValidator<EnrollmentApplicationCommand>
    {
        public EnrollmentApplicationCommandValidator()
        {
            RuleFor(application => application.Name).NotEmpty();
            RuleFor(application => application.Email).EmailAddress();
            RuleFor(application => application.Mobile).NotEmpty();
        }
    }
}
