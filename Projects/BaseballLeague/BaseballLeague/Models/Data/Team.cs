using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseballLeague.Models.Data
{
    public class Team
    {
        public int TeamId { get; set; }
        public int LeagueId { get; set; }
        public string TeamName { get; set; }
        public string TeamCity { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}