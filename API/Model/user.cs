using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    public class user
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Rols { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
