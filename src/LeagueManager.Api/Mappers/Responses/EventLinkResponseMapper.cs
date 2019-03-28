using LeagueManager.Business.Models;
using LeagueManager.Domain;
using LeagueManager.Domain.Responses;

namespace LeagueManager.Api.Mappers.Responses
{
    public static class EventLinkResponseMapper
    {
        public static LinkResponse[] ToLinkResponse(this Event model)
        {
            return new []
            {
                new LinkResponse
                {
                    Href = $"/{Routes.Seasons}/{model.SeasonId}",
                    MediaType = MediaTypes.Json,
                    Method = Methods.GET,
                    Rel = LinkTypes.SEASONS
                }
            };
        }
    }
}
