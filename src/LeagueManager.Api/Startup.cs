using LeagueManager.Business;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Swashbuckle.AspNetCore.Swagger;

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
            services.ConfigureBusinessServices(Configuration);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info
                {
                    Title = "League Manager REST services",
                    Version = "v1",
                    Description = "A REST service with commands to manage a sports league.",
                    Contact = new Contact
                    {
                        Name = "Chad Wescott",
                        Email = "chadwescott@gmail.com"
                    }
                });
                x.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "League Manager REST services");
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
