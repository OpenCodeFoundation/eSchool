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
            _settings = options is null
                ? throw new ArgumentNullException(nameof(options))
                : options.Value;
        }

        // GET
        public FrontendSettings Index()
        {
            return _settings;
        }
    }
}
