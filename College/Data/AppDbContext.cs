using College.Models;
using Microsoft.EntityFrameworkCore;

namespace College.Data
{
    public class AppDbContext :DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) 
        {
        
        }

        public DbSet<Colleges> Colleges { get; set; }
    }
}
