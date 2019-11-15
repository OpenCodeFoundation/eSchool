using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace OpenCodeFoundation.eSchool.Identity.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "IdentityServer";
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel()
                    .UseUrls("http://localhost:5105")
                    .UseIISIntegration()
                    .UseStartup<Startup>();
                });
    }
}
