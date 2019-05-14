using System;
using System.Collections.Generic;

namespace StandUpConceirge.DB.Models
{
    public partial class BotQuestions
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int? BotScheduleId { get; set; }
    }
}
