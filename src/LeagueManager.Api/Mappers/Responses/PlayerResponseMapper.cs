using LeagueManager.Business.Models;
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
                Email = player.Email
            };
        }
    }
}
