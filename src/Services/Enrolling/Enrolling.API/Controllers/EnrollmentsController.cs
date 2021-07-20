using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        private readonly ISender _sender;

        public EnrollmentsController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        [HttpGet]
        public async Task<IEnumerable<Enrollment>> Get(CancellationToken cancellationToken)
            => await _sender.Send(new FindAllEnrollmentsQuery(), cancellationToken)
                .ConfigureAwait(false);

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Enrollment), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Enrollment?>> GetById(
            EnrollmentId id,
            CancellationToken cancellationToken)
        {
            var enrollment = await _sender
                .Send(new GetEnrollmentByIdQuery(id), cancellationToken)
                .ConfigureAwait(false);

            return enrollment is null
                ? NotFound()
                : Ok(enrollment);
        }

        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] EnrollmentApplicationCommand command,
            CancellationToken cancellationToken)
        {
            await _sender.Send(command, cancellationToken)
                .ConfigureAwait(false);
            return Ok();
        }
    }
}
