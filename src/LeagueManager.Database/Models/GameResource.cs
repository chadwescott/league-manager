using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueManager.Database.Models
{
    [Table("Games")]
    public class GameResource : IHasId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("GameTypeId")]
        public Guid GameTypeId { get; set; }

        [Column("EventId")]
        public Guid EventId { get; set; }

        [Column("Number")]
        public int Number { get; set; }

        [Column("StartTime")]
        public DateTime? StartTime { get; set; }

        [Column("Complete")]
        public bool Complete { get; set; }

        [ForeignKey("GameTypeId")]
        public GameTypeResource GameType { get; set; }

        [ForeignKey("EventId")]
        public EventResource Event { get; set; }

        public List<GameTeamXrefResource> GameTeams { get; set; }
    }
}
