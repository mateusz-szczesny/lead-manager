using System.Collections.Generic;
using System.Threading.Tasks;
using LeadManager.Models;

namespace LeadManager.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly DatabaseContext _context;

        public LeadRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task<Lead> GetLeadById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Lead>> GetLeads()
        {
            throw new System.NotImplementedException();
        }
    }
}