using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SGFModels;

namespace SGFData
{
    public class OrderRepo : IOrderRepo
    {
        public static List<OrderInfo> OrderInfoList { get; set; }

        static OrderRepo()
        {
            OrderInfoList = new List<OrderInfo>();
        }

        public List<OrderInfo> GetOrdersByDate(DateTime orderdate)
        {
            //using (StreamReader sr = new StreamReader("Orders_{0}.txt", orderdate()))
            //{
                
            //}
            

            return OrderInfoList.Where(o => o.OrderDate == orderdate).ToList();
        }

        //public ReadTextFile(string orderDate)
        //{
        //    string dateSearched = orderDate("MMddyyy");
        //    StreamReader sr = new StreamReader("Orders_{0}.txt", dateSearched);

        //    return List<OrderInfo>;
        //}

        public OrderInfo CreateOrder(OrderInfo order)
        {
            order.OrderId = CreateNextOrderNumber();
            OrderInfoList.Add(order);
            WriteToFile(OrderInfoList);
            return order;
        }

        private void WriteToFile(List<OrderInfo> orderInfoList)
        {
            var results = from orderInfo in orderInfoList
                          group orderInfo by orderInfo.OrderDate into g
                          select g;

            foreach (var orderdate in results)
            {
                string currentDate = orderdate.Key.ToString("MMddyyyy");
                string fileName = string.Format("Orders_{0}.txt", currentDate);

                using (StreamWriter writeOrder = new StreamWriter(fileName))
                {
                    foreach (var order in orderdate)
                    {
                        writeOrder.WriteLine(
                            $"{order.OrderId},{order.CustomerName},{order.StateTaxInfo.StateName},{order.StateTaxInfo.TaxRate},{order.ProductInfo.ProductType},{order.Area},{order.ProductInfo.CostPerSquareFoot}," +
                            $"{order.ProductInfo.LaborCostPerSquareFoot},{order.MaterialCost},{order.LaborCost},{order.Tax},{order.Total}");
                    }
                }
            }
        }

        public int CreateNextOrderNumber()
        {
            //GetOrdersByDate(orderDate);

            //StreamReader sr = new StreamReader(orderDate);
            int orderNumber = 1;

            if (OrderInfoList.Count != 0)
            {
                orderNumber = OrderInfoList.Max(x => x.OrderId) + 1;
            }

            return orderNumber;
        }


    }
}
