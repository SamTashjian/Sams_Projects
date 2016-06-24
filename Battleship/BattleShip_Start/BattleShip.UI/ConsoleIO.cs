using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class ConsoleIO
    {
        //method used to talk at the users
        public static void Display(string message)
        {
            Console.WriteLine(message);
        }
        //method used to talk to the user, and return back their input
        public static string PromptString(string message)
        {
            Display(message);
            return Console.ReadLine();
        }
        //method to set up board which will be used again throughout the program
        public static void DisplaySetUpBoard(Board board)
        {
            Console.Write("   ");
            //Creating header for the x axis
            for (char i = 'A'; i < 'K'; i++)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("");
            //Creating the actual x axis
            for (int i = 1; i < 11; i++)
            {
                //Foreach element in the x axis creating a y column that is the y axis. 
                Console.Write("{0} ", i.ToString().PadLeft(2));
                for (int j = 1; j < 11; j++)
                {
                    var results = from s in board.GetShips()
                        where s != null && s.BoardPositions.Any(b => b.XCoordinate == j && b.YCoordinate == i)
                        select s;

                    if (results.Count() > 0)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("~ ");
                    }  
                }
                Console.WriteLine("");
            }
        }
        //method used on each players turn to create a board that checks the shot history to see 
        //if each coordinate has been shot at, and if so, whether the previous shots were hits,
        //misses, or have not been shot at yet.
        public static void DisplayShotHistory(Board board)
        {
            Console.Write("   ");
            for (char i = 'A'; i < 'K'; i++)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("");
            for (int i = 1; i < 11; i++)
            {
                Console.Write("{0} ", i.ToString().PadLeft(2));
                for (int j = 1; j < 11; j++)
                {
                    Coordinate coordinate = new Coordinate(j, i);
                    bool shotHistory = board.ShotHistory.ContainsKey(coordinate);
                    if (shotHistory == true)
                    {
                        switch (board.ShotHistory[coordinate])
                        {
                            case ShotHistory.Hit:
                                Console.Write("H ");
                                break;
                            case ShotHistory.Miss:
                                Console.Write("M ");
                                break;
                            case ShotHistory.Unknown:
                                Console.Write("  ");
                                break;
                            default:
                                Console.WriteLine("Something bad happened...");
                                break;
                        }
                    }
                    else
                    {
                        Console.Write("~ ");

                    }
                }
                Console.WriteLine("");
            }
        }
    }
}
