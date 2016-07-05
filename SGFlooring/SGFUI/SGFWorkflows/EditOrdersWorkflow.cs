using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SGFBLL;
using SGFModels;

namespace SGFUI.SGFWorkflows
{
    public class EditOrdersWorkflow
    {
        
            public void EditOrders()
            {
                DateTime date = GetDateForEdit();
                int orderId = GetIdForEdit();

                ProcessOrderForEdit(date, orderId);
            }

            public DateTime GetDateForEdit()
        {
            string date;

            do
            {
                Console.Clear();

                Console.WriteLine(
                    "Please Enter the date for the order you would like to edit \n Please enter the date in MM/DD/YYYY formate.");
                date = Console.ReadLine();

                if (string.IsNullOrEmpty(date))
                {
                    Console.WriteLine("Please enter a date in the MM/DD/YYYY format.");
                    Console.ReadLine();
                }
            } while (string.IsNullOrEmpty(date));

            return Convert.ToDateTime(date);
        }

        public int GetIdForEdit()
        {
            {
                int orderId = 0;

                do
                {
                    Console.Clear();

                    Console.WriteLine("Please enter the order ID for the order you wish to edit");
                    orderId = Convert.ToInt32(Console.ReadLine());

                    if (string.IsNullOrEmpty(orderId.ToString()))
                    {
                        Console.WriteLine("Please enter an order ID");
                        Console.ReadLine();
                    }
                } while (string.IsNullOrEmpty(orderId.ToString()));

                return orderId;
            }

        }

        public void ProcessOrderForEdit(DateTime date, int orderId)
        {
            OrderOperation manager = new OrderOperation();
            var orders = manager.GetAllOrders(date);

            DisplayOrdersWorkflow displayOrder = new DisplayOrdersWorkflow();
            var order = orders.FirstOrDefault(o => o.OrderId == orderId);
            orders.Remove(order);
            displayOrder.DisplaySpecificOrder(order);

           ConsoleIO prompt = new ConsoleIO();
            var stateResponse = prompt.PromptUser("Would you like to edit your state?, press Y to edit or any other key to continue with order edit");
            if (stateResponse.ToUpper() == "Y")
            {
                order.StateTaxInfo.StateName =
                    prompt.PromptUser("Please enter your new state.");

            }

            var areaResponse = prompt.PromptUser("Would you like to edit the area of your order?, press Y to edit or any other key to continue with order edit");
            if (areaResponse.ToUpper() == "Y")
            {
                order.Area = Convert.ToDecimal(prompt.PromptUser("Please enter your new area."));
            }

            var productResponse =
                prompt.PromptUser("Would you like to update your product type?, Please enter Y to edit or any other key to continue to order edit.");
            if (productResponse.ToUpper() == "Y")
            {
                order.ProductInfo.ProductType = prompt.PromptUser("Please enter your new product type.");
            }

            displayOrder.DisplaySpecificOrder(order);
          var confrimResponse = prompt.PromptUser("Are your updates correct?, press Y  to submit your edits or any other key to abandon changes and return to main menu");
            if (confrimResponse.ToUpper() == "Y")
            {
                orders.Add(order);
                manager.RiteToFile(orders);
            }
        }
        
    }
}
