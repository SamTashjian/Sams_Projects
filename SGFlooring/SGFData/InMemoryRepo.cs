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
        private static List<OrderInfo> orderList = new List<OrderInfo>();
        private static List<ProductInfo>_productInfo;
        private static List<StateTaxInfo> _stateTaxInfos;


        static InMemoryRepo()
        {
             _productInfo = new List<ProductInfo>();
            _stateTaxInfos = new List<StateTaxInfo>();

            {
               orderList.Add( new OrderInfo()
                {
                    Area = 10,
                    CustomerName = "Scooby",
                    OrderId = 1,
                    ProductInfo = new ProductInfo() {ProductType = "Wood"},
                    StateTaxInfo = new StateTaxInfo() {StateName = "Ohio"},
                    OrderDate = DateTime.Parse("01/01/2016"),
                    //Tax = 5,
                });

                orderList.Add(new OrderInfo()
                {
                    Area = 20,
                    CustomerName = "Bobo",
                    OrderId = 2,
                    ProductInfo = new ProductInfo() {ProductType = "Tile"},
                    StateTaxInfo = new StateTaxInfo() {StateName = "Michigan"},
                    OrderDate = DateTime.Parse("01/01/2016"),
                    //Tax = 4,


                });
                orderList.Add(new OrderInfo()
                {
                    Area = 40,
                    CustomerName = "Scrappy",
                    OrderId = 3,
                    ProductInfo =
                        new ProductInfo() {ProductType = "Carpet"},
                    StateTaxInfo = new StateTaxInfo() {StateName = "Indiana"},
                    OrderDate = DateTime.Parse("01/02/2016"),
                    //Tax = 6,


                });
            };

           
        }

        public List<OrderInfo> GetOrdersByDate(DateTime orderdate)
        {

            return (from order in orderList where orderdate == order.OrderDate select order).ToList();

        }

        public OrderInfo GetOneSpecificOrder(DateTime orderdate, int orderId)
        {
            var orders = GetOrdersByDate(orderdate);

            var order = orders.FirstOrDefault(o => o.OrderId == orderId);


            return order;
        }

        public OrderInfo CreateOrder(OrderInfo order)
        {
            order.OrderId = CreateNextOrderNumber();
            orderList.Add(order);

            return order;
        }

        public void RemoveOrder(DateTime orderDate, int orderId)
        {

            OrderInfo orderToRemove = new OrderInfo(); 
            foreach (var order in orderList)
            {
                if (orderDate == order.OrderDate && orderId == order.OrderId)
                {
                    orderToRemove = order;
                }
            }
            orderList.Remove(orderToRemove);
        }

        public int CreateNextOrderNumber()
        {
            int orderNumber = 0;

            if (orderList.Count != 0)
            {
                orderNumber = orderList.Max(x => x.OrderId) + 1;
            }

            return orderNumber;
        }
        public List<ProductInfo> GetAllProducts()
        {
            return _productInfo;
        }

       public ProductInfo GetProductByProductType(string productSearched)
       {
            var product = _productInfo.Where(p => p.ProductType == productSearched).FirstOrDefault();

            return product;
        }

        public List<StateTaxInfo> GetAllStateTaxInfos()
        {
            return _stateTaxInfos;
        }

        public StateTaxInfo GetStateTaxInfoByStateName(string stateSearched)
        {
            var state = _stateTaxInfos.Where(s => s.StateName == stateSearched).FirstOrDefault();

            return state;
        }
    }

   
}
