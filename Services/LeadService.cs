using System.Collections.Generic;
using System.Threading.Tasks;
using LeadManager.Models;
using LeadManager.Repositories;

namespace LeadManager.Services
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;

        public LeadService(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public Task<Lead> GetLeadById(int id)
        {
            return _leadRepository.GetLeadById(id);
        }

        public Task<List<Lead>> GetLeads()
        {
            return _leadRepository.GetLeads();
        }
    }
}