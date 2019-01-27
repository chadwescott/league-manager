using System;
using Newtonsoft.Json;

namespace LeagueManager.Domain.Responses
{
    public class SeasonResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("links")]
        public LinkResponse[] Links { get; set; }
    }
}
