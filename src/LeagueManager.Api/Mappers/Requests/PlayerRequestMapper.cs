using LeagueManager.Business.Models;
using LeagueManager.Domain.Requests;

namespace LeagueManager.Api.Mappers.Requests
{
    public static class PlayerRequestMapper
    {
        public static Player ToPlayer(this PlayerRequest request)
        {
            return new Player
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                NickName = request.NickName
            };
        }
    }
}
