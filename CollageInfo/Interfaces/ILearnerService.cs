using CollageInfo.Entities;
using CollageInfo.Models;

namespace CollageInfo.Interfaces
{
    public interface ILearnerService
    {
        Task AddLearnerAsync(List<LearnerModel> learnerModels);
        Task<List<Learner>> GetAllLearners();
        Task<Learner> GetLearnerById(int subscriberId);
        Task<Learner> UpdateLearnerById(int id, LearnerModel learnerModel);
        Task<bool> DeleteLearnerById(int id);
    }
}
