using CollageInfo.Entities;
using CollageInfo.Models;

namespace CollageInfo.Interfaces
{
    public interface ICourseSubscriptionService
    {
        Task AddCourseSubscription(List<CourseSubscriptionModel> courseSubscriptionModel);
        Task<IEnumerable<CourseSubscription>> GetAllCourseSubscription();
        Task<CourseSubscription?> GetCourseSubscriptionById(int id);
        Task<CourseSubscription> UpdateCourseSubscription(int id, CourseSubscriptionModel subscriptionModel);
    }
}
