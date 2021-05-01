using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Resulting.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCustomHealthChecks(
               this IServiceCollection services,
               IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var hcBuilder = services.AddHealthChecks();

            //hcBuilder
            //    .AddCheck("self", () => HealthCheckResult.Healthy())
            //    .AddSqlServer(
            //        configuration["ConnectionStrings"],
            //        name: "ResultingDB-check",
            //        tags: new string[] { "resultingdb" });

            return services;
        }
    }
}
