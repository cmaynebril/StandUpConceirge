using System;
using System.Collections.Generic;

namespace StandUpConceirge.Models.DB
{
    public partial class BotSchedule
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public string Day { get; set; }
        public string Frequency { get; set; }
        public string Respondents { get; set; }
        public string WelcomeMsg { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
        public string Creator { get; set; }
        public int? ScheduleId { get; set; }
    }
}
