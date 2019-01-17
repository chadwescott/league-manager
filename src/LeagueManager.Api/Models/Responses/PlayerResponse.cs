using System;
using LeagueManager.Business.Models;
using Newtonsoft.Json;

namespace LeagueManager.Api.Models.Responses
{
    public class PlayerResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("nickName")]
        public string NickName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }

    public static class PlayerResponseMapper
    {
        public static PlayerResponse ToResponse(this Player player)
        {
            return new PlayerResponse
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
