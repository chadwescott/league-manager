using System;

using LeagueManager.DataAccess.Context;

namespace LeagueManager.DataAccess.Repository
{
    public class ReadOnlyRepository<T> : Repository<T> where T : class
    {
        public override bool IsReadOnly { get { return true; } }

        public ReadOnlyRepository(IDbContext context) : base(context)
        { }

        /// <exception cref="NotSupportedException"></exception>
        public override void Insert(T entity)
        {
            throw new NotSupportedException("This Repository is ReadOnly");
        }

        /// <exception cref="NotSupportedException"></exception>
        public override void Update(T entity)
        {
            throw new NotSupportedException("This Repository is ReadOnly");
        }

        /// <exception cref="NotSupportedException"></exception>
        public override void Delete(T entity)
        {
            throw new NotSupportedException("This Repository is ReadOnly");
        }

    }
}

