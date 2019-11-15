using System;
using LeadManager.Models;
using LeadManager.Requests;
using LeadManager.Responses;

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

        public static ActivityResponse ToActivityResponse(this Activity activity)
        {
            return new ActivityResponse
            {
                Id = activity.Id,
                Type = activity.Type,
                LeadId = activity.LeadId,
                CreatedDate = activity.CreatedDate,
                UpdatedDate = activity.UpdatedDate,
            };
        }
    }
}