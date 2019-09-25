using System;

namespace LeagueManager.Database.Commands.Impl
{
    internal class QueryDbContext : SqlCommand, IQueryDbContext
    {
        public QueryDbContext(IContextFactory contextFactory)
            : base(contextFactory)
        { }

        public void Execute(Action<ILeagueManagerContext> action = null)
        {
            if (action != null)
                QueryDatabase(context => action(context));
        }
    }
}
