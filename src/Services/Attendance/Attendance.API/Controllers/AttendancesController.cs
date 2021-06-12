using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OpenCodeFoundation.ESchool.Services.Attending.API.Application.Commands;

namespace OpenCodeFoundation.ESchool.Services.Attending.API.Controllers
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
