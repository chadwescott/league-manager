using LeagueManager.Business.Models;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Mappers
{
    internal class LeagueMapper : IResourceMapper<League, LeagueResource>
    {
        public League ToModel(LeagueResource resource)
        {
            return resource == null
                ? null
                : new League
                {
                    Id = resource.Id,
                    Name = resource.Name
                };
        }

        public LeagueResource ToResource(League model)
        {
            return model == null
                ? null
                : new LeagueResource
                {
                    Id = model.Id,
                    Name = model.Name
                };
        }
    }
}
