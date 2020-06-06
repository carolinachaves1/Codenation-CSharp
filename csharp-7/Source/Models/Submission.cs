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
        public int User_Id { get; set; }
        public int Challenge_Id { get; set; }
        public decimal Score { get; set; }
        public DateTime Created_at { get; set; }

       
    }
}
