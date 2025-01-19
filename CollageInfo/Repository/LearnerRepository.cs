using CollageInfo.Entities;
using CollageInfo.Interfaces;
using CollageInfo.Models;
using Learner_API.Data;
using Microsoft.EntityFrameworkCore;

namespace CollageInfo.Repository
{
    public class LearnerRepository : ILearnerRepository
    {
        private readonly CollageInfoDBContext _learnerDbContext;

        public LearnerRepository(CollageInfoDBContext learnerDbContext)
        {
            _learnerDbContext = learnerDbContext;
        }

        public async Task<List<Learner>> GetAllLearners()
        {
            return await _learnerDbContext.Learners.ToListAsync();
        }

        public async Task<Learner> GetLearnerById(int subscriberId)
        {
            return await _learnerDbContext.Learners.FirstOrDefaultAsync(l => l.SubscriberID == subscriberId); ;
        }

        public async Task AddLearnerAsync(List<Learner> learner)
        {
            await _learnerDbContext.Learners.AddRangeAsync(learner);
            await _learnerDbContext.SaveChangesAsync();
        }

        public async Task<Learner> UpdateLearnerById(int id, LearnerModel learnerModel)
        {
            var learner = await _learnerDbContext.Learners.FindAsync(id);
            if (learner == null)
            {
                return null; // Return null if the learner is not found
            }

            // Update the learner's properties with the new values
            learner.TranscriptID = learnerModel.TranscriptID;
            learner.LearnerID = learnerModel.Employee_ID;
            learner.PeopleKey = learnerModel.PeopleKey;
            learner.CourseID = learnerModel.CourseID;
            learner.SessionID = learnerModel.SessionID;
            learner.Status = learnerModel.Status;
            learner.CompletionDate = learnerModel.CompletionDate;
            learner.SourceID = learnerModel.SourceID;
            learner.SourceName = learnerModel.SourceName;

            // Save changes to the database
            _learnerDbContext.Learners.Update(learner);
            await _learnerDbContext.SaveChangesAsync();
            return learner;
        }

        public async Task<bool> DeleteLearnerById(int id)
        {
            var learner = await _learnerDbContext.Learners.FindAsync(id);
            if (learner != null)
            {
                _learnerDbContext.Learners.Remove(learner);
                await _learnerDbContext.SaveChangesAsync();
                return true; // Return true if the delete operation is successful
            }
            else return false;
        }
    }
}
