using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;

namespace Resulting.API
{
    public static class WebHostExtensions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
               "Design",
               "CA1031:Do not catch general exception types",
               Justification = "Top level all exception catcher")]
        public static IHost MigrateDbContext<TContext>(
               this IHost webHost,
               Action<TContext, IServiceProvider> seeder)
                   where TContext : DbContext
        {
            if (webHost == null)
            {
                throw new ArgumentNullException(nameof(webHost));
            }

            using var scope = webHost.Services.CreateScope();
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<TContext>>();
            var context = services.GetRequiredService<TContext>();

            try
            {
                logger.LogInformation("Migrating database associated with context {ContextName}", typeof(TContext).Name);

                var retry = Policy.Handle<SqlException>()
                    .WaitAndRetry(new TimeSpan[]
                    {
                        TimeSpan.FromSeconds(5),
                        TimeSpan.FromSeconds(10),
                        TimeSpan.FromSeconds(15),
                    });

                //retry.Execute(() =>
                //{
                //    object p = context.Database.Migrate();
                //    seeder(context, services);
                //});

                logger.LogInformation($"Migrated database associated with context {typeof(TContext).Name}");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error occurred while migrating the databases used on context {typeof(TContext).Name}");
            }

            return webHost;

        }
    }
}
