using StandUpConceirge.Models.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StandUpConceirge.Models
{
    public class ScheduleViewModel
    {
        public int ID { get; set; }
        [Required]
        public DateTime? StartDay { get; set; }
        [Required]
        public TimeSpan? TimeOccur { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public string Creator { get; set; }
        public int? ScheduleId { get; set; }

        [Required]
        public string FrequencyOccur { get; set; }
        [Required]
        public string WelcomeMsg { get; set; }
        [NotMapped]
        public string[] Respondents { get; set; }
        [NotMapped]
        public string[] Question { get; set; }
               
    }
}
