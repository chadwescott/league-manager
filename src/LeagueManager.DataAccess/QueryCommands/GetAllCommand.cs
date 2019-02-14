using System.Collections.Generic;
using LeagueManager.DataAccess.Repository;

namespace LeagueManager.DataAccess.QueryCommands
{
    public class GetAllCommand<TEntity> : QueryCommand<TEntity, IEnumerable<TEntity>>
    {
        public GetAllCommand(IRepositoryFactory<TEntity> factory)
            : base(factory)
        { }

        protected override IEnumerable<TEntity> Execute(IRepository<TEntity> repository, List<string> includes = null)
        {
            return repository.GetAll(includes);
        }
    }
}
