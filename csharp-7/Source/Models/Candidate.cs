using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    [Table("candidate")]
    public class Candidate
    {
        [ForeignKey("user_id")]
        public int MyProperty { get; set; }
    }
}
