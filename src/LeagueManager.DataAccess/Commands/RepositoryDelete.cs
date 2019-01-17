using LeagueManager.DataAccess.Context;

namespace LeagueManager.DataAccess.Commands
{
    public abstract class RepositoryDelete<T> : RepositoryChange<T> where T : class, IHasId
    {
        protected RepositoryDelete(IContextFactory<IDbContext> contextFactory, T model)
            : base(contextFactory, model)
        { }

        public override void Execute()
        {
            InvokeRepositoryAndSave(repository =>
            {
                repository.Delete(Result);
            });
        }
    }
}
