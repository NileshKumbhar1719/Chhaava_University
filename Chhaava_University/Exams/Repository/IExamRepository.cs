using Exam.Models;

namespace Exams.Repository
{
    public interface IExamRepository
    {
        Task<List<Exampaper>> GetAllExamsAsync();
        Task<Exampaper> GetByIdAsync(int id);

        Task<Exampaper> CreateAsync(Exampaper exampaper);
        Task<Exampaper> UpdateAsync(Exampaper exampaper,int id);
        Task<bool> DeleteAsync(int id);
    }
}
