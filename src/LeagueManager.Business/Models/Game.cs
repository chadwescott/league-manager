using System;

using LeagueManager.Database.Models;

namespace LeagueManager.Business.Models
{
    public class Game : IHasId
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public DateTime? StartTime { get; set; }

        public Guid[] TeamIds { get; set; }
    }
}
