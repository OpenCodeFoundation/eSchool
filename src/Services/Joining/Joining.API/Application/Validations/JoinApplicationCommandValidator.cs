using FluentValidation;
using OpenCodeFoundation.ESchool.Services.Joining.API.Application.Commands;

namespace OpenCodeFoundation.ESchool.Services.Joining.API.Application.Validations
{
    public class JoinApplicationCommandValidator
     : AbstractValidator<JoinApplicationCommand>
    {
        public JoinApplicationCommandValidator()
        {
            RuleFor(application => application.Name).NotEmpty();
            RuleFor(application => application.Email).EmailAddress();
            RuleFor(application => application.Mobile).NotEmpty();
        }
    }
}
