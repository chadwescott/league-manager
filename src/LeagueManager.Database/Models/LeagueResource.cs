using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueManager.Database.Models
{
    [Table("Leagues")]
    public class LeagueResource : IHasId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey("LeagueId")]
        public IEnumerable<SeasonResource> Seasons { get; set; }
    }
}
