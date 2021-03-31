using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry;
using OpenTelemetry.Context.Propagation;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace OpenCodeFoundation.OpenTelemetry
{
    public static class ServiceCollectionExtensions
    {
        private const string SectionName = "OpenTelemetry";

        public static IServiceCollection AddOpenTelemetryIntegration(
            this IServiceCollection services,
            Action<OpenTelemetryOptions>? options = null,
            string sectionName = SectionName)
        {
            var openTelemetryOptions = services.GetOptions(sectionName, options);

            if (openTelemetryOptions.Enabled)
            {
                ConfigureOpenTelemetry(services, openTelemetryOptions);
            }

            return services;
        }

        public static T GetOptions<T>(
            this IServiceCollection services,
            string sectionName,
            Action<T>? configure = null)
        where T : IConfigurationOptions, new()
        {
            var provider = services.BuildServiceProvider();
            var configuration = provider.GetRequiredService<IConfiguration>();

            var options = new T();
            configure?.Invoke(options);

            configuration.GetSection(sectionName).Bind(options);

            options.Validate();
            return options;
        }

        private static void ConfigureOpenTelemetry(IServiceCollection services, OpenTelemetryOptions openTelemetryOptions)
        {
            services.AddOpenTelemetryTracing(configure =>
            {
                ConfigureSampler(openTelemetryOptions, configure);
                ConfigureInstrumentation(openTelemetryOptions, configure);
                ConfigureExporters(openTelemetryOptions, configure);
            });
        }

        private static void ConfigureSampler(OpenTelemetryOptions openTelemetryOptions, TracerProviderBuilder configure)
        {
            if (openTelemetryOptions.AlwaysOnSampler)
            {
                configure.SetSampler(new AlwaysOnSampler());
            }
        }

        private static void ConfigureExporters(OpenTelemetryOptions openTelemetryOptions, TracerProviderBuilder configure)
        {
            if (openTelemetryOptions.Jaeger.Enabled)
            {
                configure.SetResourceBuilder(ResourceBuilder.CreateDefault()
                    .AddService(openTelemetryOptions.Jaeger.ServiceName));

                configure.AddJaegerExporter(config =>
                {
                    config.AgentHost = openTelemetryOptions.Jaeger.Host;
                    config.AgentPort = openTelemetryOptions.Jaeger.Port ?? 6831;
                });
            }
        }

        private static void ConfigureInstrumentation(OpenTelemetryOptions openTelemetryOptions, TracerProviderBuilder configure)
        {
            Sdk.SetDefaultTextMapPropagator(GetPropagator(openTelemetryOptions));

            configure.AddAspNetCoreInstrumentation();

            configure.AddHttpClientInstrumentation();

            configure.AddSqlClientInstrumentation();
        }

        private static TextMapPropagator GetPropagator(OpenTelemetryOptions openTelemetryOptions)
        {
            var propagators = new List<TextMapPropagator>()
            {
                new TraceContextPropagator(),
                new BaggagePropagator(),
            };

            if (openTelemetryOptions.Istio)
            {
                propagators.Add(new B3Propagator());
            }

            return new CompositeTextMapPropagator(propagators);
        }
    }
}
