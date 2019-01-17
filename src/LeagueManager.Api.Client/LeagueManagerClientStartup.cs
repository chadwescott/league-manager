﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueManager.Api.Client
{
    public static class LeagueManagerClientStartup
    {
        public static void ConfigureBaanClientServices(this IServiceCollection services, IConfiguration configuration)
        {
            var clientSettings = new LeagueManagerClientSettings();
            configuration.Bind("BaanClient", clientSettings);
            services.AddSingleton(clientSettings);

            services.AddSingleton<LeagueManagerClient>();
        }
    }
}
