using LeagueManager.Business.Commands;
using LeagueManager.Business.Commands.Impl;
using LeagueManager.Database;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueManager.Business
{
    public static class BusinessStartup
    {
        public static void ConfigureBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDatabaseServices(configuration);

            services.AddTransient<IGetAllPlayers, GetAllPlayers>();
            services.AddTransient<IGetPlayerById, GetPlayerById>();
            services.AddTransient<ISavePlayer, SavePlayer>();
        }
    }
}
