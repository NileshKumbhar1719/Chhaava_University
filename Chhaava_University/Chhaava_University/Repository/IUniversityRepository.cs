using Chhaava_University.Models;

namespace Chhaava_University.Repository
{
    public interface IUniversityRepository
    {
        Task<List<University>> GetAllAsync();
        Task<University> GetByIdAsync(int id);
        Task<University> CreateUniversityAsync(University university);
        Task<University> UpdateUniversityAsync(University university);
        Task<bool> DeleteUniversityAsync(int id);


    }
}
