using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFUI
{
    public class ConsoleIO
    {
        public static void Display(string message)
        {
            Console.WriteLine(message);
        }

        public static string PromptUser(string message)
        {
            Console.WriteLine(message);

            return Console.ReadLine();
        }
    }
}
