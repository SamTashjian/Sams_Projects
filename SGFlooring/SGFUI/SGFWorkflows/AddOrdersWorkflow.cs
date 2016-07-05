using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using SGFBLL;
using SGFData;
using SGFModels;

namespace SGFUI.SGFWorkflows
{
    public class AddOrdersWorkflow
    {
        public void AddOrder()
        {
            string name = GetNameForOrder();
            string state = GetStateForOrder();
            decimal area = GetAreaForOrder();
            string productType = GetProductTypeForOrder();

            ProcessNewOrder(name, state, productType, area);
        }

        private string GetNameForOrder()
        {
            string name = "";

            do
            {
                Console.Clear();

                Console.WriteLine("Please enter a name for your new order:");
                name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Please enter something");
                    Console.ReadLine();
                }

            } while (string.IsNullOrEmpty(name));

            return name;
        }

        private string GetStateForOrder()
        {
            string state = "";

            do
            {
                Console.Clear();

                Console.WriteLine("Please enter a State for your new order:");
                state = Console.ReadLine();

                if (string.IsNullOrEmpty(state))
                {
                    Console.WriteLine("Please enter something");
                    Console.ReadLine();
                }

            } while (string.IsNullOrEmpty(state));

            return state;
        }
        
        private string GetProductTypeForOrder()
        {
            string productType = "";

            do
            {
                Console.Clear();

                Console.WriteLine("Please enter a product type for your new order:");
                productType = Console.ReadLine();

                if (string.IsNullOrEmpty(productType))
                {
                    Console.WriteLine("Please enter something");
                    Console.ReadLine();
                }

            } while (string.IsNullOrEmpty(productType));

            return productType;
        }

        private decimal GetAreaForOrder()
        {
            decimal area = 0;

                do
            {
                Console.Clear();

                Console.WriteLine("Please enter a area for your new order:");
                area = Convert.ToDecimal(Console.ReadLine());

                if (string.IsNullOrEmpty(area.ToString()))
                {
                    Console.WriteLine("Please enter something");
                    Console.ReadLine();
                }

            } while (string.IsNullOrEmpty(area.ToString()));

            return area;
        }

        private void ProcessNewOrder(string name, string state, string productType, decimal area)
        {
            var ops = new OrderOperation();
            var product = ops.ShowProductInfo(productType);
            var stateInfo = ops.ShowStateInfo(state);

            var order = new OrderInfo()
            {
                CustomerName = name,
                Area = area,
                ProductInfo = product,
                OrderDate = DateTime.Today,
                OrderId = 0,
                StateTaxInfo = stateInfo
                
            };

            DisplayOrdersWorkflow displayOrderInfo = new DisplayOrdersWorkflow();
            displayOrderInfo.PrintOrderInfo(order);
           
           
            ConsoleIO prompt = new ConsoleIO();
            string userInput = prompt.PromptUser( "Please press V to validate and submit your order, or any other key to return to the main menu.");
            if (userInput.ToUpper() == "V")
            {

                Response<OrderInfo> response = ops.CreateNewOrder(order);
                displayOrderInfo.PrintOrderInfo(order);
                

                if (!response.Success)
                {
                    Console.WriteLine("Error, please try again");
                    Console.WriteLine(response.Message);
                    Console.ReadLine();
                }
            }
        }
    }
}
