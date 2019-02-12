using LeagueManager.DataAccess.Context;
using LeagueManager.Database.Commands;
using LeagueManager.Database.Commands.Impl;
using LeagueManager.Database.Models;

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

            services.AddSingleton<IGetAllResourcesSqlCommand<EventResource>, GetAllEventsSqlCommand>();
            services.AddTransient<IGetByIdSqlCommand<EventResource>, GetByIdSqlCommand<EventResource>>();
            services.AddSingleton<ISaveSqlCommand<EventResource>, SaveSqlCommand<EventResource>>();

            services.AddSingleton<IGetAllResourcesSqlCommand<PlayerResource>, GetAllPlayersSqlCommand>();
            services.AddTransient<IGetByIdSqlCommand<PlayerResource>, GetByIdSqlCommand<PlayerResource>>();
            services.AddSingleton<ISaveSqlCommand<PlayerResource>, SaveSqlCommand<PlayerResource>>();

            services.AddSingleton<IGetAllResourcesSqlCommand<SeasonResource>, GetAllResourcesSqlCommand<SeasonResource>>();
            services.AddTransient<IGetByIdSqlCommand<SeasonResource>, GetByIdSqlCommand<SeasonResource>>();
            services.AddSingleton<ISaveSqlCommand<SeasonResource>, SaveSqlCommand<SeasonResource>>();
        }
    }
}
