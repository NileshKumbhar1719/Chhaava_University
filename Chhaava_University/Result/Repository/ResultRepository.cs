using Microsoft.EntityFrameworkCore;
using Result.Data;
using Result.Models;

namespace Result.Repository
{
    public class ResultRepository : IResultRepository
    {
        private readonly AppDbContext _Context;

        public ResultRepository(AppDbContext dbContext)

        {
            _Context = dbContext;
        }
        public async Task<StudentResult> Createbyasync(StudentResult studentResult)
        {
            await _Context.Results.AddAsync(studentResult);
            await _Context.SaveChangesAsync();
            return studentResult;
        }

        public async Task<bool> Deletebyasync(int id)
        {
            var result = await _Context.Results.FindAsync(id);
            if (result == null)
            {
                return false;
            }
            _Context.Results.Remove(result);
            await _Context.SaveChangesAsync();
            return true;



        }

        public async Task<List<StudentResult>> GetAllasync()
        {
            var data = await _Context.Results.ToListAsync();
            return data;
        }

        public async Task<StudentResult> GetByIdasync(int id)
        {
            var result = await _Context.Results.FindAsync(id);
            if (result == null)
            {
                return null;
            }

            return result;

        }

        public async Task<StudentResult> Updatebyasync(StudentResult studentResult, int id)
        {
            var result = await _Context.Results.FindAsync(id);
            if (result == null)
            {
                return null;
            }
            result.Marks = studentResult.Marks;
            result.Grade = studentResult.Grade;
            result.StudentId = studentResult.StudentId;
            result.ExamId = studentResult.ExamId;
            await _Context.SaveChangesAsync();
            return result;

        }
    }
}
