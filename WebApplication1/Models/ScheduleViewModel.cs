using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ScheduleViewModel
    {
        public int ID { get; set; }
        public DateTime? StartDay { get; set; }
        public TimeSpan? TimeOccur { get; set; }
        public bool Sunday { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public string FrequencyOccur { get; set; }
        public string Respondents { get; set; }
        public string WelcomeMsg { get; set; }
        public string Question { get; set; }


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
