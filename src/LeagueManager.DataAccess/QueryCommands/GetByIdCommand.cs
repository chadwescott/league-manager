using System.Collections.Generic;
using LeagueManager.DataAccess.Repository;

namespace LeagueManager.DataAccess.QueryCommands
{
    public class GetByIdCommand<TEntity> : QueryCommand<TEntity, TEntity>
    {
        private readonly int _id;

        public GetByIdCommand(IRepositoryFactory<TEntity> factory, int id)
            : base(factory)
        {
            _id = id;
        }

        protected override TEntity Execute(IRepository<TEntity> repository, List<string> includes = null)
        {
            return repository.GetById(_id, includes);
        }
    }
}
