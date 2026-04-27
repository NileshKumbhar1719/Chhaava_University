using Exam.Models;
using Exams.Repository;

namespace Exams.Service
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _Repo;

        public ExamService(IExamRepository examRepository)
        {
          _Repo=examRepository;
        }
        public async Task<Exampaper> CreateExame(Exampaper exam)
        {
            if (exam == null)
                throw new ArgumentNullException(nameof(exam));
            return await _Repo.CreateAsync(exam);
        }

        public async Task<bool> DeleteExamAsync(int id)
        {
             await _Repo.DeleteAsync(id);
            return true;

        }

        public async Task<Exampaper> GetExambyIdAsync(int id)
        {
            return await _Repo.GetByIdAsync(id);
        }

        public async Task<List<Exampaper>> GetExamsAsync()
        {
            return await _Repo.GetAllExamsAsync();
        }

        public async Task<Exampaper> UpdateExame(Exampaper exam, int id)
        {
            return await _Repo.UpdateAsync(exam, id);
        }
    }
}
