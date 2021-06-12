using Microsoft.AspNetCore.Mvc;

namespace CertificateProcessing.API.Controllers
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
