using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using LeagueManager.DataAccess;

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
        public string Name { get; set; }

        [Column("StartTime")]
        public DateTime StartTime { get; set; }
    }
}
