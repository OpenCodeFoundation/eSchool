using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OpenCodeFoundation.ESchool.Services.Enrolling.API.Application.Commands;
using OpenCodeFoundation.ESchool.Services.Enrolling.Domain.AggregatesModel.EnrollmentAggregate;
using OpenCodeFoundation.ESchool.Services.Enrolling.Infrastructure;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly ILogger<EnrollmentsController> _logger;
        private readonly IMediator _mediator;
        private readonly EnrollingContext _context;

        public EnrollmentsController(
            ILogger<EnrollmentsController> logger,
            IMediator mediator,
            EnrollingContext context)
        {
            _logger = logger;
            _mediator = mediator;
            _context = context;
        }

        [HttpGet]
        public async Task<List<Enrollment>> Get()
        {
            return await _context.Enrollments.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EnrollmentApplicationCommand command)
        {
            _logger.LogInformation("Posting request");
            await _mediator.Send(command);
            return Ok();
        }
    }
}
