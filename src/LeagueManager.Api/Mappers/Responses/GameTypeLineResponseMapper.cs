using LeagueManager.Business.Models;
using LeagueManager.Domain;
using LeagueManager.Domain.Responses;

namespace LeagueManager.Api.Mappers.Responses
{
    public static class GameTypeLinkResponseMapper
    {
        public static LinkResponse[] ToLinkResponse(this GameType model)
        {
            return new[]
            {
                new LinkResponse
                {
                    Href = $"/{Routes.GameTypes}/{model.Id}",
                    MediaType = MediaTypes.Json,
                    Method = Methods.GET,
                    Rel = LinkTypes.GAME_TYPES
                },
                new LinkResponse
                {
                    Href = $"/{Routes.ScoreSystems}/{model.ScoreSystemId}",
                    MediaType = MediaTypes.Json,
                    Method = Methods.GET,
                    Rel = LinkTypes.SCORE_SYSTEMS
                }
            };
        }
    }
}
