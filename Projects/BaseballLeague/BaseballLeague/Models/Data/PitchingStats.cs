using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseballLeague.Models.Data
{
    public class PitchingStats
    {
        public int PlayerId { get; set; }
        public int GP { get; set; }
        public int GS { get; set; }
        public int W { get; set; }
        public int L { get; set; }
        public int HLD { get; set; }
        public int SV { get; set; }
        public int IP { get; set; }
        public int HitsAllowed { get; set; }
        public int ER { get; set; }
        public int K { get; set; }
        public int Walks { get; set; }
    }
}