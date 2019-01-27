using LeagueManager.DataAccess.Context;
using LeagueManager.Database.Models;

namespace LeagueManager.Database.Commands.Impl
{
    internal class SavePlayerSqlCommand : ISavePlayerSqlCommand
    {
        private readonly IContextFactory<IDbContext> _contextFactory;

        public SavePlayerSqlCommand(IContextFactory<IDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void Execute(PlayerResource resource)
        {
            var command = new PlayerSaveCommand(_contextFactory, resource);
            command.Execute();
        }
    }
}
