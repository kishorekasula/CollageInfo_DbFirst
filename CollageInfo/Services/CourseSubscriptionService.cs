using CollageInfo.Entities;
using CollageInfo.Interfaces;
using CollageInfo.Models;

namespace CollageInfo.Services
{
    public class CourseSubscriptionService : ICourseSubscriptionService
    {
        private readonly ICourseSubscriptionRepository _repository;

        public CourseSubscriptionService(ICourseSubscriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task AddCourseSubscription(List<CourseSubscriptionModel> courseSubscriptionModel)
        {
            var subscription = new List<CourseSubscription>();
            foreach (var Model in courseSubscriptionModel)
            {
                subscription.Add(new CourseSubscription
                {
                    CourseId = Model.CourseId,
                    CourseName = Model.CourseName,
                    CourseType = Model.CourseType,
                    CourseHours = Model.CourseHours,
                    ContentLevel = Model.ContentLevel,
                    SessionId = Model.SessionId,
                    CurriculumDispCat = Model.CurriculumDispCat,
                    SubscribedDateTime = Model.SubscribedDateTime,
                    Payload = Model.Payload
                });
            }
            
            await _repository.AddCourseSubscription(subscription);
        }

        public async Task<IEnumerable<CourseSubscription>> GetAllCourseSubscription()
        {
            return await _repository.GetAllCourseSubscription();
        }

        public async Task<CourseSubscription?> GetCourseSubscriptionById(int id)
        {
            return await _repository.GetCourseSubscriptionById(id);
        }

        public async Task<CourseSubscription> UpdateCourseSubscription(int id, CourseSubscriptionModel subscriptionModel)
        {
            var updateCourseSubscription = new CourseSubscription
            {
                CourseId = subscriptionModel.CourseId,
                CourseName = subscriptionModel.CourseName,
                CourseType = subscriptionModel.CourseType,
                CourseHours = subscriptionModel.CourseHours,
                ContentLevel = subscriptionModel.ContentLevel,
                SessionId = subscriptionModel.SessionId,
                CurriculumDispCat= subscriptionModel.CurriculumDispCat,
                SubscribedDateTime = subscriptionModel.SubscribedDateTime,
                Payload = subscriptionModel.Payload
            };

            return await _repository.UpdateCourseSubscription(id, subscriptionModel);
        }
    }
}
