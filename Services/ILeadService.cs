using System.Collections.Generic;
using System.Threading.Tasks;
using LeadManager.Models;

namespace LeadManager.Services
{
    public interface ILeadService
    {
        Task<Lead> GetLeadById(int id);
        Task<List<Lead>> GetLeads();
    }
}