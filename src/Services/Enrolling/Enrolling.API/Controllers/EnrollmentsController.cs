using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Commands;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnrollmentsController : ControllerBase
    {

        private readonly ILogger<EnrollmentsController> _logger;
        public readonly IMediator _mediator;

        public EnrollmentsController(
            ILogger<EnrollmentsController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EnrollmentApplicationCommand command)
        {
            _logger.LogTrace("Posting request");
            await _mediator.Send(command);
            return Ok();
        }
    }
}
