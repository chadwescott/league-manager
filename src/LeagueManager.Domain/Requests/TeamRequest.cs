using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace LeagueManager.Domain.Requests
{
    public class TeamRequest
    {
        [JsonProperty("name")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
