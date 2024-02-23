using System.ComponentModel.DataAnnotations;

namespace Api_project.Models
{
    public class NationalPark
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string State { get; set; }
        public byte[]? Picture { get; set; }
        public DateTime Create { get; set; }
        public DateTime Estabished { get; set; }
    }
}
