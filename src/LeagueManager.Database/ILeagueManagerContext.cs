using System;

using LeagueManager.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace LeagueManager.Database
{
    public interface ILeagueManagerContext : IDbContext
    {
        DbSet<EventResource> Events { get; set; }

        DbSet<GameResource> Games { get; set; }

        DbSet<GameTeamXrefResource> GameTeams { get; set; }

        DbSet<LeagueResource> Leagues { get; set; }

        DbSet<PlayerResource> Players { get; set; }

        DbSet<SeasonResource> Seasons { get; set; }

        DbSet<SeasonTeamXrefResource> SeasonTeams { get; set; }

        DbSet<TeamResource> Teams { get; set; }

        DbSet<TeamPlayerXrefResource> TeamPlayers { get; set; }
    }
}
