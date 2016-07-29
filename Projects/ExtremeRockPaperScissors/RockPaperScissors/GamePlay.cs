using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissors.Enums;
using RockPaperScissors.Implementation;

namespace RockPaperScissors
{
    public class GamePlay
    {
        public void PlayRound()
        {
           Player p1 = new HumanPlayer("Player 1");
           Player p2 = new ComputerPlayer("Player 2");

            MatchResult result = new MatchResult();
            result.Player1Choice = p1.GetChoice();
            result.Player2Choice = p2.GetChoice();

            //TODO:Need to compare choices and determine our winner

            if (result.Player1Choice == result.Player2Choice)
            {
                result.MatchResults = Result.Tie;
            } else if ((result.Player1Choice == Choice.Rock && result.Player2Choice == Choice.Scissors) ||
                       (result.Player1Choice == Choice.Rock && result.Player2Choice == Choice.Underwear) ||
                       (result.Player1Choice == Choice.Paper && result.Player2Choice == Choice.Rock) ||
                       (result.Player1Choice == Choice.Paper && result.Player2Choice == Choice.Hammer) ||
                       (result.Player1Choice == Choice.Scissors && result.Player2Choice == Choice.Paper)||
                       (result.Player1Choice == Choice.Scissors && result.Player2Choice == Choice.Underwear)||
                       (result.Player1Choice == Choice.Hammer && result.Player2Choice == Choice.Rock)||
                       (result.Player1Choice == Choice.Hammer && result.Player2Choice == Choice.Scissors)||
                       (result.Player1Choice == Choice.Underwear && result.Player2Choice == Choice.Hammer)||
                       (result.Player1Choice == Choice.Underwear && result.Player2Choice == Choice.Paper))
            {
                result.MatchResults = Result.Win;
            }
            else
            {
                result.MatchResults = Result.Loss;
            }

            ProcessResult(p1, p2, result);

         }

        private void ProcessResult(Player player1, Player player2, MatchResult result)
        {
            Console.WriteLine($"{player1.Name} chose {result.Player1Choice}");
            Console.WriteLine($"{player2.Name} chose {result.Player2Choice}");

            switch (result.MatchResults)
            {
                    case Result.Win:
                    Console.WriteLine($"{player1.Name} Wins");
                    break;

                    case  Result.Loss:
                    Console.WriteLine($"{player2.Name} Wins");
                    break;

                default:
                    Console.WriteLine("You both tie");
                    break;

            }
        }
    }
}
