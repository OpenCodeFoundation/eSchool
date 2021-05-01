using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resulting.API.Application.Commands;
using Resulting.API.Application.Queries;
using Resulting.Domain.AggregateModel.ResultingAggregate;

namespace Resulting.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResultingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResultingController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IEnumerable<Results>> Get(CancellationToken cancellationToken)
            => await _mediator.Send(new FindAllResultQuery(), cancellationToken)
                .ConfigureAwait(false);

        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] ResultingApplicationCommand command,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken)
                .ConfigureAwait(false);
            return Ok();
        }
    }
}
