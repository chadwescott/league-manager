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

            services.AddTransient<IGetAllModels<Event>, GetAllModels<Event, EventResource>>();
            services.AddTransient<IGetEventById, GetEventById>();
            services.AddTransient<IResourceMapper<Event, EventResource>, EventMapper>();
            services.AddTransient<ISaveModel<Event>, SaveModel<Event, EventResource>>();

            services.AddTransient<IGetAllModels<Player>, GetAllModels<Player, PlayerResource>>();
            services.AddTransient<IGetPlayerById, GetPlayerById>();
            services.AddTransient<IResourceMapper<Player, PlayerResource>, PlayerMapper>();
            services.AddTransient<ISaveModel<Player>, SaveModel<Player, PlayerResource>>();
        }
    }
}
