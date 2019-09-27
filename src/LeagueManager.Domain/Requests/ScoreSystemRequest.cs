using Newtonsoft.Json;

namespace LeagueManager.Domain.Requests
{
    public class ScoreSystemRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
