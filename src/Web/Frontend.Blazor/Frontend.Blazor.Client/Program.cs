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
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            var settings = await LoadFrontendSettings(builder);
            builder.Services.AddSingleton(settings);

            builder.Services.AddHttpClient("EschoolClient", client =>
            {
                client.BaseAddress = new Uri(settings.GraphQlGatewayEndpoint);
            });
            builder.Services.AddEschoolClient();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddMudServices();
            builder.Services.AddMudBlazorDialog();
            builder.Services.AddMudBlazorSnackbar(config =>
            {
                config.PositionClass = Defaults.Classes.Position.BottomRight;
                config.SnackbarVariant = Variant.Filled;
            });
            builder.Services.AddMudBlazorResizeListener();

            await builder.Build().RunAsync().ConfigureAwait(false);
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
