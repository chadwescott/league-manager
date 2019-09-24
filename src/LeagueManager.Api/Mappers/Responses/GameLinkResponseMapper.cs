using LeagueManager.Business.Models;
using LeagueManager.Domain;
using LeagueManager.Domain.Responses;

namespace LeagueManager.Api.Mappers.Responses
{
    public static class GameLinkResponseMapper
    {
        public static LinkResponse[] ToLinkResponse(this Game model)
        {
            return new LinkResponse[] { };
            //return new[]
            //{
            //    new LinkResponse
            //    {
            //        Href = $"/{Routes.Games}/{model.Id}",
            //        MediaType = MediaTypes.Json,
            //        Method = Methods.GET,
            //        Rel = LinkTypes.GAMES
            //    }
            //};
        }
    }
}
