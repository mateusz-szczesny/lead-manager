using System.Collections.Generic;
using System.Linq;
using LeadManager.Models;
using LeadManager.Requests;
using LeadManager.Responses;

namespace LeadManager.Mappers
{
    public static class LeadMapper
    {
        public static LeadResponse ToLeadResponse(this Lead lead)
        {
            return new LeadResponse
            {
                Id = lead.Id,
                ExternalId = lead.ExternalId,
                FirstName = lead.FirstName,
                LastName = lead.LastName,
                Email = lead.Email,
                Active = lead.Active,
                CreatedDate = lead.CreatedDate,
                UpdatedDate = lead.UpdatedDate,
                Activities = lead.Activities.Select(a => a.ToActivityResponse()).ToList(),
                NumberOfActivities = lead.Activities.Count
            };
        }
        public static Lead ToLead(this LeadRequest leadRequest)
        {
            return new Lead
            {
                ExternalId = leadRequest.ExternalId,
                FirstName = leadRequest.FirstName,
                LastName = leadRequest.LastName,
                Email = leadRequest.Email,
                Active = true,
            };
        }
    }
}