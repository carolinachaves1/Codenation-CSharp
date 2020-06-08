using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("user")]
    public class User
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Required, Column("full_name"), MaxLength(100)]
        public string FullName { get; set; }

        [Required, Column("email"), MaxLength(100)]
        public string Email { get; set; }

        [Required, Column("nickname"), MaxLength(50)]
        public string Nickname { get; set; }

        [Required, Column("password"), MaxLength(255)]
        public string Password { get; set; }

        [Required, Column("created_at", TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; }


        public ICollection<Candidate> Candidates { get; set; }
        public ICollection<Submission> Submissions { get; set; }
    }
}
