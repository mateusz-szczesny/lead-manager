using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using LeadManager.Models;
using Microsoft.EntityFrameworkCore;
using LeadManager.Utils;
using Microsoft.Extensions.Logging;

namespace LeadManager.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<LeadRepository> _logger;

        public LeadRepository(DatabaseContext context, ILogger<LeadRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<StatusReport> BulkLoadLeads(List<Lead> leads)
        {
            try
            {
                _context.AddRange(leads);
                await _context.SaveChangesAsync();
                return new StatusReport { Ok = true };
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return new StatusReport { Ok = false };
            }
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
                var leads = await _context.Leads.Include(l => l.Activities).ToListAsync();
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