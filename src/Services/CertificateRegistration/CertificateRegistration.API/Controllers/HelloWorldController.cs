using Microsoft.AspNetCore.Mvc;

namespace CertificateRegistration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public static string Ping()
        {
            return "Pong";
        }
    }
}
