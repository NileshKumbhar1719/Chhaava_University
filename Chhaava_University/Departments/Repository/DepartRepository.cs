using Departments.Data;
using Departments.Models;
using Microsoft.EntityFrameworkCore;

namespace Departments.Repository
{
    public class DepartRepository : IDepartRepository
    {
        private readonly AppDbContext _App;

        public DepartRepository(AppDbContext appDbContext) 
        {
         _App=appDbContext;
        }
        public async Task<Department> CreateAsync(Department department)
        {
             await _App.Departments.AddAsync(department);
            await _App.SaveChangesAsync();
            return department;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = await _App.Departments.FindAsync(id);
            if(data == null)
            {
                return false;
            }
             _App.Departments.Remove(data);
            await _App.SaveChangesAsync();
            return true;
        }

        public async Task<List<Department>> GetalldataAsync()
        {
           var data = await _App.Departments.ToListAsync();
           return data;
        }

        public async Task<Department> GetByIDAsync(int id)
        {
            var data = await _App.Departments.FindAsync(id);
            return data;
        }

        public async Task<Department> UpdateAsync(Department department,int id)
        {
            var data = await _App.Departments.FindAsync(id);
            if(data == null)
            {
                return null;
            }
            data.Name = department.Name;
            data.CollegeId= department.CollegeId;
            await _App.SaveChangesAsync();
            return data;
        }
    }
}
