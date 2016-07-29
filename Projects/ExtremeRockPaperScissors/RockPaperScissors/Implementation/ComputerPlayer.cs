using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissors.Enums;

namespace RockPaperScissors.Implementation
{
    public class ComputerPlayer: Player
    {
        private static Random  _randomGenerator = new Random();

        public ComputerPlayer(string name) : base(name)
        {
        }

        public override Choice GetChoice()
        {
            int choice = _randomGenerator.Next(1, 101);
            if (choice >= 1 && choice <= 50)
            {
                return Choice.Rock;
            }
            else if (choice >= 51 && choice <= 60)
            {
                return Choice.Paper;
            }
            else if (choice >= 61 && choice <= 70)
            {
                return Choice.Scissors;
            }
            else if (choice >= 71 && choice <= 80)
            {
                return Choice.Hammer;
            }
            else
            {
                return Choice.Underwear;
            }
            
        }
    }
}
