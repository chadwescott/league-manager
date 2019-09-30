using System;

using Newtonsoft.Json;

namespace LeagueManager.Domain.Responses
{
    public class GameTypeResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("minimumTeams")]
        public int MinimumTeams { get; set; }

        [JsonProperty("maximumTeams")]
        public int MaximumTeams { get; set; }

        [JsonProperty("minimumTeamSize")]
        public int MinimumTeamSize { get; set; }

        [JsonProperty("maximumTeamSize")]
        public int MaximumTeamSize { get; set; }

        [JsonProperty("links")]
        public LinkResponse[] Links { get; set; }
    }
}
