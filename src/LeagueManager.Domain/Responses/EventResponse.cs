using System;

using Newtonsoft.Json;

namespace LeagueManager.Domain.Responses
{
    public class EventResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("startTime")]
        public DateTime StartTime { get; set; }

        [JsonProperty("links")]
        public LinkResponse[] Links { get; set; }
    }
}
