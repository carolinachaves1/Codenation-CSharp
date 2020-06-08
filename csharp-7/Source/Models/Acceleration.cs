using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("acceleration")]
    public class Acceleration
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Required, Column("challenge_id")]
        public int ChallengeId { get; set; }

        [Required, Column("name"), MaxLength(100)]
        public string Name { get; set; }

        [Required, Column("slug"), MaxLength(50)]
        public string Slug { get; set; }

        [Required, Column("created_at", TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; }


        public Challenge Challenge { get; set; }
        public ICollection<Candidate> Candidates { get; set; }
    }
}