using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    class GameWorkFlow
    {
        public static void PlaceShips(List<Player> players)
        {
            foreach (var player in players)
            {
                for (int i = 0; i < 5; i++)
                {
                    bool isValid = false;
                    do
                    {
                        PlaceShipRequest request = new PlaceShipRequest();


                        if (i == 0)
                        {
                            request.ShipType = ShipType.Destroyer;
                        }
                        else if (i == 1)
                        {
                            request.ShipType = ShipType.Submarine;
                        }
                        else if (i == 2)
                        {
                            request.ShipType = ShipType.Cruiser;
                        }
                        else if (i == 3)
                        {
                            request.ShipType = ShipType.Battleship;
                        }
                        else if (i == 4)
                        {
                            request.ShipType = ShipType.Carrier;
                        }



                        Console.WriteLine($"{player.Name} Please enter a coordinate to place your " + request.ShipType);
                        request.Coordinate = Game.GetCoordinate();
                        request.Direction = Game.GetDirection();
                        ShipPlacement response = player.Board.PlaceShip(request);
                        switch (response)
                        {

                            case ShipPlacement.NotEnoughSpace:
                                ConsoleIO.Display("There is not enough space for your ship using that coordinate, try again");
                                break;
                            case ShipPlacement.Overlap:
                                ConsoleIO.Display("Your ships are overlapping, try again");
                                break;
                            default:
                                ConsoleIO.Display("Good job placing that ship");
                                isValid = true;

                                break;

                        }
                    } while (isValid == false);
                    ConsoleIO.DisplaySetUpBoard(player.Board);

                    Console.ReadLine();

                }
                Console.Clear();
            }
        }
        public static void Turns(List<Player> playerTurns)
        {
            bool Winner = false;

            while (Winner == false)
            {
                for (int i = 1; i < 3; i++)
                {
                    Player currentPlayer = playerTurns[i - 1];
                    Player enemyPlayer = playerTurns[i % 2];

                    ConsoleIO.Display($"{currentPlayer.Name} Please enter the coordinate you would like to fire at");
                    ConsoleIO.DisplayShotHistory(enemyPlayer.Board);
                    
                    bool isShotValid = false;
                    while (isShotValid == false)
                    {
                        Coordinate shotCoordinate = Game.GetCoordinate();
                        var response = enemyPlayer.Board.FireShot(shotCoordinate);

                        switch (response.ShotStatus)
                        {
                            case ShotStatus.Invalid:
                                Console.WriteLine("Invalid Coordinate, please try again");
                                break;
                            case ShotStatus.Duplicate:
                                Console.WriteLine("You already shot there, try again");
                                break;
                            case ShotStatus.Miss:
                                Console.WriteLine("You missed, too bad");
                                isShotValid = true;
                                break;
                            case ShotStatus.Hit:
                                Console.WriteLine("You hit em' up");
                                isShotValid = true;
                                break;
                            case ShotStatus.HitAndSunk:
                                Console.WriteLine("Good job you sunk their " + response.ShipImpacted);
                                isShotValid = true;
                                break;
                            case ShotStatus.Victory:
                                Console.WriteLine("Alright,{0} you won the game", currentPlayer.Name);
                                isShotValid = true;
                                Winner = true;
                                break;
                            default:
                                Console.WriteLine("Something went terribly wronge");
                                break;
                        }
                        if (isShotValid == true)
                        {
                            ConsoleIO.DisplayShotHistory(enemyPlayer.Board);
                        }
                    }
                    if (Winner == true)
                    {

                        break;
                    }



                }
            }
        }
    }
}
