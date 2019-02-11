using System;

namespace LeagueManager.Business.Models
{
    public class Event
    {
        public Guid Id { get; set; }

        public Guid SeasonId { get; set; }

        public string Name { get; set; }

        public DateTime StartTime { get; set; }
    }
}
