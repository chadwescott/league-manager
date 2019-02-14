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

            services.AddTransient<IResourceMapper<Event, EventResource>, EventMapper>();
            services.AddTransient<IResourceMapper<League, LeagueResource>, LeagueMapper>();
            services.AddTransient<IResourceMapper<Player, PlayerResource>, PlayerMapper>();
            services.AddTransient<IResourceMapper<Season, SeasonResource>, SeasonMapper>();
            services.AddTransient<IResourceMapper<Team, TeamResource>, TeamMapper>();

            services.AddTransient<IGetAllModels<Event>, GetAllEvents>();
            services.AddTransient<IGetModelById<Event>, GetModelById<Event, EventResource>>();
            services.AddTransient<ISaveModel<Event>, SaveModel<Event, EventResource>>();

            services.AddTransient<IGetAllModels<League>, GetAllModels<League, LeagueResource>>();
            services.AddTransient<IGetModelById<League>, GetModelById<League, LeagueResource>>();
            services.AddTransient<ISaveModel<League>, SaveModel<League, LeagueResource>>();

            services.AddTransient<IGetAllModels<Player>, GetAllPlayers>();
            services.AddTransient<IGetModelById<Player>, GetModelById<Player, PlayerResource>>();
            services.AddTransient<IGetPlayersByTeam, GetPlayersByTeam>();
            services.AddTransient<ISaveModel<Player>, SaveModel<Player, PlayerResource>>();

            services.AddTransient<IGetAllModels<Season>, GetAllModels<Season, SeasonResource>>();
            services.AddTransient<IGetModelById<Season>, GetModelById<Season, SeasonResource>>();
            services.AddTransient<ISaveModel<Season>, SaveModel<Season, SeasonResource>>();

            services.AddTransient<IGetAllModels<Team>, GetAllModels<Team, TeamResource>>();
            services.AddTransient<IGetModelById<Team>, GetModelById<Team, TeamResource>>();
            services.AddTransient<IGetTeamsByEvent, GetTeamsByEvent>();
            services.AddTransient<ISaveModel<Team>, SaveModel<Team, TeamResource>>();
        }
    }
}
