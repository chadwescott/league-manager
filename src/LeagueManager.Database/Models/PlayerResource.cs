using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using LeagueManager.DataAccess;

namespace LeagueManager.Database.Models
{
    [Table("Players")]
    public class PlayerResource : IHasId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("NickName")]
        public string NickName { get; set; }

        [Column("Email")]
        public string Email { get; set; }
    }
}
