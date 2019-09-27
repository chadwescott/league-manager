using System;

namespace LeagueManager.Business.Models
{
    public class GameType
    {
        public Guid Id { get; set; }

        public Guid ScoreSystemId { get; set; }

        public string Name { get; set; }

        public int MinimumTeams { get; set; }

        public int MaximumTeams { get; set; }

        public int MinimumTeamSize { get; set; }

        public int MaximumTeamSize { get; set; }
    }
}
