using System;

using Newtonsoft.Json;

namespace LeagueManager.Domain.Responses
{
    public class TeamResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("teamNumber")]
        public int TeamNumber { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }

        [JsonProperty("links")]
        public LinkResponse[] Links { get; set; }
    }
}
