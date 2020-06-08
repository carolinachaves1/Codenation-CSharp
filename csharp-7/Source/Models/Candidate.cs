using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Codenation.Challenge.Models
{
    [Table("candidate")]
    public class Candidate
    {
        [Required, Column("user_id")]
        public int UserId { get; set; }

        [Required, Column("acceleration_id")]
        public int AccelerationId { get; set; }

        [Required, Column("company_id")]
        public int CompanyId { get; set; }

        [Required, Column("status")]
        public int Status { get; set; }

        [Required, Column("created_at", TypeName="timestamp")]
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
        public Acceleration Acceleration { get; set; }
        public Company Company { get; set; }
    }
}