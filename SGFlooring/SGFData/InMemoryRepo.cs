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
        private static List<StateTaxInfo> _stateTaxInfos;

        

        public  InMemoryRepo()
        {
            _productInfo = new List<ProductInfo>()
            {
                new ProductInfo()
                {
                    ProductType = "Wood",
                    CostPerSquareFoot = 5.0m,
                    LaborCostPerSquareFoot = 3.0m
                },
                new ProductInfo()
                {
                    ProductType = "Steel",
                    CostPerSquareFoot = 8.0m,
                    LaborCostPerSquareFoot = 5.0m
                },
                new ProductInfo()
                {
                    ProductType = "Plastic",
                    CostPerSquareFoot = 2.0m,
                    LaborCostPerSquareFoot = 1.5m
                }
            };

            _stateTaxInfos = new List<StateTaxInfo>()
            {
                new StateTaxInfo()
                {
                    StateName = "Ohio",
                    StateAbb = "OH",
                    TaxRate = 5.5m
                },
                new StateTaxInfo()
                {
                    StateName = "Texas",
                    StateAbb = "TX",
                    TaxRate = 3.2m
                },
                new StateTaxInfo()
                {
                    StateName = "Wisconsin",
                    StateAbb = "WI",
                    TaxRate = 4.0m
                }
            };

            if (orderList == null)
            {
                orderList = new List<OrderInfo>();
                orderList.Add(new OrderInfo()
                {
                    Area = 1000,
                    CustomerName = "Scooby",
                    OrderId = 1,
                    ProductInfo = _productInfo.FirstOrDefault( x => x.ProductType == "Wood"),
                    StateTaxInfo = _stateTaxInfos.FirstOrDefault(x => x.StateName == "Ohio"),
                    OrderDate = DateTime.Parse("01/01/2016"),

                });

                orderList.Add(new OrderInfo()
                {
                    Area = 2000,
                    CustomerName = "Bobo",
                    OrderId = 2,
                    ProductInfo = _productInfo.FirstOrDefault(x => x.ProductType == "Steel"),
                    StateTaxInfo = _stateTaxInfos.FirstOrDefault(x =>x.StateName == "Wisconsin"),
                    OrderDate = DateTime.Parse("01/01/2016"),

                });
                orderList.Add(new OrderInfo()
                {
                    Area = 4000,
                    CustomerName = "Scrappy",
                    OrderId = 1,
                    ProductInfo = _productInfo.FirstOrDefault(x => x.ProductType == "Plastic"),
                    StateTaxInfo = _stateTaxInfos.FirstOrDefault(x => x.StateName == "Texas"),
                    OrderDate = DateTime.Parse("01/02/2016"),

                });
            }


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
            order.OrderId = CreateNextOrderNumber(order.OrderDate);
            orderList.Add(order);

            return order;
        }

        public void RemoveOrder(OrderInfo orderInfo )
        {

            OrderInfo orderToRemove = new OrderInfo(); 
          
            orderList.RemoveAt(orderList.IndexOf(orderInfo));

        }

        public void EditOrder(OrderInfo orders)
        {
            var currentOrders = GetOrdersByDate(orders.OrderDate);
            int index = currentOrders.FindIndex(x => x.OrderId == orders.OrderId);
            currentOrders[index] = orders;
        }

        public int CreateNextOrderNumber(DateTime orderDate)
        {
            int orderNumber = 0;

            if (orderList.Where(x => x.OrderDate == orderDate).Any())
            {
                orderNumber = orderList.Where(x => x.OrderDate == orderDate).Max(x => x.OrderId);
            }

            return orderNumber+1;
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
