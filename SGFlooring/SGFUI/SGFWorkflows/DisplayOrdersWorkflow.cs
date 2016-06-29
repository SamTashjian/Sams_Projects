using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SGFBLL;
using SGFModels;

namespace SGFUI.SGFWorkflows
{
    public class DisplayOrdersWorkflow
    {
        public OrderInfo _currentOrderDate;

        public DateTime GetOrderDateFromUser()
        {
            DateTime orderDate;
            bool isValidDate = false;
            do
            {
                Console.Clear();
                Console.WriteLine(
                    "Enter the date for which you would like to see all of the orders, please enter date in MMDDYYYY format.");
                string input = Console.ReadLine();

                if (!(isValidDate = DateTime.TryParse(input, out orderDate)))
                {
                    Console.WriteLine(
                        "This is not a valid date, please enter a valid date you wish to search in the MMDDYYYY format");
                    Console.WriteLine("Press any key to continue");
                }
               
            } while (isValidDate == false);
            return orderDate;
        }

        public void DisplayOrderInfo(DateTime orderDate)
        {
            var AO = new OrderOperation();
            var responses = AO.DisplayOrder(orderDate);

            if (responses.Success)
            {
                //TODO: loop through orders returned
                _currentOrderDate = responses.OrderDetails;

                PrintOrderInfo();

            }
            else
            {
                Console.WriteLine("Error");
                Console.WriteLine(responses.Message);
                Console.ReadLine();
            }
        }

        public void PrintOrderInfo()
        {
            Console.Clear();
            Console.WriteLine("Order Information");
            Console.WriteLine("*****************");
            Console.WriteLine("Customer Name: {0}", _currentOrderDate.CustomerName);
            Console.WriteLine("Order Date: {0}", _currentOrderDate.OrderDate);
            Console.WriteLine("Order ID: {0}", _currentOrderDate.OrderId);
            Console.WriteLine("Area: {0}", _currentOrderDate.Area);
            Console.WriteLine("Material Cost: {0}", _currentOrderDate.MaterialCost);
            Console.WriteLine("Tax: {0}", _currentOrderDate.Tax);
            Console.WriteLine("Total: {0}", _currentOrderDate.Total);
        }

    }
}
