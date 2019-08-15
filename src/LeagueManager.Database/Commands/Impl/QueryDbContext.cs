using System;

namespace LeagueManager.Database.Commands.Impl
{
    internal class GetWithDbContext<T> : SqlCommand, IQueryDbContext<T>
        where T: IDbContext
    {
        public GetWithDbContext(IContextFactory contextFactory)
            : base(contextFactory)
        { }

        public void Execute(Action<ILeagueManagerContext> action = null)
        {
            if (action != null)
                QueryDatabase(context => action(context));
        }
    }
}
