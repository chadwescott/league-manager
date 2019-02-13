using System;
using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace LeagueManager.Domain.Requests
{
    public class EventRequest
    {
        [JsonProperty("seasonId")]
        public Guid SeasonId { get; set; }

        [JsonProperty("name")]
        [MaxLength(200)]
        public string Name { get; set; }

        [JsonProperty("startTime")]
        public DateTime StartTime { get; set; }
    }
}
