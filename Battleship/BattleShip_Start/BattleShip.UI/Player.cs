using BattleShip.BLL.GameLogic;

namespace BattleShip.UI
{
    public class Player
    {
        //Creating the players, hold the data for their names, and their boards.
        public Player()
        {
            Board = new Board();
        }
        public string Name { get; set; }
        public Board Board { get; set; }
        
    }
}