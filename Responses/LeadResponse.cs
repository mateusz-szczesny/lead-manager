using System;
using System.Collections.Generic;

namespace LeadManager.Responses
{
    public class LeadResponse
    {
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool? Active { get; set; }
        public List<ActivityResponse> Activities { get; set; }
        public int NumberOfActivities { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}