using System;

using Newtonsoft.Json;

namespace LeagueManager.Domain.Requests
{
    public class GameRequest
    {
        [JsonProperty("gameTypeId")]
        public Guid GameTypeId  { get; set; }

        [JsonProperty("teamIds")]
        public Guid[] TeamIds  { get; set; }

        [JsonProperty("startTime")]
        public DateTime? StartTime { get; set; }
    }
}
