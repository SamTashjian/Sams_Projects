using BattleShip.BLL.GameLogic;

namespace BattleShip.UI
{
    //Creating the Player class  that  holds the data for their names, and their boards.
    public class Player
    {
        
        public Player()
        {
            //Creating a new Board from the Board class called board.
            Board = new Board();
        }
        public string Name { get; set; }
        public Board Board { get; set; }
        
    }
}