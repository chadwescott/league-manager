using System;
using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace LeagueManager.Domain.Requests
{
    public class SeasonRequest
    {
        [JsonProperty("leagueId")]
        public Guid LeagueId { get; set; }

        [JsonProperty("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [JsonProperty("sortOrder")]
        public int SortOrder { get; set; }
    }
}
