using System;
using System.IO;
using System.Reflection;

using AutoMapper;
using AutoMapper.Configuration;

using LeagueManager.Api.Mappers.Responses;
using LeagueManager.Business;
using LeagueManager.Business.Models;
using LeagueManager.Domain.Requests;
using LeagueManager.Domain.Responses;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

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
            // AutomMapper configuration
            var mapperConfig = new MapperConfigurationExpression();
            services.ConfigureBusinessServices(Configuration, mapperConfig);

            mapperConfig.CreateMap<EventRequest, Event>();
            mapperConfig.CreateMap<LeagueRequest, League>();
            mapperConfig.CreateMap<PlayerRequest, Player>();
            mapperConfig.CreateMap<SeasonRequest, Season>();
            mapperConfig.CreateMap<TeamRequest, Team>();

            mapperConfig.CreateMap<Event, EventResponse>().ForMember(x => x.Links, opt => opt.MapFrom(y => y.ToLinkResponse()));
            mapperConfig.CreateMap<Game, GameResponse>().ForMember(x => x.Links, opt => opt.MapFrom(y => y.ToLinkResponse()));
            mapperConfig.CreateMap<Player, PlayerResponse>().ForMember(x => x.Links, opt => opt.MapFrom(y => y.ToLinkResponse()));
            mapperConfig.CreateMap<Season, SeasonResponse>().ForMember(x => x.Links, opt => opt.MapFrom(y => y.ToLinkResponse()));
            mapperConfig.CreateMap<Team, TeamResponse>().ForMember(x => x.Links, opt => opt.MapFrom(y => y.ToLinkResponse()));

            Mapper.Initialize(mapperConfig);
            services.AddSingleton(Mapper.Instance);

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
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "My League REST services");
                x.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseErrorHandlingMiddleware();
            }
            else
            {
                app.UseHsts();
                app.UseErrorHandlingMiddleware();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
