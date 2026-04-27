
using Exam.Models;
using Exams.Data;
using Microsoft.EntityFrameworkCore;

namespace Exams.Repository
{
    public class ExamRepository : IExamRepository
    {
        private readonly AppDbContext _App;

        public ExamRepository(AppDbContext appDbContext) 
        {
          _App=appDbContext;
        }
        public async Task<Exampaper> CreateAsync(Exampaper exampaper)
        {
              await _App.exams.AddAsync(exampaper);
            await _App.SaveChangesAsync();
            return exampaper;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = await _App.exams.FindAsync(id);
            if (data == null)
            {
                return false;
            }
             _App.exams.Remove(data);
            await _App.SaveChangesAsync();
            return true;
        }

        public async Task<List<Exampaper>> GetAllExamsAsync()
        {
            var data = await _App.exams.ToListAsync();
             return data;
        }

        public async Task<Exampaper> GetByIdAsync(int id)
        {
            var data = await _App.exams.FindAsync(id);
            if (data == null)
            {
                return null;
            }
            return data;
               
        }

        public async Task<Exampaper> UpdateAsync(Exampaper exampaper, int id)
        {
            var data = await _App.exams.FindAsync(id);
            if(data == null)
            {
                return null;
            }

            data.Name = exampaper.Name;
            data.Date = exampaper.Date;
            data.CourseId = exampaper.CourseId;

            await _App.SaveChangesAsync();
            return data;
        }
    }
}
