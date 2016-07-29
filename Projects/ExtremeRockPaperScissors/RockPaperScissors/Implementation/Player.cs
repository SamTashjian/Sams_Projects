using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissors.Enums;
using RockPaperScissors.Interfaces;

namespace RockPaperScissors.Implementation
{
    public abstract class Player: IChoiceSelector
    {
        public string Name { get; }

        public Player(string name)
        {
            Name = name;
        }

        public abstract Choice GetChoice();
    }
}
