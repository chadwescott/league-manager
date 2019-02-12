using System;

using Newtonsoft.Json;

namespace LeagueManager.Domain.Requests
{
    public class SeasonRequest
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("leagueId")]
        public Guid LeagueId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sortOrder")]
        public int SortOrder { get; set; }
    }
}
