using System.Collections.Generic;
using System.Threading.Tasks;
using LeadManager.Models;
using LeadManager.Utils;

namespace LeadManager.Repositories
{
    public interface ILeadRepository
    {
        Task<Lead> GetLeadById(int id);
        Task<List<Lead>> GetLeads();
        Task<StatusReport> BulkLoadLeads(List<Lead> leads);
    }
}