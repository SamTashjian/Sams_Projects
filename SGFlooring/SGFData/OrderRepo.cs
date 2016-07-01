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
            OrderInfoList = ReadTextFile(orderdate.ToString("MMddyyyy"));


            return OrderInfoList;
        }

        public List<OrderInfo> ReadTextFile(string orderDate)
        {
            List<OrderInfo> result = new List <OrderInfo>();
            string dateSearched = orderDate;
            using (StreamReader sr = new StreamReader(string.Format("Orders_{0}.txt", dateSearched)))
            {
                string[] records = sr.ReadToEnd().Split('\n');
                for (int i = 0; i < records.Length; i++)
                {
                    string record = records[i];
                    if (record.Length < 1)
                    {
                        continue;
                    }
                    string[] fields = record.Split(',');
                    OrderInfo temp = new OrderInfo();
                    temp.OrderId = Convert.ToInt32(fields[0]);
                    temp.CustomerName = fields[1];
                    temp.StateTaxInfo.StateName = fields[2];
                    temp.StateTaxInfo.TaxRate = Convert.ToDecimal(fields[3]);
                    temp.ProductInfo.ProductType = fields[4];
                    temp.Area = Convert.ToDecimal(fields[5]);
                    temp.ProductInfo.CostPerSquareFoot = Convert.ToDecimal(fields[6]);
                    temp.ProductInfo.LaborCostPerSquareFoot = Convert.ToDecimal(fields[7]);

                    result.Add(temp);
                }
            }
            return result;
        }

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
