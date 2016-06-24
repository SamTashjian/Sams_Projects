using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class MainMenu
    {
        public void Display()
        {
            string input = "";

            do
            {
                Console.Clear();
                Console.WriteLine("WELCOME TO SGBANK!");
                Console.WriteLine("--------------------");
                Console.WriteLine("1. Lookup Account");
                Console.WriteLine("2. Create Account");
                Console.WriteLine();
                Console.WriteLine("(Q) to Quit");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Enter Choice: ");

                input = Console.ReadLine();

                if (input.ToUpper() != "Q")
                {
                    ProcessChoice(input);
                }

            } while (input.ToUpper() != "Q");
        }

        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    LookupWorkflow lookup = new LookupWorkflow();
                    lookup.Execute();
                    break;
                case "2":
                  CreateAccountWorkFlow createAccnt = new CreateAccountWorkFlow();
                    createAccnt.Execute();
                    break;
                
                default:
                    Console.WriteLine("{0} is not valid!", choice);
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
