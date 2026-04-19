using College.Models;

namespace College.Repository
{
    public interface ICollegeRepository
    {
        Task<List<Colleges>> GetAllCollege();
        Task<Colleges> GetByIdCollege(int id);
        Task<Colleges>CreateCollege(Colleges college);
        Task<Colleges> UpdateCollege(Colleges colleges);

        Task<bool> DeleteCollege(int id);
    }
}
