using Microsoft.AspNetCore.Mvc;

namespace Attendance.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Ping()
        {
            return Ok("Pong");
        }
    }
}
