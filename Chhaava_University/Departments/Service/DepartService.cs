using Departments.Models;
using Departments.Repository;

namespace Departments.Service
{
    public class DepartService : IDepartService
    {
        private readonly IDepartRepository _Depart;

        public DepartService(IDepartRepository departRepository) 
        {
         _Depart= departRepository;
        }
        public async Task<bool> DeleteDepartmentsAsync(int id)
        {
           return await _Depart.DeleteAsync(id);
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            return await _Depart.GetalldataAsync();
        }

        public async Task<Department> GetDepartmentsByIdAsync(int id)
        {
            return await _Depart.GetByIDAsync(id);
        }

        public async Task<Department> GetDepartmentsCreateAsync(Department department)
        {
            return await _Depart.CreateAsync(department);
        }

        public async Task<Department> GetDepartmentsUpdateAsync(Department department, int id)
        {
            return await _Depart.UpdateAsync(department, id);
        }
    }
}
