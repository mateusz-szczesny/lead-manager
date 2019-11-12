using System.Collections.Generic;
using System.Threading.Tasks;
using LeadManager.Models;

namespace LeadManager.Services
{
    public interface IActivityService
    {
        Task<Activity> Create(Activity activity);
        Task<List<Activity>> GetActivitiesByLeadId(int leadId);
        Task<Activity> GetActivityById(int id);

    }
}