using System;

namespace LeadManager.Requests
{
    public class ActivityHQ
    {
        public string external_id { get; set; }
        public string lead_id { get; set; }
        public string type { get; set; }
        public DateTime created_date { get; set; }
    }
}