using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;


namespace BattleShip.UI
{
    public class Game
    {
        //Declaring _coordinates dictionary that it is static.
        private static Dictionary<string, Coordinate> _coordinates;
        
        //Creating properties for the Players List.
        public List<Player> Players { get; set; }

        public Game()
        {
            //Creating a new dictionary called _coordinates, that has strings(ex:A5) for the keys,
            //and coordinates that are the values for each key. Example: user inputs the string "A5"
            // they are really targeting/placing at x=1 y=5 aka (1,5).  

            _coordinates = new Dictionary<string, Coordinate>();

            //Manually adding all the keys and their values to _coordinates.
            //I'm sure there was a better way to do this, but making this dictioanry manually 
            //was a good distraction task when I got stuck.
            _coordinates.Add("A1", new Coordinate(1, 1));
            _coordinates.Add("A2", new Coordinate(1, 2));
            _coordinates.Add("A3", new Coordinate(1, 3));
            _coordinates.Add("A4", new Coordinate(1, 4));
            _coordinates.Add("A5", new Coordinate(1, 5));
            _coordinates.Add("A6", new Coordinate(1, 6));
            _coordinates.Add("A7", new Coordinate(1, 7));
            _coordinates.Add("A8", new Coordinate(1, 8));
            _coordinates.Add("A9", new Coordinate(1, 9));
            _coordinates.Add("A10", new Coordinate(1, 10));
            _coordinates.Add("B1", new Coordinate(2, 1));
            _coordinates.Add("B2", new Coordinate(2, 2));
            _coordinates.Add("B3", new Coordinate(2, 3));
            _coordinates.Add("B4", new Coordinate(2, 4));
            _coordinates.Add("B5", new Coordinate(2, 5));
            _coordinates.Add("B6", new Coordinate(2, 6));
            _coordinates.Add("B7", new Coordinate(2, 7));
            _coordinates.Add("B8", new Coordinate(2, 8));
            _coordinates.Add("B9", new Coordinate(2, 9));
            _coordinates.Add("B10", new Coordinate(2, 10));
            _coordinates.Add("C1", new Coordinate(3, 1));
            _coordinates.Add("C2", new Coordinate(3, 2));
            _coordinates.Add("C3", new Coordinate(3, 3));
            _coordinates.Add("C4", new Coordinate(3, 4));
            _coordinates.Add("C5", new Coordinate(3, 5));
            _coordinates.Add("C6", new Coordinate(3, 6));
            _coordinates.Add("C7", new Coordinate(3, 7));
            _coordinates.Add("C8", new Coordinate(3, 8));
            _coordinates.Add("C9", new Coordinate(3, 9));
            _coordinates.Add("C10", new Coordinate(3, 10));
            _coordinates.Add("D1", new Coordinate(4, 1));
            _coordinates.Add("D2", new Coordinate(4, 2));
            _coordinates.Add("D3", new Coordinate(4, 3));
            _coordinates.Add("D4", new Coordinate(4, 4));
            _coordinates.Add("D5", new Coordinate(4, 5));
            _coordinates.Add("D6", new Coordinate(4, 6));
            _coordinates.Add("D7", new Coordinate(4, 7));
            _coordinates.Add("D8", new Coordinate(4, 8));
            _coordinates.Add("D9", new Coordinate(4, 9));
            _coordinates.Add("D10", new Coordinate(4, 10));
            _coordinates.Add("E1", new Coordinate(5, 1));
            _coordinates.Add("E2", new Coordinate(5, 2));
            _coordinates.Add("E3", new Coordinate(5, 3));
            _coordinates.Add("E4", new Coordinate(5, 4));
            _coordinates.Add("E5", new Coordinate(5, 5));
            _coordinates.Add("E6", new Coordinate(5, 6));
            _coordinates.Add("E7", new Coordinate(5, 7));
            _coordinates.Add("E8", new Coordinate(5, 8));
            _coordinates.Add("E9", new Coordinate(5, 9));
            _coordinates.Add("E10", new Coordinate(5, 10));
            _coordinates.Add("F1", new Coordinate(6, 1));
            _coordinates.Add("F2", new Coordinate(6, 2));
            _coordinates.Add("F3", new Coordinate(6, 3));
            _coordinates.Add("F4", new Coordinate(6, 4));
            _coordinates.Add("F5", new Coordinate(6, 5));
            _coordinates.Add("F6", new Coordinate(6, 6));
            _coordinates.Add("F7", new Coordinate(6, 7));
            _coordinates.Add("F8", new Coordinate(6, 8));
            _coordinates.Add("F9", new Coordinate(6, 9));
            _coordinates.Add("F10", new Coordinate(6, 10));
            _coordinates.Add("G1", new Coordinate(7, 1));
            _coordinates.Add("G2", new Coordinate(7, 2));
            _coordinates.Add("G3", new Coordinate(7, 3));
            _coordinates.Add("G4", new Coordinate(7, 4));
            _coordinates.Add("G5", new Coordinate(7, 5));
            _coordinates.Add("G6", new Coordinate(7, 6));
            _coordinates.Add("G7", new Coordinate(7, 7));
            _coordinates.Add("G8", new Coordinate(7, 8));
            _coordinates.Add("G9", new Coordinate(7, 9));
            _coordinates.Add("G10", new Coordinate(7, 10));
            _coordinates.Add("H1", new Coordinate(8, 1));
            _coordinates.Add("H2", new Coordinate(8, 2));
            _coordinates.Add("H3", new Coordinate(8, 3));
            _coordinates.Add("H4", new Coordinate(8, 4));
            _coordinates.Add("H5", new Coordinate(8, 5));
            _coordinates.Add("H6", new Coordinate(8, 6));
            _coordinates.Add("H7", new Coordinate(8, 7));
            _coordinates.Add("H8", new Coordinate(8, 8));
            _coordinates.Add("H9", new Coordinate(8, 9));
            _coordinates.Add("H10", new Coordinate(8, 10));
            _coordinates.Add("I1", new Coordinate(9, 1));
            _coordinates.Add("I2", new Coordinate(9, 2));
            _coordinates.Add("I3", new Coordinate(9, 3));
            _coordinates.Add("I4", new Coordinate(9, 4));
            _coordinates.Add("I5", new Coordinate(9, 5));
            _coordinates.Add("I6", new Coordinate(9, 6));
            _coordinates.Add("I7", new Coordinate(9, 7));
            _coordinates.Add("I8", new Coordinate(9, 8));
            _coordinates.Add("I9", new Coordinate(9, 9));
            _coordinates.Add("I10", new Coordinate(9, 10));
            _coordinates.Add("J1", new Coordinate(10, 1));
            _coordinates.Add("J2", new Coordinate(10, 2));
            _coordinates.Add("J3", new Coordinate(10, 3));
            _coordinates.Add("J4", new Coordinate(10, 4));
            _coordinates.Add("J5", new Coordinate(10, 5));
            _coordinates.Add("J6", new Coordinate(10, 6));
            _coordinates.Add("J7", new Coordinate(10, 7));
            _coordinates.Add("J8", new Coordinate(10, 8));
            _coordinates.Add("J9", new Coordinate(10, 9));
            _coordinates.Add("J10", new Coordinate(10, 10));
            
            //Creating new list called Players that will hold each player
            Players = new List<Player>();
        }

        //The only method that will actually be ran, other methods will be called within 
        //the Run() method
        public void Run()
        {
            string userInput;
            do
            {
                //Creating player 1 and player 2, getting each players name from each user 
                //and storing it in a variable, adding each player to the Players List, and
                // displaying a welcome message to both players, including both of their names
                Player player1 = new Player();
                Player player2 = new Player();
                player1.Name = ConsoleIO.PromptString("Player 1, Enter your name");
                player2.Name = ConsoleIO.PromptString("Player 2, Enter your name");
                Players.Add(player1);
                Players.Add(player2);
                ConsoleIO.Display($"Welcome to Battleship {player1.Name} and {player2.Name}, Get ready to play Battleship");

                //calling the PlaceShips method(self-explanatory), followed by the Turns method that
                //takes us through the rest of the game
                GameWorkFlow.PlaceShips(Players);
                GameWorkFlow.Turns(Players);

                //The entire game is wrapped in this do/while loop
                //The game will play and repeat while the variable userInput is not set to "N"
                //As soon as userInput is set to N by the user at the conclusion of the Turns()
                //method, we will break out of the loop and exit the console app.
                userInput = ConsoleIO.PromptString("Would you like to play again? N to exit , any other key to play again").ToUpper();
            } while (userInput != "N");
            
        }

        

        //Method used to get each players input on which direction they would like to place
        //each ship.
        public static ShipDirection GetDirection()
        {
            //setting all the variables in this method so they won't interfere with the execution
            //of the rest of the code in this method
            ShipDirection result = ShipDirection.Up;
            int userInput = -1;
            bool isValid = false;
            do
            {
                //Asking the user what direction they want to place their ship for each ship.
                //Telling the user to input a number that corresponds to a direction.
                // Using an if statment to check if the user put in a valid direction(1-4)
                //and not letting them move on to the next ship untill they have chose a valid 
                //direction
                isValid = int.TryParse(ConsoleIO.PromptString("Enter a Direction 1-Up,2-Down,3-Left,4-Right"), out userInput);
                //If statement does not allow for the user to input outside of 1 through 4 (thanks Brendan).
                if (!isValid  || userInput <1 || userInput >4)
                {
                    ConsoleIO.Display("You've messed up!");
                    isValid = false;
                }
            } while (isValid == false);
            //Had to subtract each player's ship direction by 1 because the user's input is choosing
            // a direction from the ShipDirection enum, which starts at 0 and goes through 3
            //rather than the 1-4 that the users are prompted input. 
            result = (ShipDirection) userInput-1;
            return result;
        }

        //Method to access coordinates during ship placement and firing shots
        public static Coordinate GetCoordinate()
        {
            Coordinate result = null;
            do
            {
                //taking in the user input(ex:"A5") and checking to see if the _coordinates
                //dictionary contains the user input, and returning the user input if it is a key
                //in the dictionary.  If it is not, it displays an error message to the user,
                // and the while loop forces them to put in coordinate, untill they put in a 
                //valid coordinate
                string userInput = Console.ReadLine().ToUpper();
                if (_coordinates.ContainsKey(userInput))
                {
                    result = _coordinates[userInput];
                }
                else
                {
                    ConsoleIO.Display("Invalid Coordinate");
                }
            } while (result == null);
            return result;
        }
    }
}

