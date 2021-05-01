using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Resulting.API.Application.Commands
{
    public record ResultingApplicationCommand(
            string Result,
            string GradeScale,
            string Grade)
        : IRequest<bool>;
}
