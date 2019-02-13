namespace LeagueManager.Database
{
    internal interface IContextFactory
    {
        ILeagueManagerContext Make();
    }
}
