using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rock, Paper, Scissors, Hammer, and Underwear");
            Console.WriteLine("Same as traditional game.\nExcept Hammer beats: rock & scissors, and loses to: paper & underwear.\nUnderwear beats: hammer & paper, and loses to: rock & scissors.");
            GamePlay newGame = new GamePlay(); 

            string input = "";

            do
            {
                newGame.PlayRound();

                Console.Write("Would you like to play again? enter Q to Quit, or any other key to keep playing");
                input = Console.ReadLine();
            } while (input.ToUpper() != "Q");
        }
    }
}
