using System;
using System.Collections.Generic;

namespace WebApplication1.Models.DB
{
    public partial class BotQuestions
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int? BotScheduleId { get; set; }
    }
}
