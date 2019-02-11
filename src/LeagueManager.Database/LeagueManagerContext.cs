
using LeagueManager.DataAccess.Context;
using LeagueManager.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace LeagueManager.Database
{
    internal class LeagueManagerContext : BaseDbContext, ILeagueManagerContext
    {
        public LeagueManagerContext(string connectionString)
            : base(connectionString)
        { }

        public DbSet<EventResource> Events { get; set;  }

        public DbSet<PlayerResource> Players { get; set; }
    }
}
