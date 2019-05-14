using System;
using System.Collections.Generic;

namespace StandUpConceirge.Models.DB
{
    public partial class BotUsers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAdd { get; set; }
        public string Password { get; set; }
    }
}
