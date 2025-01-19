using CollageInfo.Entities;
using CollageInfo.Interfaces;
using CollageInfo.Models;
using CollageInfo.Repository;

namespace CollageInfo.Services
{
    public class LearnerService : ILearnerService
    {
        private readonly ILearnerRepository _repository;

        public LearnerService(ILearnerRepository repository)
        {
            _repository = repository;
        }

        public async Task AddLearnerAsync(List<LearnerModel> learnerModels)
        {
            var learners = new List<Learner>();
            foreach (var model in learnerModels)
            {
                learners.Add(new Learner
                {
                    TranscriptID = model.TranscriptID,
                    LearnerID = model.Employee_ID,
                    PeopleKey = model.PeopleKey,
                    CourseID = model.CourseID,
                    SessionID = model.SessionID,
                    Status = model.Status,
                    CompletionDate = model.CompletionDate,
                    SourceID = model.SourceID,
                    SourceName = model.SourceName
                });
            }
            await _repository.AddLearnerAsync(learners);
        }

        public async Task<List<Learner>> GetAllLearners()
        {
            return await _repository.GetAllLearners();
        }

        public async Task<Learner> GetLearnerById(int subscriberId)
        {
            return await _repository.GetLearnerById(subscriberId);
        }

        public async Task<Learner> UpdateLearnerById(int id, LearnerModel learnerModel)
        {
            // Convert the LearnerModel to a Learner entity
            var updatedLearner = new Learner
            {
                TranscriptID = learnerModel.TranscriptID,
                LearnerID = learnerModel.Employee_ID,
                PeopleKey = learnerModel.PeopleKey,
                CourseID = learnerModel.CourseID,
                SessionID = learnerModel.SessionID,
                Status = learnerModel.Status,
                CompletionDate = learnerModel.CompletionDate,
                SourceID = learnerModel.SourceID,
                SourceName = learnerModel.SourceName
            };

            return await _repository.UpdateLearnerById(id, learnerModel);
        }

        public async Task<bool> DeleteLearnerById(int id)
        {
            var data = await _repository.DeleteLearnerById(id);
            if (data)
            {
                return true;
            }
            else return false;
        }
    }
}
