using Newtonsoft.Json;

namespace LeagueManager.Domain.Requests
{
    public class PlayerRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("nickName")]
        public string NickName { get; set; }
    }
}
