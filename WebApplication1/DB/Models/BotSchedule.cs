using System;
using System.Collections.Generic;

namespace StandUpConceirge.DB.Models
{
    public partial class BotSchedule
    {
        public int Id { get; set; }
        public DateTime? StartDay { get; set; }
        public TimeSpan? TimeOccur { get; set; }
        public string DayOccur { get; set; }
        public string FrequencyOccur { get; set; }
        public string Respondents { get; set; }
        public string WelcomeMsg { get; set; }
    }
}
