using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseballLeague.Models.Data
{
    public class Player
    {
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public string PlayerFirstName { get; set; }
        public string PlayerLastName { get; set; }
        public int PositionId { get; set; }
        public int JerseyNumber { get; set; }
        public int YearsPlayed { get; set; }
    }
}