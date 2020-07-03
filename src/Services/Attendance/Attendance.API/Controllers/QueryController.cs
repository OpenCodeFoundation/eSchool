using Attendance.SharedKernel;
using Attendance.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OpenCodeFoundation.ESchool.Services.Attendance.API.Controllers
{
    [ApiController]
    [Route("Attendance/[controller]")]
    public class QueryController : ControllerBase
    {
        private readonly ILogger<QueryController> _logger;
        private readonly QueryHandler _queryHandler;

        public QueryController(
            ILogger<QueryController> logger,
            QueryHandler queryHandler)
        {
            _logger = logger;
            _queryHandler = queryHandler;
        }


    }
}
