using System;

namespace LeagueManager.Business.Models
{
    public class GameTeamStatistics
    {
        public Guid Id { get; set; }

        public Guid GameId { get; set; }

        public Guid TeamId { get; set; }

        public Statistic<int>[] IntegerStatistics { get; set; }

        public Statistic<decimal>[] DecimalStatistics { get; set; }

        public Statistic<TimeSpan>[] TimeStatistics { get; set; }
    }
}
