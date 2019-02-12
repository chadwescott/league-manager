using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using LeagueManager.DataAccess;

namespace LeagueManager.Database.Models
{
    [Table("Seasons")]
    public class SeasonResource : IHasId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("LeagueId")]
        public Guid LeagueId { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("SortOrder")]
        public int SortOrder { get; set; }
    }
}
