using System.Data.SqlClient;

namespace LeagueManager.Patterns.Database
{
    public interface ISqlConnectionFactory
    {
        SqlConnection Make();
    }
}
