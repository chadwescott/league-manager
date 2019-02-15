namespace LeagueManager.Business.Commands
{
    public interface IGetModels<T>
    {
        T[] Execute();
    }
}
