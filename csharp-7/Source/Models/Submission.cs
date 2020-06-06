using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    [Table("submission")]
    public class Submission
    {

        [ForeignKey("user_id")]
        [Column("user_id")]
        public User User { get; set; }
        public User UserId { get; set; }

        [ForeignKey("challenge_id")]
        [Column("challenge_id")]
        public Challenge Challenge { get; set; }
        public Challenge ChallengeId { get; set; }

        [Required]
        [Column("email", TypeName = "decimal(9,2)")]
        public float Score { get; set; }

        [Column("created_at", TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; }


    }
}
