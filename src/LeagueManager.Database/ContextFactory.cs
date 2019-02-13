namespace LeagueManager.Database
{
    internal class ContextFactory : IContextFactory
    {
        private readonly string _connectionString;
        
        public ContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ILeagueManagerContext Make()
        {
            return new LeagueManagerContext(_connectionString);
        }
    }
}
