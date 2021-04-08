using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseRegistration.API.Application.Commands;
using CourseRegistration.API.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseRegistrationController : Controller
    {
        private readonly IMediator _mediator;

        public CourseRegistrationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseRegistration.Domain.AggregatesModel.CourseRegistrationAggregate.CourseRegistration>> Get()
            => await _mediator.Send(new FindAllCourseRegistrationQuery());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CourseRegistrationCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
