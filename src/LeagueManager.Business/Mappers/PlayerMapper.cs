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
        public static PlayerResource ToPlayerResource(this Player model)
        {
            return model == null
                ? null
                : new PlayerResource
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    NickName = model.NickName,
                    Email = model.Email
                };
        }
    }
}
