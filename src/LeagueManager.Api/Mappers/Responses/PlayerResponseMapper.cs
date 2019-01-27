using LeagueManager.Business.Models;
using LeagueManager.Domain;
using LeagueManager.Domain.Responses;

namespace LeagueManager.Api.Mappers.Responses
{
    public static class PlayerResponseMapper
    {
        public static PlayerResponse ToResponse(this Player player)
        {
            return new PlayerResponse
            {
                Id = player.Id,
                FirstName = player.FirstName,
                LastName = player.LastName,
                NickName = player.NickName,
                Email = player.Email,
                Links = new LinkResponse[]
                {
                    new LinkResponse
                    {
                        Href = $"/{Routes.Players}/{player.Id}/{Routes.Leagues}",
                        MediaType = MediaTypes.Json,
                        Method = Methods.GET,
                        Rel = LinkTypes.LEAGUES 
                    }
                }
            };
        }
    }
}
