using Codenation.Challenge.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    [Table("candidate")]
    public class Candidate
    {
        [ForeignKey("user_id")]
        public User User { get; set; }
        public User UserId { get; set; }

        [ForeignKey("acceleration_id")]
        public Acceleration Acceleration { get; set; }
        public Acceleration AccelerationId { get; set; }

        [ForeignKey("company_id")]
        public Company Company { get; set; }
        public Company CompanyId { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

    }
}
