using Result.Models;
using Result.Repository;

namespace Result.Service
{
    public class ResultService : IResultService
    {
        private IResultRepository _result;

        public ResultService(IResultRepository repository) 
        {
            _result = repository;
        
        }
        public async Task<StudentResult> CreateStudentResult(StudentResult studentResult)
        {
            return await _result.Createbyasync(studentResult);
        }

        public async Task<bool> DeleteStudentResult(int id)
        {
            return await _result.Deletebyasync(id);
        }

        public async Task<List<StudentResult>> GetAllStudentsResult()
        {
            return await _result.GetAllasync();
        }

        public async Task<StudentResult> GetByIdStudentsResult(int id)
        {
            return await _result.GetByIdasync(id);
        }

        public async Task<StudentResult> UpdateStudentResult(StudentResult studentResult, int id)
        {
            return await _result.Updatebyasync(studentResult, id);
        }
    }
}
