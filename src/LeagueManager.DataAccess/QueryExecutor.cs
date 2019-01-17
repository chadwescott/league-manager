using LeagueManager.DataAccess.Context;
using LeagueManager.DataAccess.QueryCommands;

namespace LeagueManager.DataAccess
{
    public class QueryExecutor<TContext, TReturn>
        where TContext : IDbContext
    {
        private readonly IContextFactory<TContext> _factory;
        private readonly IQueryCommand<TReturn> _command;

        public QueryExecutor(IContextFactory<TContext> factory, IQueryCommand<TReturn> command)
        {
            _factory = factory;
            _command = command;
        }

        public TReturn Execute()
        {
            using (var context = _factory.CreateContext())
            {
                return _command.Execute(context);
            }
        }
    }
}
