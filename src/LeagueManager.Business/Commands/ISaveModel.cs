namespace LeagueManager.Business.Commands
{
    public interface ISaveModel<T>
        where T : class
    {
        T Execute(T model);
    }
}
