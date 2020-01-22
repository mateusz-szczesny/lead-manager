using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadManager.Models
{
    public class Activity : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public Guid ExternalId { get; set; }
        public int LeadId { get; set; }
        public Lead Lead { get; set; }
        public DateTime? SyncDateTime { get; set; }
        public ActivityType Type { get; set; }
    }

    public enum ActivityType
    {
        Phone,
        Meeting,
        Email,
    }
}