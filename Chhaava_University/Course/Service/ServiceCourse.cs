using Course.Models;
using Course.Repository;

namespace Course.Service
{
    public class ServiceCourse : IServiceCourse
    {
        private readonly IRepositoryCourse _Repo;

        public ServiceCourse(IRepositoryCourse repositoryCourse)
        {
           _Repo=repositoryCourse;
        }
        
        public async Task<List<Courses>> AllGetdata()
        {
            return await _Repo.GetCoursesAsync();
        }

        public async Task<Courses> create(Courses course)
        {
           return await _Repo.CreateCoursesAsync(course);
        }

        public async Task<bool> Delete(int id)
        {
            return await _Repo.DeleteCoursesAsync(id);
        }

        public async Task<Courses> GetbyIDdata(int id)
        {
            return await _Repo.GetbyIdCoursesAsync(id).ConfigureAwait(false);
        }

        public async Task<Courses> Update(int id, Courses courses)
        {
            return await _Repo.UpdateCoursesAsync(courses, id).ConfigureAwait(false);
        }
    }
}
