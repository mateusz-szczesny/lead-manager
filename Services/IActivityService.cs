using System.Collections.Generic;
using System.Threading.Tasks;
using LeadManager.Models;

namespace LeadManager.Services
{
    public interface IActivityService
    {
        Task<Activity> Create(Activity activity);
        List<Activity> GetActivitiesByLeadId(int leadId);
        Task<Activity> GetActivityById(int id);
        Task<List<Activity>> GetActivitiesToSync();
        Task UpdateSyncDateTime(List<Activity> activities);

    }
}