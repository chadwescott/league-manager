using LeagueManager.DataAccess.Context;

namespace LeagueManager.DataAccess.Commands
{
    public abstract class RepositoryCommand
    {
        protected RepositoryCommand(IContextFactory<IDbContext> contextFactory)
        {
            ContextFactory = contextFactory;
        }

        protected readonly IContextFactory<IDbContext> ContextFactory;
    }
}
