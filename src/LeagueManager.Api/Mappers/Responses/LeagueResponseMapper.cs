using LeagueManager.Business.Models;
using LeagueManager.Domain.Responses;

namespace LeagueManager.Api.Mappers.Responses
{
    public static class LeagueResponseMapper
    {
        public static LeagueResponse ToResponse(this League model)
        {
            return new LeagueResponse
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
