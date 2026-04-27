
using Exam.Models;
using Microsoft.EntityFrameworkCore;


namespace Exams.Data
{
    public class AppDbContext :DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options) 
        { 
        
        }

        public DbSet<Exampaper> exams { get; set; }
    }
}
