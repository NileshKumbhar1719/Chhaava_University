using Course.Data;
using Course.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Course.Repository
{
    public class RepositoryCourse : IRepositoryCourse
    {
        private readonly AppDbContext _App;

        public RepositoryCourse(AppDbContext appDb) 
        {
           _App=appDb;
        }
        public async Task<Courses> CreateCoursesAsync(Courses courses)
        {
             await _App.AddAsync(courses);
             await  _App.SaveChangesAsync();
             return courses;
           
        }

        public async Task<bool> DeleteCoursesAsync(int id)
        {
            var data = await _App.courses.FindAsync(id);
            if (data == null)
            {
                return false;
            }

            _App.Remove(data);
            await _App.SaveChangesAsync();

            return true;
        }

        public async Task<List<Courses>> GetCoursesAsync()
        {
            var Data = await _App.courses.ToListAsync();
            return Data;
        }

        public async Task<Courses> GetbyIdCoursesAsync(int id)
        {
            var data = await _App.courses.FindAsync(id);
            return data;

        }

        public async Task<Courses> UpdateCoursesAsync(Courses courses,int id)
        {
            var data = await _App.courses.FindAsync(id);
            if(data == null)
            {
                return null;
            }
            data.Title = courses.Title;
            data.Credits = courses.Credits;
            data.DepartmentId = courses.DepartmentId;

            await _App.SaveChangesAsync();
            return data;


        }
    }
}
