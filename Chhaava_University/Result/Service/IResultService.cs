using Result.Models;

namespace Result.Service
{
    public interface IResultService
    {
        Task<List<StudentResult>> GetAllStudentsResult();
        Task<StudentResult> GetByIdStudentsResult(int id);
        Task<StudentResult> CreateStudentResult(StudentResult studentResult);
        Task<StudentResult> UpdateStudentResult(StudentResult studentResult,int id);
        Task<bool> DeleteStudentResult(int id);

    }
}
