using System;
using System.Collections.Generic;

namespace LeagueManager.Patterns.Database
{
    public class TransactionExecuter : SqlCommandExecuter
    {
        public TransactionExecuter(ISqlConnectionFactory sqlConnectionFactory)
            : base(sqlConnectionFactory)
        { }

        public void Execute(IEnumerable<SqlCommandSpec> commands, bool commit = true)
        {
            using (var connection = SqlConnectionFactory.Make())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var command in commands)
                            Execute(connection, command);
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }

                    if (commit)
                        transaction.Commit();
                    else
                        transaction.Rollback();
                }
            }
        }
    }
}
