using System;

using LeagueManager.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace LeagueManager.Database
{
    internal interface ILeagueManagerContext : IDbContext
    {
        DbSet<EventResource> Events { get; set; }

        DbSet<LeagueResource> Leagues { get; set; }

        DbSet<PlayerResource> Players { get; set; }

        DbSet<SeasonResource> Seasons { get; set; }

        DbSet<TeamResource> Teams { get; set; }

        DbSet<TeamPlayerXrefResource> TeamPlayers { get; set; }
    }
}
