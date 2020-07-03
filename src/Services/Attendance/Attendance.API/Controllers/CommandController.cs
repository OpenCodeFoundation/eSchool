using Attendance.SharedKernel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OpenCodeFoundation.ESchool.Services.Attendance.API.Controllers
{
    [ApiController]
    [Route("Attendance/[controller]")]
    public class CommandController : ControllerBase
    {
        private readonly ILogger<CommandController> _logger;
        private readonly CommandHandler _commandHandler;

        public CommandController(
            ILogger<CommandController> logger,
            CommandHandler commandHandler)
        {
            _logger = logger;
            _commandHandler = commandHandler;
        }


    }
}
