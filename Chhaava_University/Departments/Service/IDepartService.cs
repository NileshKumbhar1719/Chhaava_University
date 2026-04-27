using Departments.Models;

namespace Departments.Service
{
    public interface IDepartService
    {
        Task <List<Department>> GetDepartmentsAsync ();

        Task<Department> GetDepartmentsByIdAsync (int id);

        Task<Department> GetDepartmentsCreateAsync (  Department department);

        Task<Department> GetDepartmentsUpdateAsync ( Department department,int id);

        Task<bool> DeleteDepartmentsAsync (int id);
    }
}
