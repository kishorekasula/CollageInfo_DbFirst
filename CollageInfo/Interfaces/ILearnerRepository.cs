using CollageInfo.Entities;
using CollageInfo.Models;

namespace CollageInfo.Interfaces
{
    public interface ILearnerRepository
    {
        Task<List<Learner>> GetAllLearners();
        Task<Learner> GetLearnerById(int subscriberId);
        Task AddLearnerAsync(List<Learner> learner);
        Task<Learner> UpdateLearnerById(int id, LearnerModel learnerModel);
        Task<bool> DeleteLearnerById(int id);
    }
}
