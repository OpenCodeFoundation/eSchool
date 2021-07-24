using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Shared;

namespace OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppSettingsController
        : ControllerBase
    {
        private readonly FrontendSettings _settings;

        public AppSettingsController(IOptions<FrontendSettings> options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _settings = options.Value;
        }

        // GET
        public FrontendSettings Index()
        {
            return _settings;
        }
    }
}
