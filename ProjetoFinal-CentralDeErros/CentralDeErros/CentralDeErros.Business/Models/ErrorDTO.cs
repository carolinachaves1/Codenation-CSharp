
namespace CentralDeErros.Business.Models
{
    public class ErrorDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public string Category { get; set; }
        public string CreatedAt { get; set; }
    }
}
