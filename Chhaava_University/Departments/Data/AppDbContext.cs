using Departments.Models;
using Microsoft.EntityFrameworkCore;

namespace Departments.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Department> Departments { get; set; }
        

        
    }
}
