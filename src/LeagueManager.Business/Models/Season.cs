using System;

using LeagueManager.Database.Models;

namespace LeagueManager.Business.Models
{
    public class Season : IHasId
    {
        public Guid Id { get; set; }

        public Guid LeagueId { get; set; }

        public string Name { get; set; }

        public int SortOrder { get; set; }
    }
}
