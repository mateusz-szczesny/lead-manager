using System;
using LeadManager.Models;
using LeadManager.Requests;

namespace LeadManager.Mappers
{
    public static class ActivityMapper
    {
        public static Activity ToActivity(this ActivityRequest activityRequest)
        {
            return new Activity
            {
                LeadId = activityRequest.LeadId,
                Type = ParseEnum<ActivityType>(activityRequest.Type),
            };
        }
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}