namespace LeagueManager.DataAccess.Context
{
    public interface IContextFactory<out T>
    {
        T CreateContext();
    }
}