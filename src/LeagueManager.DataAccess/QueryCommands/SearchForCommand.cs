using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using LeagueManager.DataAccess.Repository;

namespace LeagueManager.DataAccess.QueryCommands
{
    public class SearchForCommand<TEntity> : QueryCommand<TEntity, IEnumerable<TEntity>>
    {
        private Expression<Func<TEntity, bool>> WherePredicate { get; set; }

        public SearchForCommand(IRepositoryFactory<TEntity> factory, Expression<Func<TEntity, bool>> wherePredicate)
            : base(factory)
        {
            WherePredicate = wherePredicate ?? throw new ArgumentNullException("wherePredicate");
        }

        protected override IEnumerable<TEntity> Execute(IRepository<TEntity> repository, List<string> includes = null)
        {
            return repository.SearchFor(WherePredicate, includes).ToList();
        }
    }
}
