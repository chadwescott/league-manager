
using LeagueManager.DataAccess.Context;
using LeagueManager.Database.Models;

using Microsoft.EntityFrameworkCore;

namespace LeagueManager.Database
{
    internal interface ILeagueManagerContext : IDbContext
    {
        DbSet<PlayerResource> Players { get; set;  }
    }
}
