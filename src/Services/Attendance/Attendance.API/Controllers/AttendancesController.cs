using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OpenCodeFoundation.ESchool.Services.Attendance.API.Application.Commands;
using OpenCodeFoundation.ESchool.Services.Attendance.API.Application.Queries;
using OpenCodeFoundation.ESchool.Services.Attendance.Domain.AggregatesModel.EnrollmentAggregate;

namespace OpenCodeFoundation.ESchool.Services.Attendance.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttendancesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AttendancesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IEnumerable<Enrollment>> Get(CancellationToken cancellationToken)
            => await _mediator.Send(new FindAllEnrollmentsQuery(), cancellationToken)
                .ConfigureAwait(false);

        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] AttendanceApplicationCommand command,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken)
                .ConfigureAwait(false);
            return Ok();
        }
    }
}
