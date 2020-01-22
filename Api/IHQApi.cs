using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LeadManager.Requests;
using Refit;

namespace LeadManager.Api
{
    public interface IHQApi
    {
        [Post("/integration_activities")]
        Task<HttpResponseMessage> SyncActivities([Body] IEnumerable<ActivityHQ> activities);
    }
}