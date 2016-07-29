using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissors.Enums;

namespace RockPaperScissors
{
    public class MatchResult
    {
        public Choice Player1Choice { get; set; }
        public Choice Player2Choice { get; set; }
        public Result MatchResults { get; set; }
    }
}
