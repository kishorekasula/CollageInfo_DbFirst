using CollageInfo.Entities;
using CollageInfo.Models;

namespace CollageInfo.Interfaces
{
    public interface ICourseSubscriptionRepository
    {
        Task AddCourseSubscription(List<CourseSubscription> courseSubscription);
        Task<IEnumerable<CourseSubscription>> GetAllCourseSubscription();
        Task<CourseSubscription?> GetCourseSubscriptionById(int id);
        Task<CourseSubscription> UpdateCourseSubscription(int id, CourseSubscriptionModel SubscriptionModel);
    }
}
