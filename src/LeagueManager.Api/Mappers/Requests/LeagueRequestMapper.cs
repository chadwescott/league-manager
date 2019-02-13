using LeagueManager.Business.Models;
using LeagueManager.Domain.Requests;

namespace LeagueManager.Api.Mappers.Requests
{
    public static class LeagueRequestMapper
    {
        public static League ToLeague(this LeagueRequest request)
        {
            return new League
            {
                Name = request.Name
            };
        }
    }
}
