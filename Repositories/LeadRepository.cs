using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using LeadManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LeadManager.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly DatabaseContext _context;

        public LeadRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Lead> GetLeadById(int id)
        {
            try
            {
                var lead = await _context.Leads.Where(l => l.Id == id).Include(l => l.Activities).ToListAsync();
                if (lead != null && lead.Count == 1)
                {
                    return lead[0];
                }
                throw new Exception("Cannot found such lead");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Lead>> GetLeads()
        {
            try
            {
                var leads = await _context.Leads.ToListAsync();
                if (leads != null)
                {
                    return leads;
                }
                throw new Exception("No leads available");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}