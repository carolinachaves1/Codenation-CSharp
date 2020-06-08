using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    public class Submission
    {
        public User UserId { get; set; }
        public Challenge ChallengeId { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
