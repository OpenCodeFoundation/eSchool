using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Commands;
using OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Queries;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EnrollmentsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IEnumerable<Enrollment>> Get(CancellationToken cancellationToken)
            => await _mediator.Send(new FindAllEnrollmentsQuery(), cancellationToken)
                .ConfigureAwait(false);

        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] EnrollmentApplicationCommand command,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken)
                .ConfigureAwait(false);
            return Ok();
        }
    }
}
