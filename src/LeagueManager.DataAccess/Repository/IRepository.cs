using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LeagueManager.DataAccess.Repository
{
    public interface IRepository<T>
    {
        Exception Error { get; }

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate, List<String> includes = null);

        IQueryable<T> GetAll();

        T GetById<K>(K id);

        bool IsReadOnly { get; }
    }
}
