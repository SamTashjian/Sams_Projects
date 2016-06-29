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
        //PlaceShip method() that is called within the Run(), after taking in each player's name,
        // but before running the Turns() method
        public static void PlaceShips(List<Player> players)
        {
            //foreach because each player will have to place their ships
            foreach (var player in players)
            {
                //iterating 5 times through this for loop because there are 5 ships to place
                for (int i = 0; i < 5; i++)
                {
                    bool isValid = false;
                    do
                    {
                        PlaceShipRequest request = new PlaceShipRequest();

                        //specifying which ship each user is placing, using the ShipType enum, 0-4
                        switch(i)
                        {
                            case 0:
                                request.ShipType = ShipType.Destroyer;
                                break;
                            case 1:
                                request.ShipType = ShipType.Submarine;
                                break;
                            case 2:
                                request.ShipType = ShipType.Cruiser;
                                break;
                            case 3:
                                request.ShipType = ShipType.Battleship;
                                break;
                            case 4:
                                request.ShipType = ShipType.Carrier;
                                break;
                        }


                        //Message to the user telling them to place ship, and what ship they will be placing
                        //user is forced to place ships in the order of the ShipType enum
                        Console.WriteLine($"{player.Name} Please enter a coordinate to place your " + request.ShipType);
                       
                        //Calling the GetCoordinate() method and the GetDirection() method for each ship placement
                        request.Coordinate = Game.GetCoordinate();
                        request.Direction = Game.GetDirection();

                        //Using the ShipPlacement enum in a switch statement to tell the user that they successfully
                        //choose a direction for the ship, or tell them why their ship direction was not successfull,
                        //and force them to choose again untill they choose a valid coordinate and direction.
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
                    //Displaying each user's board throughout their ship placement.
                    ConsoleIO.DisplaySetUpBoard(player.Board);

                    Console.ReadLine();

                }
                //Clearing each players board after they have successfully placed all of their ship
                //so that the opposing player cannot see their ship placement and have a competative
                //advantage.
                Console.Clear();
            }
        }
        public static void Turns(List<Player> playerTurns)
        {
            bool Winner = false;
            //This variable is set to false so the game run untill a winner is decided
            while (Winner == false)
            {

                //A loop that iterates twice, starting at 1. So that the current player will always be 
                // the iteration minus 1.  The player who is not firing(aka the enemy) will always be
                // the remainder.
                for (int i = 1; i < 3; i++)
                {
                    Player currentPlayer = playerTurns[i - 1];
                    Player enemyPlayer = playerTurns[i % 2];

                    //Displays the current player's name and prompts them to fire, to avoid confusion about
                    //whose turn it is.
                    ConsoleIO.Display($"{currentPlayer.Name} Please enter the coordinate you would like to fire at");
                    
                    //Displaying where the current player has already shot, so they will not have a dupplicate
                    //shot(hopefully), and will make a more informed decision about where their next shot should go.
                    ConsoleIO.DisplayShotHistory(enemyPlayer.Board);
                    
                    //Setting this isShotValid variable to false and only changing it to true on valid shots
                    //to force the player to shot again if they choose an invalid coordinate or shot a 
                    //duplicate shot.
                    bool isShotValid = false;
                    while (isShotValid == false)
                    {
                        //Using the GetCoordinate method again to get a coordinate for where the current player
                        //wants to fire
                        Coordinate shotCoordinate = Game.GetCoordinate();
                        //Taking in the shot on the enemy player's board
                        var response = enemyPlayer.Board.FireShot(shotCoordinate);

                        switch (response.ShotStatus)
                        {
                            //Pulling from the ShotStatus enum to determine what the result of each shot will be
                            //isShot Valid is not changed to true on Invalid and Duplicate so they have to stay 
                            //in the while loop untill a valid shot is shot.
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
                                //Changing the Winner variable to true to break out of the Turns loop, and prompt
                                //the user if they want to play again.
                                Winner = true;
                                break;
                            default:
                                Console.WriteLine("Something went terribly wronge");
                                break;
                        }
                        if (isShotValid == true)
                        {
                            //Displaying your enemy players board after the current player has shot to show the damage
                            //you have or have not done.
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
