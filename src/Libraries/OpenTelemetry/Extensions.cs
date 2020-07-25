using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Context.Propagation;
using OpenTelemetry.Trace;
using OpenTelemetry.Trace.Samplers;

namespace OpenCodeFoundation.OpenTelemetry
{
    public static class Extensions
    {
        private const string SectionName = "OpenTelemetry";

        public static IServiceCollection AddOpenTelemetryIntegration(
            this IServiceCollection services,
            Action<OpenTelemetryOptions> options = null,
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
            Action<T> configure = null)
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
            services.AddOpenTelemetry(configure =>
            {
                ConfigureSampler(openTelemetryOptions, configure);
                ConfigureInstrumentations(openTelemetryOptions, configure);
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
                configure.UseJaegerExporter(config =>
                {
                    config.ServiceName = openTelemetryOptions.Jaeger.ServiceName;

                    config.AgentHost = openTelemetryOptions.Jaeger.Host;
                    config.AgentPort = openTelemetryOptions.Jaeger.Port;
                });
            }
        }

        private static void ConfigureInstrumentations(OpenTelemetryOptions openTelemetryOptions, TracerProviderBuilder configure)
        {
            configure.AddAspNetCoreInstrumentation(config =>
            {
                config.TextFormat = GetTextFormat(openTelemetryOptions);
            });

            configure.AddHttpClientInstrumentation(config =>
            {
                config.TextFormat = GetTextFormat(openTelemetryOptions);
            });

            configure.AddSqlClientDependencyInstrumentation();
        }

        private static ITextFormat GetTextFormat(OpenTelemetryOptions openTelemetryOptions)
            => openTelemetryOptions.Istio
                ? new B3Format()
                : (ITextFormat)new TraceContextFormat();
    }
}
