namespace LeagueManager.Business.Commands
{
    public interface IDeleteModel<T>
        where T : class
    {
        void Execute(T model);
    }
    
}
