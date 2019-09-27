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

            services.AddSingleton<IContextFactory>(x => new ContextFactory(settings.ConnectionString));
            services.AddSingleton<IQueryDbContext, QueryDbContext>();

            services.AddSingleton<IGetSqlCommand<EventResource>, GetSqlCommand<EventResource>>();
            services.AddSingleton<ISaveSqlCommand<EventResource>, SaveSqlCommand<EventResource>>();

            services.AddSingleton<IGetSqlCommand<GameResource>, GetSqlCommand<GameResource>>();
            services.AddSingleton<ISaveSqlCommand<GameResource>, SaveSqlCommand<GameResource>>();

            services.AddSingleton<IGetSqlCommand<LeagueResource>, GetSqlCommand<LeagueResource>>();
            services.AddSingleton<ISaveSqlCommand<LeagueResource>, SaveSqlCommand<LeagueResource>>();

            services.AddSingleton<IGetSqlCommand<PlayerResource>, GetSqlCommand<PlayerResource>>();
            services.AddSingleton<ISaveSqlCommand<PlayerResource>, SaveSqlCommand<PlayerResource>>();

            services.AddSingleton<IGetSqlCommand<SeasonResource>, GetSqlCommand<SeasonResource>>();
            services.AddSingleton<ISaveSqlCommand<SeasonResource>, SaveSqlCommand<SeasonResource>>();

            services.AddSingleton<IGetSqlCommand<ScoreSystemResource>, GetSqlCommand<ScoreSystemResource>>();
            services.AddSingleton<ISaveSqlCommand<ScoreSystemResource>, SaveSqlCommand<ScoreSystemResource>>();

            services.AddSingleton<IGetSqlCommand<TeamPlayerXrefResource>, GetSqlCommand<TeamPlayerXrefResource>>();
            services.AddSingleton<ISaveSqlCommand<TeamPlayerXrefResource>, SaveSqlCommand<TeamPlayerXrefResource>>();
            services.AddSingleton<IDeleteSqlCommand<TeamPlayerXrefResource>, DeleteSqlCommand<TeamPlayerXrefResource>>();

            services.AddSingleton<IGetSqlCommand<TeamResource>, GetSqlCommand<TeamResource>>();
            services.AddSingleton<ISaveSqlCommand<TeamResource>, SaveSqlCommand<TeamResource>>();
        }
    }
}
