using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissors.Enums;

namespace RockPaperScissors.Implementation
{
    class HumanPlayer: Player
    {
        public HumanPlayer(string name) : base(name)
        {
        }

        public override Choice GetChoice()
        {
            Choice choice = Choice.Uknown;

            while (choice == Choice.Uknown)
            {
                Console.Write($"{Name}, Enter a choice (R) for Rock, (P) for Paper, (S) for Scissors, (H) for Hammer, or (U) for Underwear");
                string input = Console.ReadLine();

                switch (input.ToUpper())
                {
                    case "R":
                        choice = Choice.Rock;
                        break;

                    case "P":
                        choice = Choice.Paper;
                        break;

                    case "S":
                        choice = Choice.Scissors;
                        break;

                    case "H":
                        choice = Choice.Hammer;
                        break;

                    case "U":
                        choice = Choice.Underwear;
                        break;

                    default:
                        Console.WriteLine("Invalid Entry, try again");
                        break;
                }
            }

            return choice;
        }
    }
}
