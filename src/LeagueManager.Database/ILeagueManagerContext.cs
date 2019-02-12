
using LeagueManager.DataAccess.Context;
using LeagueManager.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace LeagueManager.Database
{
    internal interface ILeagueManagerContext : IDbContext
    {
        DbSet<EventResource> Events { get; set; }

        DbSet<PlayerResource> Players { get; set; }

        DbSet<SeasonResource> Seasons { get; set; }
    }
}
