using AutoMapper.Configuration;

using LeagueManager.Business.Models;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Configs
{
    internal static class AutoMapperConfig
    {
        public static void ConfigureAutoMapper(this MapperConfigurationExpression mapperConfig)
        {
            mapperConfig.CreateMap<Event, EventResource>();
            mapperConfig.CreateMap<EventResource, Event>();
            mapperConfig.CreateMap<Game, GameResource>();
            mapperConfig.CreateMap<GameTeamStatistics, GameTeamXrefResource>();
            mapperConfig.CreateMap<GameResource, Game>();
            mapperConfig.CreateMap<League, LeagueResource>();
            mapperConfig.CreateMap<LeagueResource, League>();
            mapperConfig.CreateMap<Player, PlayerResource>();
            mapperConfig.CreateMap<PlayerResource, Player>();
            mapperConfig.CreateMap<ScoreSystem, ScoreSystemResource>();
            mapperConfig.CreateMap<ScoreSystemResource, ScoreSystem>();
            mapperConfig.CreateMap<Season, SeasonResource>();
            mapperConfig.CreateMap<SeasonResource, Season>();
            mapperConfig.CreateMap<Team, TeamResource>();
            mapperConfig.CreateMap<TeamResource, Team>();
            mapperConfig.CreateMap<TeamPlayer, TeamPlayerXrefResource>();
            mapperConfig.CreateMap<TeamPlayerXrefResource, TeamPlayer>();
        }
    }
}
