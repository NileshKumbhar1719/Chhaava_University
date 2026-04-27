using Course.Models;

namespace Course.Service
{
    public interface IServiceCourse
    {
        Task<List<Courses>> AllGetdata();
        Task<Courses> GetbyIDdata(int id);
        Task<Courses> create(Courses course);
        Task<Courses> Update(int id,Courses courses);
        Task<bool> Delete(int id);

    }
}
