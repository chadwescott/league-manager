using System.IO;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueManager.Database.Tests
{
    public class TestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var config = configBuilder.Build();

            DatabaseStartup.ConfigureDatabaseServices(services, config);
        }

        public void Configure(IApplicationBuilder app)
        {
        }
    }
}
