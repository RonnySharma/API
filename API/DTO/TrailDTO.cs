using API.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTO
{
    public class TrailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Distance { get; set; }
        public string Elevation { get; set; }
        public DateTime DateCreated { get; set; }
        //public enum DiffcultyType { Easy, Moderate, Difficult }
        // public Dif Diffculty { get; set; }
        public int NationalParkId { get; set; }
        public NationalPark? NationalPark { get; set; }
    }
}
