using System;
using System.Collections.Generic;

namespace StandUpConceirge.Models.DB
{
    public partial class BotQuestions
    {
        public int Id { get; set; }
        public string Questions { get; set; }
        public int? ScheduleId { get; set; }
    }
}
