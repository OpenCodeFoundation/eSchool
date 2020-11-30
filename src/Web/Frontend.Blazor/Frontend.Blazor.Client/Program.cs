using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using MudBlazor;
using MudBlazor.Services;
using OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Shared;

namespace OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            var settings = await LoadFrontendSettings(builder);
            builder.Services.AddSingleton(settings);

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddMudBlazorDialog();
            builder.Services.AddMudBlazorSnackbar();
            builder.Services.AddMudBlazorResizeListener();

            await builder.Build().RunAsync();
        }

        private static async Task<FrontendSettings> LoadFrontendSettings(WebAssemblyHostBuilder builder)
        {
            using var http = new HttpClient()
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            };

            var settings = await http
                .GetFromJsonAsync<FrontendSettings>("appsettings");

            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            return settings;
        }
    }
}
