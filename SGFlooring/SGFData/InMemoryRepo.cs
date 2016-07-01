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
        private static List<ProductInfo>_productInfo;


        static InMemoryRepo()
        {
             _productInfo = new List<ProductInfo>();
            orderList = new List<OrderInfo>
            {
                new OrderInfo()
                {
                    Area = 10,
                    CustomerName = "Scooby",
                    OrderId = 1,
                    ProductInfo = new ProductInfo() {ProductType = "Wood",CostPerSquareFoot = 10},
                    StateTaxInfo = new StateTaxInfo() {StateName = "Bay Village"},
                    OrderDate = DateTime.Parse("01/01/2016"),
                    Tax = 5,
                },
                
                new OrderInfo()
                {
                    Area = 20,
                    CustomerName = "Bobo",
                    OrderId = 2,
                    ProductInfo = new ProductInfo() {ProductType = "Marble", CostPerSquareFoot = 25},
                    StateTaxInfo = new StateTaxInfo() {StateName = "Ohio"},
                    OrderDate = DateTime.Parse("01/01/2016"),
                    Tax = 4,
                 
                  
                },
                new OrderInfo()
                {
                    Area = 40,
                    CustomerName = "Scrappy",
                    OrderId = 3,
                    ProductInfo = new ProductInfo() {ProductType = "Frozen High Fructose Corn Syrup", CostPerSquareFoot = 0.5m},
                    StateTaxInfo = new StateTaxInfo() {StateName = "Iraq"},
                    OrderDate = DateTime.Parse("01/02/2016"),
                    Tax = 6,
              
                }
            };

           
        }

        public List<OrderInfo> GetOrdersByDate(DateTime orderdate)
        {

            return (from order in orderList where orderdate == order.OrderDate select order).ToList();

        }

        public OrderInfo CreateOrder(OrderInfo order)
        {
            order.OrderId = CreateNextOrderNumber();
            orderList.Add(order);

            return order;
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
            throw new NotImplementedException();
        }

       public ProductInfo GetProductByProductType(string productSearched)
       {
            var product = _productInfo.Where(p => p.ProductType == productSearched).FirstOrDefault();

            return product;
        }

        public List<StateTaxInfo> GetAllStateTaxInfos()
        {
            throw new NotImplementedException();
        }

        public StateTaxInfo GetStateTaxInfoByStateName(string stateSearched)
        {
            throw new NotImplementedException();
        }
    }

   
}
