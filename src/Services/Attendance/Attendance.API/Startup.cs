using System;
using System.Reflection;
using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using OpenCodeFoundation.ESchool.Services.Attendance.API.Application.Behaviors;
using OpenCodeFoundation.ESchool.Services.Attendance.API.Application.Validations;
using OpenCodeFoundation.ESchool.Services.Attendance.API.Extensions;
using OpenCodeFoundation.ESchool.Services.Attendance.API.Graphql;
using OpenCodeFoundation.ESchool.Services.Attendance.Infrastructure;
using OpenCodeFoundation.OpenTelemetry;
using Serilog;

namespace OpenCodeFoundation.ESchool.Services.Attendance.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            services.AddDbContext<AttendanceContext>(options =>
                {
                    options.UseSqlServer(
                        Configuration["ConnectionStrings"],
                        sqlServerOptionsAction: sqlOptions =>
                            {
                                sqlOptions.MigrationsAssembly(typeof(AttendanceContext).GetTypeInfo().Assembly.GetName().Name);
                                sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                            });
                });

            services.AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                    .AddType<AttendanceQuery>()
                .AddMutationType<Mutation>()
                .AddErrorFilter<GraphQlErrorFilter>();

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                })
                .AddFluentValidation(fv =>
                    fv.RegisterValidatorsFromAssemblyContaining<AttendanceApplicationCommandValidator>());

            services.AddCustomHealthChecks(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Attendance HTTP API", Version = "v1" });
            });

            services.AddOpenTelemetryIntegration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var pathBase = Configuration["PATH_BASE"];
            if (!string.IsNullOrEmpty(pathBase))
            {
                loggerFactory.CreateLogger<Startup>().LogInformation("Using PATH BASE '{pathBase}'", pathBase);
                app.UsePathBase(pathBase);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();

            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"{pathBase}/swagger/v1/swagger.json", "Attendance HTTP API");
                });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
                });
                endpoints.MapHealthChecks("/liveness", new HealthCheckOptions()
                {
                    Predicate = r => r.Name.Contains("self", StringComparison.Ordinal),
                });

                endpoints.MapGraphQL();
            });
        }
    }
}
