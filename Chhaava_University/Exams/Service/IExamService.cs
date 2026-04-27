using Exam.Models;

namespace Exams.Service
{
    public interface IExamService
    {
        Task<List<Exampaper>> GetExamsAsync();
        Task<Exampaper> GetExambyIdAsync(int id);
        Task<Exampaper> CreateExame(Exampaper exam);
        Task<Exampaper> UpdateExame(Exampaper exam, int id);
        Task<bool> DeleteExamAsync(int id);
    }
}
