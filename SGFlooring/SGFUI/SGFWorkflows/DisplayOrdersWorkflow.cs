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
        public DateTime GetOrderDateFromUser()
        {
            DateTime orderDate;
            bool isValidDate = false;
            do
            {
                Console.Clear();
                Console.WriteLine(
                    "Enter the date for which you would like to see all of the orders, please enter date in MM/DD/YYYY format.");
                string input = Console.ReadLine();
                //try parse returns a true/false and sets it to rthe datetime
                isValidDate = DateTime.TryParse(input, out orderDate);
                if (!isValidDate)
                {
                    Console.WriteLine(
                        "This is not a valid date, please enter a valid date you wish to search in the MM/DD/YYYY format");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
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
                foreach (var order in responses.Data)
                {
                    PrintOrderInfo(order);
                }
            }
            else
            {
                Console.WriteLine("Error");
                Console.WriteLine(responses.Message);
                Console.ReadLine();

            }
        }

        public void PrintOrderInfo(OrderInfo order)
        {
            Console.Clear();
            Console.WriteLine("Order Information");
            Console.WriteLine("*****************");
            Console.WriteLine("                 ");
            Console.WriteLine("Customer Name: {0}", order.CustomerName);
           Console.WriteLine("Order Date: {0}", order.OrderDate);
            Console.WriteLine("Order ID: {0}", order.OrderId);
            Console.WriteLine("State: {0}", order.StateTaxInfo.StateName);
            Console.WriteLine("Area: {0}", order.Area);
            Console.WriteLine("Labor Cost Per Square Foot: {0}", order.ProductInfo.LaborCostPerSquareFoot);
            Console.WriteLine("Labot Cost: {0}", order.LaborCost);
            Console.WriteLine("Product Type: {0}", order.ProductInfo.ProductType);
            Console.WriteLine("Cost Per Square Foot {0}", order.ProductInfo.CostPerSquareFoot);
            Console.WriteLine("Material Cost: {0}", order.MaterialCost);
            Console.WriteLine("State Tax Rate: {0}", order.StateTaxInfo.TaxRate);
            Console.WriteLine("Tax: {0}", order.Tax);
            Console.WriteLine("Total: {0}", order.Total);
            Console.WriteLine("                 ");
            Console.WriteLine("Press any key to continue.");

            Console.ReadLine();
        }

        public void DisplaySpecificOrder(OrderInfo order)
        {
            PrintOrderInfo(order);
        }
    }
}
