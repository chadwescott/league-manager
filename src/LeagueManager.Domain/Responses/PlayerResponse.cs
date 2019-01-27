using System;
using Newtonsoft.Json;

namespace LeagueManager.Domain.Responses
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

        [JsonProperty("links")]
        public LinkResponse[] Links { get; set; }
    }
}
