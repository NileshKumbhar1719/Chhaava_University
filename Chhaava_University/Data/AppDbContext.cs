using Chhaava_University.Models;
using Microsoft.EntityFrameworkCore;

namespace Chhaava_University.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        DbSet<University> universities { get; set; }
    }
}
