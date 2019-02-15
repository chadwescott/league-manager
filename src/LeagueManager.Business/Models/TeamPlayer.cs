using System;

using LeagueManager.Database.Models;

namespace LeagueManager.Business.Models
{
    public class TeamPlayer : IHasId
    {
        public Guid Id { get; set; }

        public Guid TeamId { get; set; }

        public Guid PlayerId { get; set; }
    }
}
