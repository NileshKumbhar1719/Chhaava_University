using Result.Models;

namespace Result.Repository
{
    public interface IResultRepository
    {
        Task<List<StudentResult>> GetAllasync();
        Task<StudentResult> GetByIdasync(int id);
        Task<StudentResult> Createbyasync(StudentResult studentResult);
        Task<StudentResult> Updatebyasync(StudentResult studentResult,int id);
        Task<bool> Deletebyasync(int id);
    }
}
