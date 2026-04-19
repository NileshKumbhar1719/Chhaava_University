using Chhaava_University.Models;

namespace Chhaava_University.Service
{
    public interface IUniversityService
    {
        Task<List<University>> GetAllAsync();
        Task<University> GetByIdAsync(int id);
        Task<University> CreateAsync(University university);
        Task<University> UpdateAsync(University university);
        Task<bool> DeleteAsync(int id);
    }
}
