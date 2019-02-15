using System;

namespace LeagueManager.Business.Exceptions
{
    public class ModelNotFoundException : Exception
    {
        public ModelNotFoundException(string message)
            : base(message)
        { }
    }
}
