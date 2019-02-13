using System;
using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace LeagueManager.Domain.Requests
{
    public class LeagueRequest
    {
        [JsonProperty("name")]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
