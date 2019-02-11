using LeagueManager.Business.Models;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Mappers
{
    internal class PlayerMapper : IResourceMapper<Player, PlayerResource>
    {
        public Player ToModel(PlayerResource resource)
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

        public PlayerResource ToResource(Player model)
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
