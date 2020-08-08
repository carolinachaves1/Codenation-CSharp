using System.Collections.Generic;

namespace CentralDeErros.DataLayer.Models
{
    public class Environment
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Error> Errors { get; set; }
    }
}
