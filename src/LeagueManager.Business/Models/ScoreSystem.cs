using System;

using LeagueManager.Database.Models;

namespace LeagueManager.Business.Models
{
    public class ScoreSystem : IHasId
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
