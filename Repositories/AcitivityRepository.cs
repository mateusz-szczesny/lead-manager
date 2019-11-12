using System.Collections.Generic;
using System.Threading.Tasks;
using LeadManager.Models;

namespace LeadManager.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly DatabaseContext _context;

        public ActivityRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<Activity> Create(Activity activity)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Activity>> GetActivitiesByLeadId(int leadId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Activity> GetActivityById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}