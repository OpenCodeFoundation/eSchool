using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OpenCodeFoundation.eSchool.Identity.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly ILogger<IdentityController> logger;

        public IdentityController(ILogger<IdentityController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public string Ping()
        {
            logger.LogInformation($"Service is Up!");
            return $"Service is Up!";
        }
    }
}
