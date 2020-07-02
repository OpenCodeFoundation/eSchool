using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OpenCodeFoundation.ESchool.Services.Attendance.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttendanceCommandController : ControllerBase
    {
        private readonly ILogger<AttendanceCommandController> _logger;
        private readonly IMediator _mediator;

        public AttendanceCommandController(
            ILogger<AttendanceCommandController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


    }
}
