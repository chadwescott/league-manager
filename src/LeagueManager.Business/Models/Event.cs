using System;

using LeagueManager.DataAccess;

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
