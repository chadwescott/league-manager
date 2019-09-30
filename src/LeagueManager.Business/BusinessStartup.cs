using AutoMapper.Configuration;

using LeagueManager.Business.Commands;
using LeagueManager.Business.Commands.Impl;
using LeagueManager.Business.Configs;
using LeagueManager.Business.Models;
using LeagueManager.Database;
using LeagueManager.Database.Models;

using Microsoft.Extensions.DependencyInjection;

using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace LeagueManager.Business
{
    public static class BusinessStartup
    {
        public static void ConfigureBusinessServices(
            this IServiceCollection services,
            IConfiguration configuration,
            MapperConfigurationExpression mapperConfig)
        {
            services.ConfigureDatabaseServices(configuration);

            // AutoMapper configuration
            mapperConfig.ConfigureAutoMapper();

            // Delete command registration
            services.AddTransient<IDeleteModel<TeamPlayer>, DeleteTeamPlayer>();

            // Get command registration
            services.AddTransient<IGetModels<Event>, GetEvents>();
            services.AddTransient<IGetModelById<Event>, GetModelById<Event, EventResource>>();
            services.AddTransient<IGetModels<Game>, GetModels<Game, GameResource>>();
            services.AddTransient<IGetModelById<Game>, GetModelById<Game, GameResource>>();
            services.AddTransient<IGetModels<GameType>, GetModels<GameType, GameTypeResource>>();
            services.AddTransient<IGetModelById<GameType>, GetModelById<GameType, GameTypeResource>>();
            services.AddTransient<IGetModels<League>, GetModels<League, LeagueResource>>();
            services.AddTransient<IGetModelById<League>, GetModelById<League, LeagueResource>>();
            services.AddTransient<IGetModels<Player>, GetPlayers>();
            services.AddTransient<IGetModelById<Player>, GetModelById<Player, PlayerResource>>();
            services.AddTransient<IGetPlayersByTeam, GetPlayersByTeam>();
            services.AddTransient<IGetModels<ScoreSystem>, GetModels<ScoreSystem, ScoreSystemResource>>();
            services.AddTransient<IGetModelById<ScoreSystem>, GetModelById<ScoreSystem, ScoreSystemResource>>();
            services.AddTransient<IGetModels<Season>, GetModels<Season, SeasonResource>>();
            services.AddTransient<IGetModelById<Season>, GetModelById<Season, SeasonResource>>();
            services.AddTransient<IGetModels<Team>, GetModels<Team, TeamResource>>();
            services.AddTransient<IGetModelById<Team>, GetModelById<Team, TeamResource>>();
            services.AddTransient<IGetTeamPlayerByTeamIdAndPlayerId, GetTeamPlayerByTeamIdAndPlayerId>();
            services.AddTransient<IGetTeamsByEvent, GetTeamsByEvent>();
            services.AddTransient<IGetTeamsByGameId, GetTeamsByGameId>();
            services.AddTransient<IGetTeamStatisticsByGameId, GetTeamStatisticsByGameId>();

            // Save command registration
            services.AddTransient<ISaveModel<Event>, SaveModel<Event, EventResource>>();
            services.AddTransient<ISaveModel<Game>, SaveGame>();
            services.AddTransient<ISaveModel<GameType>, SaveModel<GameType, GameTypeResource>>();
            services.AddTransient<ISaveModel<League>, SaveModel<League, LeagueResource>>();
            services.AddTransient<ISaveModel<Player>, SaveModel<Player, PlayerResource>>();
            services.AddTransient<ISaveModel<ScoreSystem>, SaveModel<ScoreSystem, ScoreSystemResource>>();
            services.AddTransient<ISaveModel<Season>, SaveModel<Season, SeasonResource>>();
            services.AddTransient<ISaveModel<Team>, SaveModel<Team, TeamResource>>();
            services.AddTransient<ISaveModel<TeamPlayer>, SaveModel<TeamPlayer, TeamPlayerXrefResource>>();
        }
    }
}
