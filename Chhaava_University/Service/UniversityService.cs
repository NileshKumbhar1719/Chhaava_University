using Chhaava_University.Models;
using Chhaava_University.Repository;

namespace Chhaava_University.Service
{
    public class UniversityService : IUniversityService
    {
        private readonly IUniversityRepository _repository;

        public UniversityService(IUniversityRepository repository)
        {
            _repository = repository;
        }

        // GET ALL
        public async Task<List<University>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // GET BY ID
        public async Task<University> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        // CREATE
        public async Task<University> CreateAsync(University university)
        {
            if (university == null)
                throw new ArgumentNullException(nameof(university));

            return await _repository.CreateUniversityAsync(university);
        }

        // UPDATE
        public async Task<University> UpdateAsync(University university)
        {
            return await _repository.UpdateUniversityAsync(university);
        }

        // DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteUniversityAsync(id);
        }
    
}
}
