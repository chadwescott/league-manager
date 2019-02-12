using System;

namespace LeagueManager.Business.Commands
{
    public interface IGetModelById<T>
    {
        T Execute(Guid id);
    }
}
