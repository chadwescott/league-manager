using LeagueManager.DataAccess.Context;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Commands.Impl;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueManager.Database
{
    public static class DatabaseStartup
    {
        public static void ConfigureDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = new DatabaseSettings();
            configuration.Bind("Database", settings);
            services.AddSingleton(settings);

            services.AddSingleton<IContextFactory<IDbContext>>(x => new ContextFactory<ILeagueManagerContext>(settings.ConnectionString, -1));

            services.AddTransient<IGetAllPlayersSqlCommand, GetAllPlayersSqlCommand>();
        }
    }
}
