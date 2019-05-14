using System;
using System.Collections.Generic;

namespace StandUpConceirge.DB.Models
{
    public partial class BotAnswers
    {
        public int Id { get; set; }
        public int? BotQuestionId { get; set; }
        public int? RespondentId { get; set; }
        public string Answer { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}
