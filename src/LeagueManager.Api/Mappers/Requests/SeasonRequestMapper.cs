using LeagueManager.Business.Models;
using LeagueManager.Domain.Requests;

namespace LeagueManager.Api.Mappers.Requests
{
    public static class SeasonRequestMapper
    {
        public static Season ToSeason(this SeasonRequest request)
        {
            return new Season
            {
                LeagueId = request.LeagueId,
                Name = request.Name,
                SortOrder = request.SortOrder
            };
        }
    }
}
