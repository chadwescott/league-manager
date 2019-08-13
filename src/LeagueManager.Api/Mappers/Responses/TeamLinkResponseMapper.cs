using LeagueManager.Business.Models;
using LeagueManager.Domain;
using LeagueManager.Domain.Responses;

namespace LeagueManager.Api.Mappers.Responses
{
    public static class TeamLinkResponseMapper
    {
        public static LinkResponse[] ToLinkResponse(this Team model)
        {
            return new []
            {
                new LinkResponse
                {
                    Href = $"/{Routes.Teams}/{model.Id}/{Routes.Players}",
                    MediaType = MediaTypes.Json,
                    Method = Methods.GET,
                    Rel = LinkTypes.PLAYERS
                }
            };
        }
    }
}
