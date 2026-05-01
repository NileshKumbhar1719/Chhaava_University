using Microsoft.EntityFrameworkCore;
using Result.Models;

namespace Result.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<StudentResult> Results { get; set; } 
    }
}