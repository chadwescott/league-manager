using System;

namespace LeagueManager.Business.Models
{
    public class Statistic<T>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public T Value { get; set; }
    }
}
