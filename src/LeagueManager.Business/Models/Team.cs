using System;

using LeagueManager.Database.Models;

namespace LeagueManager.Business.Models
{
    public class Team : IHasId
    {
        public Guid Id { get; set; }

        public Guid EventId { get; set; }

        public string Name { get; set; }

        public int TeamNumber { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public Player[] Players { get; set; }
    }
}
