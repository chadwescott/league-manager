using System;

using LeagueManager.Database.Models;

namespace LeagueManager.Business.Models
{
    public class Event : IHasId
    {
        public Guid Id { get; set; }

        public Guid SeasonId { get; set; }

        public string Name { get; set; }

        public DateTime StartTime { get; set; }
    }
}
