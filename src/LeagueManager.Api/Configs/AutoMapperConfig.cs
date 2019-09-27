using System;

using AutoMapper.Configuration;

using LeagueManager.Api.Mappers.Responses;
using LeagueManager.Business.Models;
using LeagueManager.Domain.Requests;
using LeagueManager.Domain.Responses;

namespace LeagueManager.Api.Configs
{
    internal static class AutoMapperConfig
    {
        public static void ConfigureAutoMapper(this MapperConfigurationExpression mapperConfig)
        {
            // Requests
            mapperConfig.CreateMap<EventRequest, Event>();
            mapperConfig.CreateMap<GameRequest, Game>();
            mapperConfig.CreateMap<LeagueRequest, League>();
            mapperConfig.CreateMap<PlayerRequest, Player>();
            mapperConfig.CreateMap<ScoreSystemRequest, ScoreSystem>();
            mapperConfig.CreateMap<SeasonRequest, Season>();
            mapperConfig.CreateMap<TeamRequest, Team>();

            // Responses
            mapperConfig.CreateMap<Event, EventResponse>().ForMember(x => x.Links, opt => opt.MapFrom(y => y.ToLinkResponse()));
            mapperConfig.CreateMap<Game, GameResponse>().ForMember(x => x.Links, opt => opt.MapFrom(y => y.ToLinkResponse()));
            mapperConfig.CreateMap<GameTeamStatistics, GameTeamStatisticsResponse>();
            mapperConfig.CreateMap<Player, PlayerResponse>().ForMember(x => x.Links, opt => opt.MapFrom(y => y.ToLinkResponse()));
            mapperConfig.CreateMap<ScoreSystem, ScoreSystemResponse>();
            mapperConfig.CreateMap<Season, SeasonResponse>().ForMember(x => x.Links, opt => opt.MapFrom(y => y.ToLinkResponse()));
            mapperConfig.CreateMap<Statistic<decimal>, StatisticResponse<decimal>>();
            mapperConfig.CreateMap<Statistic<int>, StatisticResponse<int>>();
            mapperConfig.CreateMap<Statistic<TimeSpan>, StatisticResponse<TimeSpan>>();
            mapperConfig.CreateMap<Team, TeamResponse>().ForMember(x => x.Links, opt => opt.MapFrom(y => y.ToLinkResponse()));
        }
    }
}
