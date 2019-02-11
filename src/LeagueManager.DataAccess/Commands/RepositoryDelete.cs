using LeagueManager.DataAccess.Context;

namespace LeagueManager.DataAccess.Commands
{
    public abstract class RepositoryDelete<T> : RepositoryChange<T> where T : class, IHasId
    {
        protected RepositoryDelete(IContextFactory<IDbContext> contextFactory)
            : base(contextFactory)
        { }

        public void Execute(T resource)
        {
            InvokeRepositoryAndSave(repository =>
            {
                repository.Delete(resource);
            });
        }
    }
}
