using LeagueManager.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace LeagueManager.Database
{
    public interface ILeagueManagerContext : IDbContext
    {
        DbSet<EventResource> Events { get; set; }

        DbSet<GameResource> Games { get; set; }

        DbSet<GameTeamXrefResource> GameTeams { get; set; }

        DbSet<GameTeamDecimalStatisticsResource> GameTeamDecimalStatistics { get; set; }

        DbSet<GameTeamIntegerStatisticsResource> GameTeamIntegerStatistics { get; set; }

        DbSet<GameTeamTimeStatisticsResource> GameTeamTimeStatistics { get; set; }

        DbSet<GameTypeResource> GameTypes { get; set; }

        DbSet<LeagueResource> Leagues { get; set; }

        DbSet<PlayerResource> Players { get; set; }

        DbSet<SeasonResource> Seasons { get; set; }

        DbSet<SeasonTeamXrefResource> SeasonTeams { get; set; }

        DbSet<ScoreSystemResource> ScoreSystems { get; set; }

        DbSet<TeamResource> Teams { get; set; }

        DbSet<TeamPlayerXrefResource> TeamPlayers { get; set; }
    }
}
