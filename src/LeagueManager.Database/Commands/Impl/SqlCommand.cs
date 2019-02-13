using System;

namespace LeagueManager.Database.Commands.Impl
{
    internal abstract class SqlCommand
    {
        private readonly IContextFactory _contextFactory;

        public SqlCommand(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        protected void QueryDatabase(Action<ILeagueManagerContext> action)
        {
            using (var context = _contextFactory.Make())
                action(context);
        }
    }
}
