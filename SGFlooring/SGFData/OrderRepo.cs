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

        private List<OrderInfo> ReadTextFile(string orderDate)
        {
            var date = new DateTime(int.Parse(orderDate.Substring(4,4)), int.Parse(orderDate.Substring(0, 2)), int.Parse(orderDate.Substring(2, 2)));
            List<OrderInfo> result = new List<OrderInfo>();
            string dateSearched = orderDate;

            
            if (File.Exists(string.Format("Orders_{0}.txt", dateSearched)))
            {
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
                        temp.OrderDate = date;

                        result.Add(temp);
                    }
                }
            }
            return result;
           

            }
            

        public OrderInfo CreateOrder(OrderInfo order)
        {
            OrderInfoList = GetOrdersByDate(order.OrderDate);
            order.OrderId = CreateNextOrderNumber();
       
            OrderInfoList.Add(order);
            WriteToFile(OrderInfoList);
            return order;
        }


        public void RemoveOrder(OrderInfo orders)
        {
            var currentOrders = GetOrdersByDate(orders.OrderDate);
            currentOrders.RemoveAt(currentOrders.FindIndex(x => x.OrderId == orders.OrderId));
            WriteToFile(currentOrders);
        }

        public void WriteToFile(List<OrderInfo> orderInfoList)
        {
            var orderDate = orderInfoList.FirstOrDefault().OrderDate.ToString("MMddyyyy");
    
            string fileName = string.Format("Orders_{0}.txt", orderDate);

            using (StreamWriter writeOrder = new StreamWriter(fileName))
                {
                foreach (var order in orderInfoList)
                {
                    writeOrder.WriteLine(
                            $"{order.OrderId},{order.CustomerName},{order.StateTaxInfo.StateName},{order.StateTaxInfo.TaxRate},{order.ProductInfo.ProductType},{order.Area},{order.ProductInfo.CostPerSquareFoot}," +
                            $"{order.ProductInfo.LaborCostPerSquareFoot},{order.MaterialCost},{order.LaborCost},{order.Tax},{order.Total}");
                }
            }
        }

        public int CreateNextOrderNumber()
        {
            int orderNumber;

            if (OrderInfoList.Count == 0)
            {
                orderNumber = 1;
            }
            else
            {
                orderNumber = OrderInfoList.Max(x => x.OrderId) + 1;
            }
                 
            return orderNumber;
        }

        public OrderInfo GetOneSpecificOrder(DateTime date, int orderId)
        {
          var orders =  GetOrdersByDate(date);

            var order = orders.FirstOrDefault(o => o.OrderId == orderId);
            

            return order;
        }

        public void EditOrder(OrderInfo orders)
        {
            var currentOrders = GetOrdersByDate(orders.OrderDate);
            int index = currentOrders.FindIndex(x => x.OrderId == orders.OrderId);
            currentOrders[index]= orders;
            WriteToFile(currentOrders);

        }
    }
}
