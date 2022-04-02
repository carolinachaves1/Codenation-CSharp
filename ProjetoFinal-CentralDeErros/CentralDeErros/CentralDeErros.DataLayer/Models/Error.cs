using System;

namespace CentralDeErros.DataLayer.Models
{
    public class Error
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int EnvironmentId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Level Level { get; set; }
        public Environment Environment { get; set; }
    }
}
