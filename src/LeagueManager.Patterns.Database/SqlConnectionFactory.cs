using System.Data.SqlClient;

namespace LeagueManager.Patterns.Database
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection Make()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
