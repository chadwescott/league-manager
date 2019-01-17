using LeagueManager.DataAccess.Context;
using LeagueManager.DataAccess.Repository;

namespace LeagueManager.DataAccess.PersistCommands
{
    public abstract class PersistCommand<TContext, TEntity> : IPersistCommand<TContext>
        where TContext : IDbContext
        where TEntity : class
    {
        private readonly IRepositoryFactory<TEntity> _factory;
 
        protected TEntity Model;

        protected PersistCommand(IRepositoryFactory<TEntity> factory, TEntity model)
        {
            _factory = factory;
            Model = model;
        }

        public void Execute(TContext context)
        {
            var repository = _factory.CreateRepository(context);
            Execute(repository);
        }

        protected abstract void Execute(IRepository<TEntity> repository);
    }
}
