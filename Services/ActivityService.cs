using System.Collections.Generic;
using System.Threading.Tasks;
using LeadManager.Models;
using LeadManager.Repositories;

namespace LeadManager.Services
{
    public class ActivityService : IActivityService
    {

        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public Task<Activity> Create(Activity activity)
        {
            return _activityRepository.Create(activity);
        }

        public List<Activity> GetActivitiesByLeadId(int leadId)
        {
            return _activityRepository.GetActivitiesByLeadId(leadId);
        }

        public Task<Activity> GetActivityById(int id)
        {
            return _activityRepository.GetActivityById(id);
        }
    }
}