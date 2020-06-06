using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("full_name", TypeName = "varchar(100)")]
        public string FullName { get; set; }

        [Required]
        [Column("email", TypeName = "varchar(200)")]
        public string Email { get; set; }

        [Required]
        [Column("nickname", TypeName = "varchar(50)")]
        public string Nickname { get; set; }

        [Required]
        [Column("password", TypeName = "varchar(255)")]
        public string Password { get; set; }

        [Column("created_at", TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; }


    }
}
