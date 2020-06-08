using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("submission")]
    public class Submission
    {
        [Required, Column("user_id")]
        public int UserId { get; set; }

        [Required, Column("challenge_id")]
        public int ChallengeId { get; set; }

        [Required, Column("score", TypeName ="decimal(9,2)")]
        public decimal Score { get; set; }

        [Required, Column("created_at", TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; }


        public User User { get; set; }
        public Challenge Challenge { get; set; }
    }
}
