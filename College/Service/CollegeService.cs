using College.Models;
using College.Repository;

namespace College.Service
{
    public class CollegeService : ICollegeService
    {
        private readonly ICollegeRepository _Repository;

        public CollegeService(ICollegeRepository collegeRepository)
        { 
         _Repository = collegeRepository;
        }
        public async Task<Colleges> Create(Colleges colleges)
        {
             return await _Repository.CreateCollege(colleges);
        }

        public async Task<bool> Delete(int id)
        {
            return await _Repository.DeleteCollege(id);
        }

        public async Task<List<Colleges>> getall()
        {
            return await _Repository.GetAllCollege();
        }

        public async Task<Colleges> Getbyid(int id)
        {
           return await _Repository.GetByIdCollege(id);
        }

        public async Task<Colleges> Update(Colleges colleges)
        {
            return  await _Repository.UpdateCollege(colleges);
        }
    }
}
