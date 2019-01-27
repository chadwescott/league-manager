using LeagueManager.DataAccess.Commands;
using LeagueManager.DataAccess.Context;
using LeagueManager.Database.Models;

namespace LeagueManager.Database.Commands.Impl
{
    internal class PlayerSaveCommand : RepositorySave<PlayerResource>
    {
        public PlayerSaveCommand(IContextFactory<IDbContext> contextFactory, PlayerResource model)
            : base(contextFactory, model)
        { }
    }
}
