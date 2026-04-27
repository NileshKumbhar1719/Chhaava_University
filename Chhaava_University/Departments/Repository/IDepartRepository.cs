using Departments.Models;

namespace Departments.Repository
{
    public interface IDepartRepository
    {
        Task<List<Department>> GetalldataAsync();

        Task<Department> GetByIDAsync(int id);

        Task<Department> CreateAsync(Department department);

        Task<Department> UpdateAsync(Department department,int id);

        Task<bool> DeleteAsync(int id);
    }
}
