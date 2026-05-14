
using Chhaava_University.Data;
using Chhaava_University.Models;
using Microsoft.EntityFrameworkCore;

namespace Chhaava_University.Repository
{
    public class UniversityRepository : IUniversityRepository
    {
        private readonly AppDbContext _DbContext;

        public UniversityRepository(AppDbContext appDbContext)
        {
            _DbContext = appDbContext;
        }

        // GET ALL
        public async Task<List<University>> GetAllAsync()
        {
            return await _DbContext.Universities.ToListAsync();
        }

        // GET BY ID
        public async Task<University> GetByIdAsync(int id)
        {
            return await _DbContext.Universities.FindAsync(id);
        }

        // CREATE
        public async Task<University> CreateUniversityAsync(University university)
        {
            await _DbContext.Universities.AddAsync(university);
            await _DbContext.SaveChangesAsync();
            return university;
        }

        // UPDATE
        public async Task<University> UpdateUniversityAsync(University university)
        {
            var existing = await _DbContext.Universities.FindAsync(university.Id);

            if (existing == null)
                return null;

            existing.Name = university.Name;
            existing.Address = university.Address;
            existing.Email = university.Email;

            await _DbContext.SaveChangesAsync();
            return existing;
        }

        // DELETE
        public async Task<bool> DeleteUniversityAsync(int id)
        {
            var university = await _DbContext.Universities.FindAsync(id);

            if (university == null)
                return false;

            _DbContext.Universities.Remove(university);
            await _DbContext.SaveChangesAsync();

            return true;
        }
    }
}
