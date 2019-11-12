using System.Collections.Generic;
using System.Threading.Tasks;
using LeadManager.Models;

namespace LeadManager.Repositories
{
    public interface ILeadRepository
    {
        Task<Lead> GetLeadById(int id);
        Task<List<Lead>> GetLeads();
    }
}