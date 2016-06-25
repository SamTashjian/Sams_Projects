using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating a new Gam called battleship
            Game battleShip = new Game();
            //Running the Run() method.  The only method I call from the Main method.  All other methods
            //run within the Run() method.
            battleShip.Run();
           
          
            Console.ReadLine();
        }
    }
}
