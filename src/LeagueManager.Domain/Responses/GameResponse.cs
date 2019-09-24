using System;

using Newtonsoft.Json;

namespace LeagueManager.Domain.Responses
{
    public class GameResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("startTime")]
        public DateTime? StartTime { get; set; }

        [JsonProperty("links")]
        public LinkResponse[] Links { get; set; }
    }
}
