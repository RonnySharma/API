using API.Model;
using Microsoft.EntityFrameworkCore;
//      using Microsoft.EntityFrameworkCore;

namespace API.ApplicationDbContext
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {
                
        }
        public DbSet<NationalPark> NationalParks { get; set; }
        public DbSet<Trail> Trails { get; set; }
        public DbSet<user> Users { get; set; }
        
    }
}
