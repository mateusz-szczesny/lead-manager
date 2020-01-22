using System.Collections.Generic;
using LeadManager.Models;
using LeadManager.Requests;
using LeadManager.Responses;

namespace LeadManager.Mappers
{
    public static class LeadMapper
    {
        public static LeadResponse ToLeadResponse(this Lead lead)
        {
            var leadResponse = new LeadResponse
            {
                Id = lead.Id,
                FirstName = lead.FirstName,
                LastName = lead.LastName,
                Email = lead.Email,
                Active = lead.Active,
                CreatedDate = lead.CreatedDate,
                UpdatedDate = lead.UpdatedDate,
                Activities = new List<ActivityResponse>(),
            };

            foreach (var activity in lead.Activities)
            {
                leadResponse.Activities.Add(activity.ToActivityResponse());
            }

            return leadResponse;
        }
        public static Lead ToLead(this LeadRequest leadRequest)
        {
            return new Lead
            {
                FirstName = leadRequest.FirstName,
                LastName = leadRequest.LastName,
                Email = leadRequest.Email,
                Active = true,
                ExternalId = leadRequest.ExternalId,
            };
        }
    }
}