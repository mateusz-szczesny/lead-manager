using System;
using System.ComponentModel.DataAnnotations;

namespace LeadManager.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        public int LeadId { get; set; }
        public ActivityType Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }

    public enum ActivityType
    {
        Phone,
        Meeting,
        Email,
    }
}