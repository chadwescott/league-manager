using LeagueManager.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace LeagueManager.Database
{
    internal class LeagueManagerContext : DbContext, ILeagueManagerContext
    {
        private readonly string _connectionString;

        public LeagueManagerContext(string connectionString)
            : base()
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public void SetEntityState<TEntity>(TEntity entity, EntityState state) where TEntity : class
        {
            Entry(entity).State = state;
        }

        public DbSet<EventResource> Events { get; set;  }

        public DbSet<GameResource> Games { get; set; }

        public DbSet<GameTeamXrefResource> GameTeams { get; set; }

        public DbSet<GameTeamDecimalStatisticsResource> GameTeamDecimalStatistics { get; set; }

        public DbSet<GameTeamIntegerStatisticsResource> GameTeamIntegerStatistics { get; set; }

        public DbSet<GameTeamTimeStatisticsResource> GameTeamTimeStatistics { get; set; }

        public DbSet<GameTypeResource> GameTypes { get; set; }

        public DbSet<LeagueResource> Leagues { get; set; }

        public DbSet<PlayerResource> Players { get; set; }

        public DbSet<SeasonResource> Seasons { get; set; }

        public DbSet<SeasonTeamXrefResource> SeasonTeams { get; set; }

        public DbSet<ScoreSystemResource> ScoreSystems { get; set; }

        public DbSet<TeamPlayerXrefResource> TeamPlayers { get; set; }

        public DbSet<TeamResource> Teams { get; set; }
    }
}
