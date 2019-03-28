using LeagueManager.Business.Models;
using LeagueManager.Domain;
using LeagueManager.Domain.Responses;

namespace LeagueManager.Api.Mappers.Responses
{
    public static class PlayerLinkResponseMapper
    {
        public static LinkResponse[] ToLinkResponse(this Player model)
        {
            if (model == null)
                return null;

            return new []
            {
                new LinkResponse
                {
                    Href = $"/{Routes.Players}/{model.Id}/{Routes.Leagues}",
                    MediaType = MediaTypes.Json,
                    Method = Methods.GET,
                    Rel = LinkTypes.LEAGUES 
                }
            };
        }
    }
}
