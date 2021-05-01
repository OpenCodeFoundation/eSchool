using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Resulting.API.Application.Commands;

namespace Resulting.API.Application.Validations
{
    public class ResultingApplicationCommandValidator
        : AbstractValidator<ResultingApplicationCommand>
    {
        public ResultingApplicationCommandValidator()
        {
            RuleFor(application => application.Result).NotEmpty();
            RuleFor(application => application.GradeScale).NotEmpty().EmailAddress();
            RuleFor(application => application.Grade).NotEmpty();
        }
    }
}
