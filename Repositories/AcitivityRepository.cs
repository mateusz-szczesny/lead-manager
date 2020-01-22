using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeadManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LeadManager.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly DatabaseContext _context;

        public ActivityRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Activity> Create(Activity activity)
        {
            try
            {
                var created = await _context.Activities.AddAsync(activity);
                await _context.SaveChangesAsync();
                if (created != null)
                {
                    return created.Entity;
                }
                throw new Exception("Cannot create activity");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Activity> GetActivitiesByLeadId(int leadId)
        {
            try
            {
                List<Activity> activities = _context.Activities.Where(a => a.LeadId == leadId).OrderByDescending(a => a.CreatedDate).ToList();
                if (activities != null && activities.Any())
                {
                    return activities;
                }
                throw new Exception("Cannot found activities for given lead id");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Activity>> GetActivitiesToSync()
        {
            try
            {
                var activities = await _context.Activities.Include(x => x.Lead).Where(a => a.SyncDateTime == null || a.UpdatedDate > a.SyncDateTime).ToListAsync();
                if (activities != null && activities.Any())
                {
                    return activities;
                }
                throw new Exception("No activities to sync!");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task UpdateSyncDateTime(List<Activity> activities)
        {
            try
            {
                activities.ForEach(a => a.SyncDateTime = DateTime.Now);
                _context.Activities.UpdateRange(activities);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Activity> GetActivityById(int id)
        {
            try
            {
                var activity = await _context.Activities.FirstOrDefaultAsync(a => a.Id == id);
                if (activity != null)
                {
                    return activity;
                }
                throw new Exception("Cannot found such activity");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}