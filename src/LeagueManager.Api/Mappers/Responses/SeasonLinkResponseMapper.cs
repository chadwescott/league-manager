using LeagueManager.Business.Models;
using LeagueManager.Domain;
using LeagueManager.Domain.Responses;

namespace LeagueManager.Api.Mappers.Responses
{
    public static class SeasonLinkResponseMapper
    {
        public static LinkResponse[] ToLinkResponse(this Season model)
        {
            return new []
            {
                new LinkResponse
                {
                    Href = $"/{Routes.Leagues}/{model.LeagueId}",
                    MediaType = MediaTypes.Json,
                    Method = Methods.GET,
                    Rel = LinkTypes.LEAGUES
                }
            };
        }
    }
}
