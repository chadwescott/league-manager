using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace LeagueManager.Domain.Requests
{
    public class PlayerRequest
    {
        [JsonProperty("email")]
        [MaxLength(255)]
        public string Email { get; set; }

        [JsonProperty("firstName")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [JsonProperty("nickName")]
        [MaxLength(50)]
        public string NickName { get; set; }
    }
}
