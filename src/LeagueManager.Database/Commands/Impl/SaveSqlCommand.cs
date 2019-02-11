using LeagueManager.DataAccess;
using LeagueManager.DataAccess.Commands;
using LeagueManager.DataAccess.Context;

namespace LeagueManager.Database.Commands.Impl
{
    internal class SaveSqlCommand<T> : RepositorySave<T>, ISaveSqlCommand<T>
        where T : class, IHasId
    {
        public SaveSqlCommand(IContextFactory<IDbContext> contextFactory)
            : base(contextFactory)
        { }
    }
}
