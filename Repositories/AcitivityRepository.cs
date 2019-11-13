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
                if (created != null && created.State == EntityState.Added)
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

        public async Task<Activity> GetActivityById(int id)
        {
            try
            {
                var activity = await _context.Activities.FirstAsync(a => a.Id == id);
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