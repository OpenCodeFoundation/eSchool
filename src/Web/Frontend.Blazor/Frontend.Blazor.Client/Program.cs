using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Shared;

namespace OpenCodeFoundation.ESchool.Web.Frontend.Blazor.Client
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            var settings = await LoadFrontendSettings(builder)
                .ConfigureAwait(false);
            builder.Services.AddSingleton(settings);

            builder.Services.AddScoped(_ =>
                new HttpClient
                {
                    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
                });

            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });

            await builder.Build().RunAsync().ConfigureAwait(false);
        }

        private static async Task<FrontendSettings> LoadFrontendSettings(WebAssemblyHostBuilder builder)
        {
            using var http = new HttpClient()
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
            };

            var settings = await http
                .GetFromJsonAsync<FrontendSettings>("appsettings")
                .ConfigureAwait(false);

            return settings ?? throw new InvalidOperationException(
                "Failed to load settings");
        }
    }
}
