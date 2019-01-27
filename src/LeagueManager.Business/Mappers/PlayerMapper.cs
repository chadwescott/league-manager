using LeagueManager.Business.Models;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Mappers
{
    internal static class PlayerMapper
    {
        public static Player ToPlayer(this PlayerResource resource)
        {
            return resource == null
                ? null
                : new Player
                {
                    Id = resource.Id,
                    FirstName = resource.FirstName,
                    LastName = resource.LastName,
                    NickName = resource.NickName,
                    Email = resource.Email
                };
        }
        public static PlayerResource ToPlayerResource(this Player player)
        {
            return player == null
                ? null
                : new PlayerResource
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
