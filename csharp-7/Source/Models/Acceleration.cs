using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    [Table("acceleration")]
    public class Acceleration
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name", TypeName = "varchar(200)")]
        public string Name { get; set; }

        [Required]
        [Column("slug", TypeName = "varchar(50)")]
        public string Slug { get; set; }

        [ForeignKey("challenge_id")]
        public Challenge Challenge{ get; set; }
        public Challenge ChallengeId { get; set; }

        [Column("created_at", TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; }
    }
}
