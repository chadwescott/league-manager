using System;
using System.IO;
using System.Reflection;

using AutoMapper;
using AutoMapper.Configuration;

using LeagueManager.Api.Configs;
using LeagueManager.Api.Mappers.Responses;
using LeagueManager.Api.Middleware;
using LeagueManager.Business;
using LeagueManager.Business.Models;
using LeagueManager.Domain.Requests;
using LeagueManager.Domain.Responses;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;

using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace LeagueManager.Api
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
            var appSettings = new AppSettings();
            Configuration.Bind("AppSettings", appSettings);
            services.AddSingleton(appSettings);

            var applicationDetails = new ApplicationDetails
            {
                ApplicationName = appSettings.Name,
                Environment = appSettings.Environment,
                Version = appSettings.Version
            };

            services.AddSingleton<ErrorHandlingSettings>();
            services.AddSingleton<CorrelationIdSettings>();
            services.AddSingleton(applicationDetails);

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

            // AutomMapper configuration
            var mapperConfig = new MapperConfigurationExpression();
            mapperConfig.ConfigureAutoMapper();
            services.ConfigureBusinessServices(Configuration, mapperConfig);

            Mapper.Initialize(mapperConfig);
            services.AddSingleton(Mapper.Instance);

            services.AddCors(x => x.AddPolicy("AllowAnyOrigin", y =>
            {
                y.AllowAnyOrigin();
                y.AllowAnyMethod();
                y.AllowAnyHeader();
            }));
            services.Configure<IISOptions>(x => x.AutomaticAuthentication = true);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info
                {
                    Title = "My League REST services",
                    Version = "v1",
                    Description = "A REST service with commands to manage a sports league.",
                    Contact = new Contact
                    {
                        Name = "Chad Wescott",
                        Email = "chadwescott@gmail.com"
                    }
                });
                x.EnableAnnotations();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAnyOrigin");
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "My League REST services");
                x.RoutePrefix = string.Empty;
            });

            if (!env.IsDevelopment())
                app.UseHsts();

            app.UseMiddleware<CorrelationIdMiddleware>();
            app.UseMiddleware<LogRequestMiddleware>();
            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
