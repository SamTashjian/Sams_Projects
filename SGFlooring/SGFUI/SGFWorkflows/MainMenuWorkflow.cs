using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFUI.SGFWorkflows
{
    public class MainMenuWorkflow
    {
        public void DisplayMainMenu()
        {
            string userInput = "";
            bool inMenu = true;
            do
            {
                Console.Clear();
                Console.WriteLine("******************************************");
                Console.WriteLine("*      Welcome to SG Flooring Company    *");
                Console.WriteLine("*                                        *");
                Console.WriteLine("                                          ");
                Console.WriteLine("           1. Display Orders              ");
                Console.WriteLine("           2. Add Order                   ");
                Console.WriteLine("           3. Edit an Order               ");
                Console.WriteLine("           4. Remove an Order             ");
                Console.WriteLine("           5. Quit                        ");
                Console.WriteLine("                                          ");
                Console.WriteLine("    *Please enter the number that         ");
                Console.WriteLine("*     corresponds with the operation     *");
                Console.WriteLine("*     you would like to perform          *");
                Console.WriteLine("******************************************");

                userInput = Console.ReadLine();

                inMenu = ProcessChoice(userInput);

            } while (inMenu);


        }

        public bool ProcessChoice(string option)
        {
            bool inMenu = true;
            switch (option)
            {
                case "1":
                    DisplayOrdersWorkflow displayOrders = new DisplayOrdersWorkflow();
                    DateTime orderDate = displayOrders.GetOrderDateFromUser();
                        displayOrders.DisplayOrderInfo(orderDate);
                    break;

                case "2":
                    AddOrdersWorkflow addOrders = new AddOrdersWorkflow();
                     addOrders.AddOrder();
                    break;

                case "3":
                    EditOrdersWorkflow editOrders = new EditOrdersWorkflow();
                    //editOrders. method to be made
                    break;

                case "4":
                    RemoveOrdersWorkflow removeOrders = new RemoveOrdersWorkflow();
                    //removeOrders. method to be made
                    break;

                case "5":
                    Console.WriteLine("Goodbye");
                    Console.ReadLine();
                    inMenu = false;
                    break;

                default:
                    Console.WriteLine("{0} is not an option, please enter a number between 1 and 5", option);
                    Console.WriteLine("Please hit any key to continue");
                    Console.ReadLine();
                    break;
            }
            return inMenu;
        }
    }
}
