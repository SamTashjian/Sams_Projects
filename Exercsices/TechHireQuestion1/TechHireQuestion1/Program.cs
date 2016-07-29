using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechHireQuestion1
{
    class Program
    {


        static void Main(String[] args)
        {
            int Q = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < Q; a0++)
            {
                string[] tokens_r = Console.ReadLine().Split(' ');
                int r = Convert.ToInt32(tokens_r[0]);
                int c = Convert.ToInt32(tokens_r[1]);

                if ((r%2 == 1) && (c%2 == 1))
                {
                    Console.WriteLine("black");
                }
                else if ((r % 2 == 1) && (c % 2 == 0))
                {
                    Console.WriteLine("red");
                }
                else if ((r % 2 == 0) && (c % 2 == 1))
                {
                    Console.WriteLine("red");
                }
                else
                {
                    Console.WriteLine("black");
                }

                Console.ReadLine();
            }
            
        }
    }
}


