using System;

using LeagueManager.DataAccess;

namespace LeagueManager.Business.Models
{
    public class Player : IHasId
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public string Email { get; set; }
    }
}
