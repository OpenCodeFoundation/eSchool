using Microsoft.AspNetCore.Mvc;

namespace ResultProcessing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Ping()
        {
            return Ok("This is new Web API");
        }
    }
}
