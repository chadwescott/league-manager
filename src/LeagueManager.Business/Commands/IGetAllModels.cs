namespace LeagueManager.Business.Commands
{
    public interface IGetAllModels<T>
    {
        T[] Execute();
    }
}
