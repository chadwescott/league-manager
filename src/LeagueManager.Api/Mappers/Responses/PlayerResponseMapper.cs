using LeagueManager.Business.Models;
using LeagueManager.Domain;
using LeagueManager.Domain.Responses;

namespace LeagueManager.Api.Mappers.Responses
{
    public static class PlayerResponseMapper
    {
        public static PlayerResponse ToResponse(this Player model)
        {
            if (model == null)
                return null;

            return new PlayerResponse
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                NickName = model.NickName,
                Email = model.Email,
                Links = new LinkResponse[]
                {
                    new LinkResponse
                    {
                        Href = $"/{Routes.Players}/{model.Id}/{Routes.Leagues}",
                        MediaType = MediaTypes.Json,
                        Method = Methods.GET,
                        Rel = LinkTypes.LEAGUES 
                    }
                }
            };
        }
    }
}
