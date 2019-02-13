using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueManager.Database.Models
{
    [Table("Teams")]
    public class TeamResource : IHasId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("EventId")]
        public Guid EventId { get; set; }

        [Column("Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column("TeamNumber")]
        public int TeamNumber { get; set; }

        [Column("Wins")]
        public int Wins { get; set; }

        [Column("Losses")]
        public int Losses { get; set; }

        public List<TeamPlayerXrefResource> TeamPlayers { get; set; }
    }
}
