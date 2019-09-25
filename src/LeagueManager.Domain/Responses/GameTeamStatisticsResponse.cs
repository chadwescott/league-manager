using System;

using Newtonsoft.Json;

namespace LeagueManager.Domain.Responses
{
    public class GameTeamStatisticsResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("gameId")]
        public Guid GameId { get; set; }

        [JsonProperty("teamId")]
        public Guid TeamId { get; set; }

        [JsonProperty("integerStatistics")]
        public StatisticResponse<int>[] IntegerStatistics { get; set; }

        [JsonProperty("decimalStatistics")]
        public StatisticResponse<decimal>[] DecimalStatistics { get; set; }

        [JsonProperty("timeStatistics")]
        public StatisticResponse<TimeSpan>[] TimeStatistics { get; set; }
    }
}
