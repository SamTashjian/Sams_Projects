using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using SGFModels;

namespace SGFData
{
    public class InMemoryRepo: IOrderRepo, IProductRepo, IStateTaxInfoRepo
    {
        private static List<OrderInfo> orderList;
        private static List<ProductInfo> productList;
        private static List<StateTaxInfo> stateTaxList;

        static InMemoryRepo()
        {
            orderList = new List<OrderInfo>()
            {
                new OrderInfo()
                {
                    Area = 10,
                    CustomerName = "Sam",
                    OrderId = 1,
                    OrderDate = DateTime.Parse("01/01/2016"),
                    Tax = 5,
                    MaterialCost = 15,
                    Total = 2000
                },
                new OrderInfo()
                {
                    Area = 20,
                    CustomerName = "bobo",
                    OrderId = 2,
                    OrderDate = DateTime.Parse("1/02/2016"),
                    Tax = 4,
                    MaterialCost = 18,
                    Total = 3000,
                  
                }
            };
            
            productList = new List<ProductInfo>();

            stateTaxList = new List<StateTaxInfo>();
        }

        

     

        public List<OrderInfo> GetOrdersByDate(DateTime orderdate)
        {
            return (from order in orderList where orderdate == order.OrderDate select order).ToList();

        }

        public List<ProductInfo> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public List<StateTaxInfo> GetAllStateTaxInfos()
        {
            throw new NotImplementedException();
        }
    }

   
}
