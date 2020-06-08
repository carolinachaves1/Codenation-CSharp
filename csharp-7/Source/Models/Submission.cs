using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    public class Submission
    {
        public int UserId { get; set; }
        public int ChallengeId { get; set; }
        public DateTime CreatedAt { get; set; }


        public User User { get; set; }
        public Challenge Challenge { get; set; }
    }
}
