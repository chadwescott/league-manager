using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LeagueManager.Patterns.Database
{
    public abstract class SqlCommandSpec<T>
    {
        public T Result { get; protected set; }

        public abstract CommandType CommandType { get; }

        public abstract string CommandText { get; }

        public IEnumerable<SqlParameter> CommandParameters { get; protected set; }

        public virtual void ExecuteCommand(SqlCommand command)
        {
            command.ExecuteNonQuery();
        }
    }
}
