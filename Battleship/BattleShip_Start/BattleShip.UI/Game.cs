using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;


namespace BattleShip.UI
{
    public class Player
    {
        public Player()
        {
            Board = new Board();
        }
        public string Name { get; set; }
        public Board Board { get; set; }
        
    }
    public class Game
    {
        private static Dictionary<string, Coordinate> _coordinates;
        public List<Player> Players { get; set; }

        public Game()
        {
            _coordinates = new Dictionary<string, Coordinate>();
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
            Players = new List<Player>();
        }


        public void Run()
        {
            string userInput;
            do
            {
                Player player1 = new Player();
                Player player2 = new Player();
                player1.Name = ConsoleIO.PromptString("Player 1, Enter your name");
                player2.Name = ConsoleIO.PromptString("Player 2, Enter your name");
                Players.Add(player1);
                Players.Add(player2);
                ConsoleIO.Display($"Welcome to Battleship {player1.Name} and {player2.Name}, Get ready to play Battleship");

                GameWorkFlow.PlaceShips(Players);
                GameWorkFlow.Turns(Players);

                userInput = ConsoleIO.PromptString("Would you like to play again? N to exit , any other key to play again").ToUpper();
            } while (userInput != "N");
            
        }

        


        public static ShipDirection GetDirection()
        {
            ShipDirection result = ShipDirection.Up;
            int userInput = -1;
            bool isValid = false;
            do
            {
                isValid = int.TryParse(ConsoleIO.PromptString("Enter a Direction 1-Up,2-Down,3-Left,4-Right"), out userInput);
                if (!isValid)
                {
                    ConsoleIO.Display("You've messed up!");
                }
            } while (isValid == false);
            result = (ShipDirection) userInput-1;
            return result;
        }

        public static Coordinate GetCoordinate()
        {
            Coordinate result = null;
            do
            {
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

