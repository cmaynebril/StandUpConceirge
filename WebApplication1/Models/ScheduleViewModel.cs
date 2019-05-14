using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StandUpConceirge.Models
{
    public class ScheduleViewModel
    {
        public int ID { get; set; }
        [Required]
        public DateTime? StartDay { get; set; }
        [Required]
        public TimeSpan? TimeOccur { get; set; }
        public bool Sunday { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        [Required]
        public string FrequencyOccur { get; set; }

        public string Respondents { get; set; }
        [Required]
        public string WelcomeMsg { get; set; }
        [Required]
        public string[] Question { get; set; }


        public string DayOccur
        {
            get
            {
                return Sunday.ToString().Substring(0, 1)
                    + Monday.ToString().Substring(0, 1)
                    + Tuesday.ToString().Substring(0, 1)
                    + Wednesday.ToString().Substring(0, 1)
                    + Thursday.ToString().Substring(0, 1)
                    + Friday.ToString().Substring(0, 1)
                    + Saturday.ToString().Substring(0, 1);
            }
        }
    }
}
