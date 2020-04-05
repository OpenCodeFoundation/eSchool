using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OpenCodeFoundation.ESchool.Services.Joining.API.Application.Commands;
using OpenCodeFoundation.ESchool.Services.Joining.Domain.AggregatesModel.JoinAggregate;
using OpenCodeFoundation.ESchool.Services.Joining.Infrastructure;

namespace OpenCodeFoundation.ESchool.Services.Joining.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("[controller]")]
    public class JoinController : ControllerBase
    {
        private readonly ILogger<JoinController> _logger;
        private readonly IMediator _mediator;
        private readonly JoiningContext _context;

        public JoinController(
            ILogger<JoinController> logger,
            IMediator mediator,
            JoiningContext context)
        {
            _logger = logger;
            _mediator = mediator;
            _context = context;
        }

        [HttpGet]
        public async Task<List<Join>> Get()
        {
            _logger.LogInformation("Getting all Joins");
            var joins = await _context.Joins.ToListAsync();

            _logger.LogInformation("Total {NumberOfJoin} joins retrived", joins.Count);
            return joins;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JoinApplicationCommand command)
        {
            _logger.LogInformation(
                "Sending command: {CommandName} - ({@Command})",
                command.GetType().Name,
                command);

            await _mediator.Send(command);
            return Ok();
        }
    }
}
