using System;

using Newtonsoft.Json;

namespace LeagueManager.Domain.Responses
{
    public class StatisticResponse<T>
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public T Value { get; set; }
    }
}
