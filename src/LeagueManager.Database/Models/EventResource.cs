using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueManager.Database.Models
{
    [Table("Events")]
    public class EventResource : IHasId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("SeasonId")]
        public Guid SeasonId { get; set; }

        [Column("Name")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Column("StartTime")]
        public DateTime StartTime { get; set; }

        public IEnumerable<GameResource> Games { get; set; }
    }
}
