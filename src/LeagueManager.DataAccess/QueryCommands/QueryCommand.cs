using System.Collections.Generic;
using LeagueManager.DataAccess.Context;
using LeagueManager.DataAccess.Repository;

namespace LeagueManager.DataAccess.QueryCommands
{
    public abstract class QueryCommand<TEntity, TReturn> : IQueryCommand<TReturn>
    {
        private readonly IRepositoryFactory<TEntity> _factory;

        protected QueryCommand(IRepositoryFactory<TEntity> factory)
        {
            _factory = factory;
        }

        public TReturn Execute(IDbContext context, List<string> includes = null)
        {
            var repository = _factory.CreateRepository(context);
            return Execute(repository, includes);
        }

        protected abstract TReturn Execute(IRepository<TEntity> repository, List<string> includes = null);

    }
}
