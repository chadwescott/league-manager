using System;
using System.Linq;
using System.Reflection;

namespace LeagueManager.DataAccess.Context
{
    public class ContextFactory<T> : IContextFactory<T> where T : IDbContext
    {
        private readonly int _minimumCommandTimeout;

        private readonly string _connectionString;

        public ContextFactory(string connectionString = null, int minCommandTimeout = -1)
        {
            _connectionString = connectionString;
            _minimumCommandTimeout = minCommandTimeout;
        }

        public T CreateContext()
        {
            var typeAssembly = Assembly.GetAssembly(typeof(T));
            var contextType = typeAssembly.GetTypes().Single(w => w.GetInterfaces().Contains(typeof(T)));

            return (T)Activator.CreateInstance(contextType, _connectionString);
        }
    }
}
