using System;

namespace LeagueManager.Business.Models
{
    public class Game
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public DateTime? StartTime { get; set; }
    }
}
