using System;
using LeadManager.Models;

namespace LeadManager.Responses
{
    public class ActivityResponse
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public ActivityType Type { get; set; }
        public string TypeName
        {
            get
            {
                return this.Type.ToString("G");
            }
        }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}