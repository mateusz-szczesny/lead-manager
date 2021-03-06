using System;
using System.Collections.Generic;
using System.IO;
using Refit;
using System.Reflection;
using LeadManager.Api;
using LeadManager.Models;
using LeadManager.Repositories;
using LeadManager.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using LeadManager.Schedulers;

namespace LeadManager.Extentions
{
    public static class ServiceCollectionExtensions
    {

        public static void AddSchedulers(this IServiceCollection services)
        {
            services.AddHostedService<ActivitiesSyncScheduler>();
        }
        public static void AddRefitClient(this IServiceCollection services)
        {
            services.AddRefitClient<IHQApi>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://hq-pai.herokuapp.com/api");
            });
        }

        public static void AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "LeadManager",
                    Version = "v1",
                    Description = "API for lead management features",
                    Contact = new OpenApiContact() { Name = "Mateusz Szczęsny", Email = "mateusz@mszczesny.com" }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                // c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                // {
                //     Description =
                //         "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                //     Name = "Authorization",
                //     In = ParameterLocation.Header,
                //     Type = SecuritySchemeType.ApiKey,
                //     Scheme = "Bearer"
                // });
                // c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                // {
                //     {
                //         new OpenApiSecurityScheme
                //         {
                //             Reference = new OpenApiReference
                //             {
                //                 Type = ReferenceType.SecurityScheme,
                //                 Id = "Bearer"
                //             },
                //             Name = "Bearer",
                //             In = ParameterLocation.Header,
                //         },
                //         new List<string>()
                //     }
                // });
            });
        }

        public static void AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetValue<string>("DATABASE_URL");
            services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>(
                options =>
                {
                    options.UseNpgsql(connection);
                }
            );
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ILeadService, LeadService>();
            services.AddTransient<IActivityService, ActivityService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ILeadRepository, LeadRepository>();
            services.AddTransient<IActivityRepository, ActivityRepository>();
        }
    }
}