using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CourseRegistration.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CourseRegistration.API
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var configuration = GetConfiguration();

            //Log.Logger = CreateSerilogLogger(configuration);

            try
            {
                //Log.Information("Configuring web host ({ApplicationContext})...", AppName);
                var host = CreateHostBuilder(configuration, args).Build();

                //Log.Information("Applying migrations ({ApplicationContext})...", AppName);
                
                host.MigrateDbContext<CourseRegistrationContext>((_, __) => { });

                //Log.Information("Starting web host ({ApplicationContext})...", AppName);
                host.Run();
                //CreateHostBuilder(args).Build().Run();

                return 0;
            }
            catch (Exception ex)
            {
                //Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                //Log.CloseAndFlush();
            }

            
        }

        public static IHostBuilder CreateHostBuilder(IConfiguration configuration, string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
            webBuilder.UseConfiguration(configuration);
            //webBuilder.UseSerilog();
        });

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });


        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            // Load other configurations here. Ex. Keyvault or AppConfiguration
            return builder.Build();
        }
    }
}
