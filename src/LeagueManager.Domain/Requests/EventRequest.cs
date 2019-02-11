using System;

using Newtonsoft.Json;

namespace LeagueManager.Domain.Requests
{
    public class EventRequest
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("seasonId")]
        public Guid SeasonId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("startTime")]
        public DateTime StartTime { get; set; }
    }
}
