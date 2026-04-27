using Course.Models;

namespace Course.Repository
{
    public interface IRepositoryCourse
    {
        Task<List<Courses>> GetCoursesAsync();
        Task<Courses> GetbyIdCoursesAsync(int id);
        Task<Courses> CreateCoursesAsync(Courses courses);

        Task<Courses> UpdateCoursesAsync(Courses courses,int id);

        Task<bool> DeleteCoursesAsync(int id);
    }
}
