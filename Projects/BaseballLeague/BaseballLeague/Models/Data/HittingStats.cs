using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseballLeague.Models.Data
{
    public class HittingStats
    {
        public int PlayerId { get; set; }
        public int GP { get; set; }
        public int AB { get; set; }
        public int Hits { get; set; }
        public int Doubles { get; set; }
        public int Triples { get; set; }
        public int R { get; set; }
        public int HR { get; set; }
        public int RBI { get; set; }
        public int BB { get; set; }
        public int SO { get; set; }
        public int SB { get; set; }

    }
}