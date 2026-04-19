using College.Data;
using College.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace College.Repository
{
    public class CollegeRepository : ICollegeRepository
    {
        private readonly AppDbContext _Context;

        public CollegeRepository(AppDbContext appDbContext ) 
        {
           _Context = appDbContext;
        
        }
        public async Task<Colleges> CreateCollege(Colleges college)
        {
            await _Context.Colleges.AddAsync(college);
            await _Context.SaveChangesAsync();
            return college;
        }

        public async Task<bool> DeleteCollege(int id)
        {
            var college = await _Context.Colleges.FindAsync(id);
            if (college == null)
            {
                return false;
            }
            _Context.Colleges.Remove(college);
            await _Context.SaveChangesAsync();
            return true;

        }

        public async Task<List<Colleges>> GetAllCollege()
        {
           var college = await _Context.Colleges.ToListAsync();
            return college;
        }

        public async Task<Colleges> GetByIdCollege(int id)
        {
           return await _Context.Colleges.FindAsync(id);
            
        }

        public async Task<Colleges> UpdateCollege(Colleges colleges)
        {
           var data = await _Context.Colleges.FindAsync(colleges.Id);
            if(data == null)
            {
                return null;
            }
            data.Name = colleges.Name;
            data.Location = colleges.Location;
            await _Context.SaveChangesAsync();
            return data;
        }
    }
}
