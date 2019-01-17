using LeagueManager.DataAccess.Context;
using LeagueManager.DataAccess.Repository;

namespace LeagueManager.DataAccess.PersistCommands
{
    public class DeleteCommand<TContext, TEntity> : PersistCommand<TContext, TEntity>
        where TContext : IDbContext
        where TEntity : class
    {
        public DeleteCommand(IRepositoryFactory<TEntity> factory, TEntity model)
            : base(factory, model)
        { }

        protected override void Execute(IRepository<TEntity> repository)
        {
            repository.Delete(Model);
        }
    }
}
