using LeagueManager.Business.Models;
using LeagueManager.Database.Models;

namespace LeagueManager.Business.Mappers
{
    internal class SeasonMapper : IResourceMapper<Season, SeasonResource>
    {
        public Season ToModel(SeasonResource resource)
        {
            return new Season
            {
                Id = resource.Id,
                LeagueId = resource.LeagueId,
                Name = resource.Name,
                SortOrder = resource.SortOrder
            };
        }

        public SeasonResource ToResource(Season model)
        {
            return new SeasonResource
            {
                Id = model.Id,
                LeagueId = model.LeagueId,
                Name = model.Name,
                SortOrder = model.SortOrder
            };
        }
    }
}
