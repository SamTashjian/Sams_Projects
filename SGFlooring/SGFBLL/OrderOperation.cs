using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFData;
using SGFModels;

namespace SGFBLL
{
   public class OrderOperation
    {
       private readonly IProductRepo _productRepo;
       private IOrderRepo _orderRepo;
       private readonly IStateTaxInfoRepo _stateTaxInfoRepo;

       public OrderOperation()
        {
           var orderRepo = OrderRepoFactory.CreateOrderRepo();
           var productRepo = OrderRepoFactory.CreateProductRepo();
           var stateTaxInfo = OrderRepoFactory.CreateStateTaxInfoRepo();
        }
        public Response DisplayOrder(DateTime orderDate)
        {
            var repo = OrderRepoFactory.CreateOrderRepo();

            var responses = new Response();

            var orders = repo.GetOrdersByDate(orderDate);

            if (orders == null )
            {
                responses.Success = false;
                responses.Message = "There are no orders for that date.";
            }
            else
            {
                responses.Success = true;
                responses.OrderDetails = orders;
            }

            return responses;
        }

       public Response CreateNewOrder(OrderInfo order)
       {
           var repo = OrderRepoFactory.CreateOrderRepo();
            
           
           var response = new Response();
           response.OrderDetails = new List<OrderInfo>() {repo.CreateOrder(order)};
           response.Success = true;
           return  response;
       }

       public ProductInfo ShowProductInfo(string productType)
       {
           var repo = OrderRepoFactory.CreateProductRepo();
           var prodInfo = repo.GetProductByProductType(productType);

           return prodInfo;
       }

       public StateTaxInfo ShowStateInfo(string stateName)
       {
           var repo = OrderRepoFactory.CreateStateTaxInfoRepo();
           var stateInfo = repo.GetStateTaxInfoByStateName(stateName);

           return stateInfo;
       }

       public int CreateNewOrderNumber()
       {
            var nextOrderId = new OrderRepo();

            return nextOrderId.CreateNextOrderNumber();

        }

        
    }
}
