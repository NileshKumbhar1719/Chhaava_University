using College.Models;

namespace College.Service
{
    public interface ICollegeService
    {
        Task <List<Colleges>> getall();
        Task<Colleges>Getbyid(int id);

        Task<Colleges> Create(Colleges colleges);
        Task<Colleges> Update(Colleges colleges);
        Task<bool> Delete(int id);


        
    }
}
