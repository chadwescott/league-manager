using System;
using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace LeagueManager.Domain.Requests
{
    public class TeamRequest
    {
        [JsonProperty("eventId")]
        public Guid EventId { get; set; }

        [JsonProperty("name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [JsonProperty("teamNumber")]
        public int TeamNumber { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }
    }
}
