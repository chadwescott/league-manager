using System;

using LeagueManager.DataAccess.Context;
using LeagueManager.DataAccess.PersistCommands;

using log4net;

namespace LeagueManager.DataAccess
{
    public class UnitOfWork<TContext>
        where TContext : IDbContext
    {
        private readonly IContextFactory<TContext> _factory;
        private readonly IPersistCommand<TContext>[] _commands;

        private static readonly ILog Log =
               LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UnitOfWork(IContextFactory<TContext> factory, IPersistCommand<TContext>[] commands)
        {
            _factory = factory;
            _commands = commands;
        }

        public bool Execute()
        {
            try
            {
                using (var context = _factory.CreateContext())
                {
                    foreach (var command in _commands)
                        command.Execute(context);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return false;
            }
        }
    }
}
