using System;

using Newtonsoft.Json;

namespace LeagueManager.Domain.Requests
{
    public class GameRequest
    {
        [JsonProperty("id")]
        public Guid Id  { get; set; }

        [JsonProperty("teamIds")]
        public Guid[] TeamIds  { get; set; }

        [JsonProperty("startTime")]
        public DateTime? StartTime { get; set; }
    }
}
