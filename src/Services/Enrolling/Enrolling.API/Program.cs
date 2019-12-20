using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using OpenCodeFoundation.ESchool.Services.Enrolling.Infrastructure;
using Serilog;
using Serilog.Events;

namespace OpenCodeFoundation.ESchool.Services.Enrolling.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.WithProperty("ApplicationContext", "Enrolling")
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Seq("http://seq")
                .CreateLogger();

            try
            {
                Log.Information("Starting web host");
                CreateHostBuilder(args).Build()
                    .MigrateDbContext<EnrollingContext>((_, __) => { })
                    .Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseSerilog();
                });
    }
}
