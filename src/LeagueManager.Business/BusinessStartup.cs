using LeagueManager.Business.Commands;
using LeagueManager.Business.Commands.Impl;
using LeagueManager.Business.Mappers;
using LeagueManager.Business.Models;
using LeagueManager.Database;
using LeagueManager.Database.Models;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueManager.Business
{
    public static class BusinessStartup
    {
        public static void ConfigureBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDatabaseServices(configuration);

            // Mapper registration
            services.AddTransient<IResourceMapper<Event, EventResource>, EventMapper>();
            services.AddTransient<IResourceMapper<League, LeagueResource>, LeagueMapper>();
            services.AddTransient<IResourceMapper<Player, PlayerResource>, PlayerMapper>();
            services.AddTransient<IResourceMapper<Season, SeasonResource>, SeasonMapper>();
            services.AddTransient<IResourceMapper<Team, TeamResource>, TeamMapper>();
            services.AddTransient<IResourceMapper<TeamPlayer, TeamPlayerXrefResource>, TeamPlayerMapper>();

            // Delete command registration
            services.AddTransient<IDeleteModel<TeamPlayer>, DeleteTeamPlayer>();

            // Get command registration
            services.AddTransient<IGetModels<Event>, GetEvents>();
            services.AddTransient<IGetModelById<Event>, GetModelById<Event, EventResource>>();
            services.AddTransient<IGetModels<League>, GetModels<League, LeagueResource>>();
            services.AddTransient<IGetModelById<League>, GetModelById<League, LeagueResource>>();
            services.AddTransient<IGetModels<Player>, GetPlayers>();
            services.AddTransient<IGetModelById<Player>, GetModelById<Player, PlayerResource>>();
            services.AddTransient<IGetPlayersByTeam, GetPlayersByTeam>();
            services.AddTransient<IGetModels<Season>, GetModels<Season, SeasonResource>>();
            services.AddTransient<IGetModelById<Season>, GetModelById<Season, SeasonResource>>();
            services.AddTransient<IGetModels<Team>, GetModels<Team, TeamResource>>();
            services.AddTransient<IGetModelById<Team>, GetModelById<Team, TeamResource>>();
            services.AddTransient<IGetTeamPlayerByTeamIdAndPlayerId, GetTeamPlayerByTeamIdAndPlayerId>();
            services.AddTransient<IGetTeamsByEvent, GetTeamsByEvent>();

            // Save command registration
            services.AddTransient<ISaveModel<Event>, SaveModel<Event, EventResource>>();
            services.AddTransient<ISaveModel<League>, SaveModel<League, LeagueResource>>();
            services.AddTransient<ISaveModel<Player>, SaveModel<Player, PlayerResource>>();
            services.AddTransient<ISaveModel<Season>, SaveModel<Season, SeasonResource>>();
            services.AddTransient<ISaveModel<Team>, SaveModel<Team, TeamResource>>();
            services.AddTransient<ISaveModel<TeamPlayer>, SaveModel<TeamPlayer, TeamPlayerXrefResource>>();
        }
    }
}
