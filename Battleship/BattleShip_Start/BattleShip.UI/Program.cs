﻿using System;
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
            Game battleShip = new Game();
            battleShip.Run();
           
          
            Console.ReadLine();
        }
    }
}
