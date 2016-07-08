using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SGFBLL;
using SGFModels;

namespace SGFUI.SGFWorkflows
{
    public class RemoveOrdersWorkflow
    {
        public void RemoveOrders()
        {
            DateTime date = GetDateForOrderRemove();
            int orderId = GetOrderIdForRemove();

            ProcessOrderForRemove(date, orderId);
        }

        public DateTime GetDateForOrderRemove()
        {
            string date = "";

            do
            {
                Console.Clear();

                Console.WriteLine(
                    "Please Enter the date for the order you would like to remove \n Please enter the date in MM/DD/YYYY formate.");
                date = Console.ReadLine();

                if (string.IsNullOrEmpty(date))
                {
                    Console.WriteLine("Please enter a date in the MM/DD/YYYY format.");
                    Console.ReadLine();
                }
            } while (string.IsNullOrEmpty(date));

            return Convert.ToDateTime(date);
        }

        public int GetOrderIdForRemove()
        {
            int orderId = 0;

            do
            {
                Console.Clear();

                Console.WriteLine("Please enter the order ID for the order you wish to remove");
                orderId = Convert.ToInt32(Console.ReadLine());

                if (string.IsNullOrEmpty(orderId.ToString()))
                {
                    Console.WriteLine("Please enter an order ID");
                    Console.ReadLine();
                }
            } while (string.IsNullOrEmpty(orderId.ToString()));

            return orderId;
        }

        public void ProcessOrderForRemove(DateTime date, int orderId)
        {

            var manager = new OrderOperation();
            var orders = manager.GetAllOrders(date);

            var orderToRemove = orders.FirstOrDefault(o => o.OrderId == orderId);

            
            ConsoleIO prompt = new ConsoleIO();
            DisplayOrdersWorkflow dipsplayOrder = new DisplayOrdersWorkflow();
            dipsplayOrder.DisplaySpecificOrder(orderToRemove);
            string userInput = prompt.PromptUser("Are you sure you would like to delete this order? Press D to delete, or any other key to return to the main menu");
            if (userInput.ToUpper() == "D")
            {
                

                var response = manager.RemoveSpecificOrder(orderToRemove);
                Console.WriteLine(response.Message);
            }
        }
    }
}

