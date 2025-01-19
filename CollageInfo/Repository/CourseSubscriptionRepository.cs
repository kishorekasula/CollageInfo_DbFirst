using CollageInfo.Entities;
using CollageInfo.Interfaces;
using CollageInfo.Models;
using Learner_API.Data;
using Microsoft.EntityFrameworkCore;

namespace CollageInfo.Repository
{
    public class CourseSubscriptionRepository : ICourseSubscriptionRepository
    {
        private readonly CollageInfoDBContext _context;

        public CourseSubscriptionRepository(CollageInfoDBContext learnerDbContext)
        {
            _context = learnerDbContext;
        }

        public async Task AddCourseSubscription(List<CourseSubscription> courseSubscription)
        {
            await _context.CourseSubscriptions.AddRangeAsync(courseSubscription);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CourseSubscription>> GetAllCourseSubscription()
        {
            return await _context.CourseSubscriptions.ToListAsync();
        }

        public async Task<CourseSubscription?> GetCourseSubscriptionById(int id)
        {
            return await _context.CourseSubscriptions.FindAsync(id);
        }

        public async Task<CourseSubscription> UpdateCourseSubscription(int id, CourseSubscriptionModel SubscriptionModel)
        {
            var subscription = await _context.CourseSubscriptions.FindAsync(id);

            if (subscription == null)
            {
                return null;
            }
             
            subscription.CourseId = SubscriptionModel.CourseId;
            subscription.CourseName = SubscriptionModel.CourseName;
            subscription.CourseType = SubscriptionModel.CourseType;
            subscription.CourseHours = SubscriptionModel.CourseHours;
            subscription.ContentLevel = SubscriptionModel.ContentLevel;
            subscription.SessionId = SubscriptionModel.SessionId;
            subscription.CurriculumDispCat = SubscriptionModel.CurriculumDispCat;
            subscription.SubscribedDateTime = SubscriptionModel.SubscribedDateTime;

            _context.CourseSubscriptions.Update(subscription);
            await _context.SaveChangesAsync();
            return subscription;
        }
    }
}
