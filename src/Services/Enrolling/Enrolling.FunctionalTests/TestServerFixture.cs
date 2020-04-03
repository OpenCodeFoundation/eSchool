using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using OpenCodeFoundation.ESchool.Services.Enrolling.API;
using OpenCodeFoundation.ESchool.Services.Enrolling.Infrastructure;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.FunctionalTests
{
    public class TestServerFixture
        : IDisposable
    {
        public TestServerFixture()
        {
            WebHost = CreateHost();
            WebHost.MigrateDbContext<EnrollingContext>((_, __) => { });
        }

        public HttpClient Client => WebHost.GetTestClient();

        public IHost WebHost { get; }

        public IHost CreateHost()
        {
            var path = Assembly.GetAssembly(typeof(TestServerFixture))
                            .Location;

            var builder = Host.CreateDefaultBuilder()
                .UseContentRoot(Path.GetDirectoryName(path))
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseTestServer();
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureAppConfiguration(config =>
                    {
                        config.AddJsonFile("appsettings.json", optional: false)
                            .AddEnvironmentVariables();
                    });
                });

            return builder.Start();
        }

        public void Dispose()
        {
            WebHost.Dispose();
        }
    }
}
