using System;
using System.Data.SqlClient;

namespace LeagueManager.Patterns.Database
{
    public class SqlCommandExecuter
    {
        protected readonly ISqlConnectionFactory SqlConnectionFactory;

        protected log4net.ILog Logger =
               log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SqlCommandExecuter(ISqlConnectionFactory sqlConnectionFactory)
        {
            SqlConnectionFactory = sqlConnectionFactory;
        }

        public virtual void Execute(SqlCommandSpec commandSpec)
        {
            using (var connection = SqlConnectionFactory.Make())
            {
                connection.Open();
                Execute(connection, commandSpec);
            }
        }

        protected void Execute(SqlConnection connection, SqlCommandSpec commandSpec)
        {
            OnBeforeExecute(commandSpec);
            using (var sqlCommand = new SqlCommand { Connection = connection })
            {
                try
                {
                    sqlCommand.CommandType = commandSpec.CommandType;
                    sqlCommand.CommandText = commandSpec.CommandText;
                    foreach (var parameter in commandSpec.CommandParameters)
                        sqlCommand.Parameters.Add(parameter);
                    commandSpec.ExecuteCommand(sqlCommand);
                }
                catch (Exception ex)
                {
                    HandleException(commandSpec, ex);
                }

            }
            OnAfterExecute(commandSpec);
        }

        protected virtual void OnBeforeExecute(SqlCommandSpec commandSpec)
        {
            Logger.Debug($"{commandSpec.GetType()} Execute Start");
        }

        protected virtual void OnAfterExecute(SqlCommandSpec commandSpec)
        {
            Logger.Debug($"{commandSpec.GetType()} Execute Complete");
        }

        protected virtual void HandleException(SqlCommandSpec commandSpec, Exception ex)
        {
            Logger.Error($"{commandSpec.GetType()} Exception: {ex.Message}", ex);
            throw ex;
        }
    }
}
