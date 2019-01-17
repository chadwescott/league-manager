using System;
using System.Collections.Generic;
using System.Linq;
using LeagueManager.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace LeagueManager.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T: class
    {
        public Exception Error { get; private set; }

        protected DbSet<T> DbSet { get; private set; }

        protected IDbContext Context { get; private set; }

        public virtual bool IsReadOnly { get { return false; } }

        public Repository(IDbContext context)
        {
            DbSet = context.Set<T>();

            if (DbSet == null)
                throw new NullReferenceException("Type " + typeof(T).ToString() + " doesn't have a matching DbSet");

            Context = context;
        }

        /// <exception cref="ArgumentNullException"></exception>
        public virtual void Insert(T entity)
        {
            SetEntityState(entity, EntityState.Added);
        }

        public virtual void Update(T entity)
        {
            SetEntityState(entity, EntityState.Modified);
        }

        /// <exception cref="ArgumentNullException"></exception>
        public virtual void Delete(T entity)
        {
            SetEntityState(entity, EntityState.Deleted);
        }

        private void SetEntityState(T entity, EntityState state)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            Context.SetEntityState(entity, state);
        }

        public virtual IQueryable<T> SearchFor(System.Linq.Expressions.Expression<Func<T, bool>> predicate, List<String> includes = null)
        {
            var queryable = DbSet.AsQueryable();

            if (includes != null)
                includes.ForEach(inc => queryable.Include(inc));

            return queryable.Where(predicate);
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet.AsQueryable<T>();
        }

        public virtual T GetById<K>(K id) 
        {
            return DbSet.Find(id);
        }
    }
}
